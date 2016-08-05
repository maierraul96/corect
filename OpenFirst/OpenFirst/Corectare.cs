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
    public partial class Corectare : Form
    {
        OleDbConnection DBConnection = new OleDbConnection(); //Conexiune
        OleDbDataAdapter DataAdapterIntrebari;
        DataTable LocalDataTableIntrbari = new DataTable();

        List<TextBox> listatexte = new List<TextBox>();

        List<string> listaselectii = new List<string>();
        List<string> listarandom = new List<string>();

        public Corectare()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=OpenFirst.mdb";
            DBConnection.Open();
        }

        private void getTexte()
        {
            Random rnd = new Random();
            listaselectii.Clear();
            listarandom.Clear();

            OleDbCommand command = new OleDbCommand("SELECT ID FROM Corectare", DBConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                listaselectii.Add(reader["ID"].ToString());
            reader.Close();

            int i = 0;
            int aux = rnd.Next(listaselectii.Count);
            while (i <= 9)
            {

                while (listarandom.Contains(listaselectii[aux]))
                {
                    aux = rnd.Next(listaselectii.Count);

                }
                // MessageBox.Show(aux.ToString());

                listarandom.Add(listaselectii[aux]);
                i++;
            }

            LocalDataTableIntrbari.Clear();

            for (i = 0; i <= 9; i++)
            {
                DataAdapterIntrebari = new OleDbDataAdapter("Select * FROM Corectare WHERE ID=" + listarandom[i], DBConnection);
                DataAdapterIntrebari.Fill(LocalDataTableIntrbari);
            }

            for (i = 0; i <= 9; i++)
                listatexte[i].Text = LocalDataTableIntrbari.Rows[i]["textgresit"].ToString();
        }

        private void Verificare()
        {
            int scor = 0;
            for (int i = 0; i <= 9; i++)
                if (listatexte[i].Text == LocalDataTableIntrbari.Rows[i]["textcorect"].ToString())
                    scor++;

            MessageBox.Show("Ai rezolvat corect "+scor.ToString()+" din 10 exercitii");

            this.Close();
        }

        private void Corectare_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();

            listatexte.Clear();

            listatexte.Add(textBox1);
            listatexte.Add(textBox2);
            listatexte.Add(textBox3);
            listatexte.Add(textBox4);
            listatexte.Add(textBox5);
            listatexte.Add(textBox6);
            listatexte.Add(textBox7);
            listatexte.Add(textBox8);
            listatexte.Add(textBox9);
            listatexte.Add(textBox10);

            getTexte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Verificare();
        }

        private void Corectare_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConnection.Close();
        }
    }
}
