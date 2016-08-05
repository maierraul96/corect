using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenFirst
{
    public partial class Meniu : Form
    {
        public string email;
        public static int puncte;

        public SpatLib formSpatiiLibere = new SpatLib();
        public Corectare formCorectare = new Corectare();
        public VarianteMultiple formVarianteMultiple = new VarianteMultiple();
        public Adaugare formAdaugare = new Adaugare();

        public Meniu()
        {
            InitializeComponent();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formSpatiiLibere.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formVarianteMultiple.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formCorectare.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formAdaugare.ShowDialog();
        }
    }
}
