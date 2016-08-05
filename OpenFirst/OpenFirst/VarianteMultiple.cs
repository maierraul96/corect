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
    public partial class VarianteMultiple : Form
    {
        OleDbConnection DBConnection = new OleDbConnection(); //Conexiune

        List<RadioButton> listaTexteRasp = new List<RadioButton>();
        List<GroupBox> listaenunturi = new List<GroupBox>();

        List<string> listaselectii = new List<string>();
        List<string> listarandom = new List<string>();

        OleDbDataAdapter DataAdapterIntrebari;
        DataTable LocalDataTableIntrbari = new DataTable();

        public VarianteMultiple()
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

            OleDbCommand command = new OleDbCommand("SELECT ID FROM VarMultiple", DBConnection);
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
                DataAdapterIntrebari = new OleDbDataAdapter("Select * FROM VarMultiple WHERE ID=" + listarandom[i], DBConnection);
                DataAdapterIntrebari.Fill(LocalDataTableIntrbari);
            }

            for (i=0;i<=9;i++)
            {
                for (int j = 1; j <= 4; j++)
                    listaTexteRasp[i * 4 + j-1].Text = LocalDataTableIntrbari.Rows[i][j + 1].ToString();
                listaenunturi[i].Text = LocalDataTableIntrbari.Rows[i]["enunt"].ToString();
            }
        }

        private void verificare()
        {
            int scor = 0;
            for (int i=0;i<=9;i++)
            {
                if (listaTexteRasp[i * 4 + Convert.ToInt16(LocalDataTableIntrbari.Rows[i]["raspCorect"]) -1].Checked)
                    scor++;

                //MessageBox.Show(Convert.ToString( Convert.ToInt16(LocalDataTableIntrbari.Rows[i]["raspCorect"]) ));
            }
            MessageBox.Show("Ai rezolvat corect "+scor.ToString()+" din 10 exercitii");
            foreach (RadioButton item in listaTexteRasp)
            {
                item.Checked = false;
            }
            this.Close();
        }



        private void VarianteMultiple_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();

            listaenunturi.Clear();
            listaTexteRasp.Clear();

            //int i = 1;
            //listaTexteRasp.Add((radioButton + i) as RadioButton);


            listaTexteRasp.Add(radioButton1);
            listaTexteRasp.Add(radioButton2);
            listaTexteRasp.Add(radioButton3);
            listaTexteRasp.Add(radioButton4);
            listaTexteRasp.Add(radioButton5);
            listaTexteRasp.Add(radioButton6);
            listaTexteRasp.Add(radioButton7);
            listaTexteRasp.Add(radioButton8);
            listaTexteRasp.Add(radioButton9);
            listaTexteRasp.Add(radioButton10);
            listaTexteRasp.Add(radioButton11);
            listaTexteRasp.Add(radioButton12);
            listaTexteRasp.Add(radioButton13);
            listaTexteRasp.Add(radioButton14);
            listaTexteRasp.Add(radioButton15);
            listaTexteRasp.Add(radioButton16);
            listaTexteRasp.Add(radioButton17);
            listaTexteRasp.Add(radioButton18);
            listaTexteRasp.Add(radioButton19);
            listaTexteRasp.Add(radioButton20);
            listaTexteRasp.Add(radioButton21);
            listaTexteRasp.Add(radioButton22);
            listaTexteRasp.Add(radioButton23);
            listaTexteRasp.Add(radioButton24);
            listaTexteRasp.Add(radioButton25);
            listaTexteRasp.Add(radioButton26);
            listaTexteRasp.Add(radioButton27);
            listaTexteRasp.Add(radioButton28);
            listaTexteRasp.Add(radioButton29);
            listaTexteRasp.Add(radioButton30);
            listaTexteRasp.Add(radioButton31);
            listaTexteRasp.Add(radioButton32);
            listaTexteRasp.Add(radioButton33);
            listaTexteRasp.Add(radioButton34);
            listaTexteRasp.Add(radioButton35);
            listaTexteRasp.Add(radioButton36);
            listaTexteRasp.Add(radioButton37);
            listaTexteRasp.Add(radioButton38);
            listaTexteRasp.Add(radioButton39);
            listaTexteRasp.Add(radioButton40);


            listaenunturi.Add(groupBox1);
            listaenunturi.Add(groupBox2);
            listaenunturi.Add(groupBox3);
            listaenunturi.Add(groupBox4);
            listaenunturi.Add(groupBox5);
            listaenunturi.Add(groupBox6);
            listaenunturi.Add(groupBox7);
            listaenunturi.Add(groupBox8);
            listaenunturi.Add(groupBox9);
            listaenunturi.Add(groupBox10);

            

            getTexte();

            foreach (RadioButton item in listaTexteRasp)
            {
                item.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verificare();
        }

        private void VarianteMultiple_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBConnection.Close();
        }
    }
}
