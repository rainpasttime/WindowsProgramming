using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            Easy easy = new Easy();
            easy.Show();
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            Normal normal = new Normal();
            normal.Show();
        }

        private void DifficultButton_Click(object sender, EventArgs e)
        {
            Difficult diff = new Difficult();
            diff.Show();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
