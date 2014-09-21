using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoMode
{
    public partial class Input : Form
    {
        private string Msg;
        public Input()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Msg = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public string GetMsg()
        {
            return Msg;
        }
    }
}
