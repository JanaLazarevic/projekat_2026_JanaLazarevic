using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projekat_2026_JanaLazarevic
{
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void Registracija_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baza = Program.user;

            if (textBox4.Text == textBox5.Text)
            {
                SqlConnection veza = Konekcija.Connect();

                string provera = "SELECT COUNT(*) FROM Korisnik WHERE korisnik_email = @email";
                SqlCommand komanda = new SqlCommand(provera, veza);
                komanda.Parameters.AddWithValue("@email", textBox3.Text);

                veza.Open();
                int ima = (int)komanda.ExecuteScalar();
                veza.Close();

                if (ima > 0)
                {
                    MessageBox.Show("Ovaj email je već registrovan!");
                }
                else
                {
                    string naredba = "INSERT INTO Korisnik (koirsnik_email, korisnik_loz) VALUES ( @email, @lozinka)";
                    SqlCommand uradi = new SqlCommand(naredba, veza);

                    
                    uradi.Parameters.AddWithValue("@lozinka", textBox4.Text);
                    uradi.Parameters.AddWithValue("@email", textBox3.Text);

                    veza.Open();
                    uradi.ExecuteNonQuery();
                    veza.Close();

                    MessageBox.Show("Uspešno ste se registrovali!");

                    this.Hide();
                    Glavna forma = new Glavna();
                    forma.Show();
                }
            }
            else
            {
                MessageBox.Show("Ponovljena lozinka nije dobra!");
            }
        }
    }
}
