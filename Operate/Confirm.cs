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
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(bool value)
        {
            InitializeComponent();
            bOnOff = value;
            if (bOnOff)
            {
                btnOn.BackColor = Color.Green;
                btnOff.BackColor = SystemColors.Control;
            }
            else
            {
                btnOn.BackColor = SystemColors.Control;
                btnOff.BackColor = Color.Green;
            }

        }

        private bool bOnOff = false;
        public bool ON
        {
            get { return bOnOff; }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            bOnOff = true;
            if (bOnOff)
            {
                btnOn.BackColor = Color.Green;
                btnOff.BackColor = SystemColors.Control;
            }
            else
            {
                btnOn.BackColor = SystemColors.Control;
                btnOff.BackColor = Color.Green;
            }

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            bOnOff = false;
            if (bOnOff)
            {
                btnOn.BackColor = Color.Green;
                btnOff.BackColor = SystemColors.Control;
            }
            else
            {
                btnOn.BackColor = SystemColors.Control;
                btnOff.BackColor = Color.Green;
            }
        }
    }
}
