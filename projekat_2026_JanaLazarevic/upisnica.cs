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

namespace projekat_2026_JanaLazarevic
{
    public partial class upisnica : Form
    {
        public upisnica()
        {
            InitializeComponent();
        }
        private void comboBox1_populate()
        { 
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM skolska_godina",veza);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "naziv";
            comboBox1.SelectedValue = 2;
        }
        private void comboBox2_populate()

        { 
            string godina = comboBox1.SelectedValue.ToString();
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id,str(razredni) + '-' + indeks AS naziv FORM  odeljenje" + godina, veza);
            DataTable dt2 = new DataTable();
            adapter.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "naziv";
        }
        private void upisnica_Load(object sender, EventArgs e)
        {
            comboBox1_populate();
            comboBox2_populate();
            comboBox2.SelectedIndex = -1;
        }

        private void txt_upisnica_TextChanged(object sender, EventArgs e)
        {

        }

        private void upisnica_Load_1(object sender, EventArgs e)
        {

        }
    }
}
