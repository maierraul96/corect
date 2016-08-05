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
    public partial class SpatLib : Form
    {
        OleDbConnection DBConnection = new OleDbConnection(); //Conexiune

        OleDbDataAdapter DataAdapterIDuri; //Definesc un DataAdapter pentru a aduce informatii din baza de date;
        OleDbDataAdapter DataAdapterIntrebari;

        DataTable LocalDataTableIDuri = new DataTable();
        DataTable LocalDataTableIntrbari = new DataTable();

        List<string> listaselectii = new List<string>();
        List<string> listarandom = new List<string>();
        List<Label> listainainte = new List<Label>();
        List<Label> listadupa = new List<Label>();
        List<TextBox> listacuvant = new List<TextBox>();

        public SpatLib()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            DBConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=OpenFirst.mdb";
            DBConnection.Open();
        }

        private void getIntrebari()
        {
            Random rnd = new Random();
            bool ExistingQuestions = true;
            
            listaselectii.Clear();
            listarandom.Clear();

            OleDbCommand command = new OleDbCommand("SELECT ID FROM SpatiiLibere", DBConnection);
            OleDbDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
                listaselectii.Add(reader["ID"].ToString());
            reader.Close();

           // MessageBox.Show(listaselectii.Count.ToString());
            int i = 0;
            int aux = rnd.Next(listaselectii.Count);
            while (i<=9)
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

            for (i=0;i<=9;i++)
            {
                DataAdapterIntrebari = new OleDbDataAdapter("Select * FROM SpatiiLibere WHERE ID=" + listarandom[i], DBConnection);
                DataAdapterIntrebari.Fill(LocalDataTableIntrbari);
            }

            

            for (i = 0; i <= 9; i++)
            {
                listainainte[i].Text = LocalDataTableIntrbari.Rows[i]["inainte"].ToString();
                listadupa[i].Text = LocalDataTableIntrbari.Rows[i]["dupa"].ToString();
            }

        }

        private void verificare()
        {
            int scor = 0;
            for (int i=0; i<=9;i++)
            {
                if (listacuvant[i].Text == LocalDataTableIntrbari.Rows[i]["cuvant"].ToString())
                    scor++;
            }
            MessageBox.Show("Execrcitii rezolvate corect:"+scor.ToString()+" din 10");
            for (int i = 0; i <= 9; i++)
                listacuvant[i].Clear();

            this.Close();
        }


        private void rearanjare()
        {
            for (int i=0; i<=9; i++)
            {
                listainainte[i].Location = new Point(5, listainainte[i].Location.Y);
                listacuvant[i].Location = new Point(listainainte[i].Location.X + listainainte[i].Width + 10, listainainte[i].Location.Y);
                listadupa[i].Location = new Point(listacuvant[i].Location.X + listacuvant[i].Width + 10, listainainte[i].Location.Y);
            }
            
        }



        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void SpatLib_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            listainainte.Clear();
            listadupa.Clear();
            listacuvant.Clear();

            listainainte.Add(lbInainte1);
            listainainte.Add(lbInainte2);
            listainainte.Add(lbInainte3);
            listainainte.Add(lbInainte4);
            listainainte.Add(lbInainte5);
            listainainte.Add(lbInainte6);
            listainainte.Add(lbInainte7);
            listainainte.Add(lbInainte8);
            listainainte.Add(lbInainte9);
            listainainte.Add(lbInainte10);

            listadupa.Add(lbDupa1);
            listadupa.Add(lbDupa2);
            listadupa.Add(lbDupa3);
            listadupa.Add(lbDupa4);
            listadupa.Add(lbDupa5);
            listadupa.Add(lbDupa6);
            listadupa.Add(lbDupa7);
            listadupa.Add(lbDupa8);
            listadupa.Add(lbDupa9);
            listadupa.Add(lbDupa10);

            listacuvant.Add(textBox1);
            listacuvant.Add(textBox2);
            listacuvant.Add(textBox3);
            listacuvant.Add(textBox4);
            listacuvant.Add(textBox5);
            listacuvant.Add(textBox6);
            listacuvant.Add(textBox7);
            listacuvant.Add(textBox8);
            listacuvant.Add(textBox9);
            listacuvant.Add(textBox10);

            getIntrebari();
            rearanjare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getIntrebari();
            rearanjare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verificare();
        }

        private void SpatLib_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConnection.Close();
        }
    }
}
