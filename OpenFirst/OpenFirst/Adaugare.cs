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
    public partial class Adaugare : Form
    {
        public static OleDbConnection DBConnection = new OleDbConnection(); //Conexiune

        public Adaugare()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=OpenFirst.mdb";
            DBConnection.Open();
        }

        private void insertSpatiiLibere()
        {
            string query = "INSERT INTO SpatiiLibere (inainte, cuvant, dupa) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
            OleDbCommand OledbInsert = new OleDbCommand(query, DBConnection);
            OledbInsert.ExecuteNonQuery();
            MessageBox.Show("Intrebarea a fost inregistrata cu succes");
        }

        private void insertAlegeRasp()
        {
            string query = "INSERT INTO VarMultiple (enunt, rasp1, rasp2, rasp3, rasp4, raspCorect) VALUES ('"+textBox8.Text+"','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','";
            if (radioButton1.Checked) query += "1')";
            else if (radioButton2.Checked) query += "2')";
            else if (radioButton3.Checked) query += "3')";
            else if (radioButton4.Checked)query += "4')";

            OleDbCommand OledbInsert = new OleDbCommand(query, DBConnection);
            OledbInsert.ExecuteNonQuery();
            MessageBox.Show("Intrebarea a fost inregistrata cu succes");
        }

        private void insertCorectareText()
        {
            string query = "INSERT INTO Corectare (textcorect, textgresit) VALUES ('" + textBox9.Text + "','" + textBox10.Text + "')";
            OleDbCommand OledbInsert = new OleDbCommand(query, DBConnection);
            OledbInsert.ExecuteNonQuery();
            MessageBox.Show("Intrebarea a fost inregistrata cu succes");
        }

        private void Adaugare_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertSpatiiLibere();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insertAlegeRasp();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertCorectareText();
            textBox10.Clear();
            textBox9.Clear();
        }

        private void Adaugare_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConnection.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
