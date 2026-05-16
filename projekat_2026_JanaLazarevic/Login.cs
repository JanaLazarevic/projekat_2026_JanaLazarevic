using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekat_2026_JanaLazarevic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIme.Text == "" || txtSifra.Text == "")
            {
                MessageBox.Show("Morate uneti podatke u oba polja!!!");
            }
            else
            {
               
                SqlConnection veza = Konekcija.Connect();
                DataTable podaci = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM korisnik WHERE ime =" + "'" + txtIme.Text + "'", veza);
                adapter.Fill(podaci);
                int count = podaci.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Dato ime je nevažece!");
                }
                else
                {
                   

                    if (podaci.Rows[0]["pass"].ToString() == txtSifra.Text)
                    {
                        MessageBox.Show("Uspesno ste se ulogovali!!!!");
                        this.Hide();
                        Glavna forma = new Glavna();
                        forma.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sifra je netacnaaa!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registracija r = new Registracija();
            r.Show();
            this.Hide();
        }
    }
}
