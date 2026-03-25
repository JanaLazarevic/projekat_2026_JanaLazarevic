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
    public partial class sifarnik : Form
    {
        DataTable tabela;
        SqlDataAdapter Adapter;
        string ime_tabele;
        public sifarnik(string tabela)
        {
            ime_tabele = tabela;
            InitializeComponent();
        }

        private void sifarnik_Load(object sender, EventArgs e)
        {
            Adapter = new SqlDataAdapter("SELECT * FROM " + ime_tabele, Konekcija.Connect());
            tabela = new DataTable();
            Adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
            dataGridView1.Columns["id"].ReadOnly = true;
        }
    }
}
