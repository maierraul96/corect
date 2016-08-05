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
    public partial class CreeareCont : Form
    {
        OleDbConnection DBConnection = new OleDbConnection(); //Conexiune

        public CreeareCont()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=OpenFirst.mdb";
            DBConnection.Open();
        }

        private void CreeareCont_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Conturi (nume, prenume, email, parola, tip) VALUES ('" + textBox1.Text + "','" + textBox2.Text +"','"+textBox3.Text+"','"+textBox4.Text+"','"+comboBox1.Text+ "')";
            OleDbCommand OledbInsert = new OleDbCommand(query, DBConnection);
            OledbInsert.ExecuteNonQuery();
            this.Close();
        }
    }
}
