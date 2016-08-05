using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace OpenFirst
{
    public partial class Logare : Form
    {
        OleDbConnection DBConnection = new OleDbConnection(); //Conexiune
        OleDbDataAdapter DataAdapterCont;
        DataTable LocalDataTableCont = new DataTable();
        public Meniu formMeniu;

        public Logare()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=OpenFirst.mdb";
            DBConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAdapterCont = new OleDbDataAdapter("Select * FROM Conturi WHERE email='" + textBox1.Text+"')", DBConnection);
            DataAdapterCont.Fill(LocalDataTableCont);

            if (LocalDataTableCont.Rows.Count == 1)
            {
                formMeniu = new Meniu();
                formMeniu.email = textBox1.Text;
                formMeniu.ShowDialog();
            }
        
                
        }
    }
}
