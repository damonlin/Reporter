using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace AutoMode
{
    public partial class InspectPage1 : Common.Wizard.CCInteriorWizardPage
    {
        public InspectPage1()
        {
            InitializeComponent();

            // 修正 TableLayout 閃爍問題
            MakeTablelayoutSmooth();
        }

        private void MakeTablelayoutSmooth()
        {
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);
            tableLayoutPanel6.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel6, true, null);
            tableLayoutPanel7.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel7, true, null);
            tableLayoutPanel8.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel8, true, null);
            tableLayoutPanel9.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel9, true, null);
            tableLayoutPanel10.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel10, true, null);
            tableLayoutPanel11.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel11, true, null);
            tableLayoutPanel12.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel12, true, null);
            tableLayoutPanel13.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel13, true, null);
            tableLayoutPanel14.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel14, true, null);
            tableLayoutPanel15.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel15, true, null);
            tableLayoutPanel16.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel16, true, null);
            tableLayoutPanel17.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel17, true, null);
            tableLayoutPanel18.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel18, true, null);
            tableLayoutPanel19.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel19, true, null);
            tableLayoutPanel20.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel20, true, null);
            tableLayoutPanel21.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel21, true, null);

        }        

        private void DrawBolder(int col, int row, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == col && e.Row == row)
                e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), e.CellBounds.Location, new Point(e.CellBounds.Left, e.CellBounds.Bottom));
        }

        private void tableLayoutPanel9_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
            DrawBolder(2, 0, e);
            DrawBolder(3, 0, e);
        }

        private void tableLayoutPanel8_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
            DrawBolder(2, 0, e);
            DrawBolder(3, 0, e);
        }

        private void tableLayoutPanel6_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
        }

        private void tableLayoutPanel7_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
            DrawBolder(2, 0, e);
            DrawBolder(3, 0, e);
        }

        private void tableLayoutPanel4_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
        }

        private void tableLayoutPanel5_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            DrawBolder(1, 0, e);
        }

        private void tableLayoutPanel10_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel11_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
           
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string curItem = comboBox.SelectedItem.ToString();
            int index = comboBox.FindString(curItem);
            if (index == 0)
            {
                AutoMode.Input input = new AutoMode.Input();
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    comboBox.Items.Add(input.GetMsg());
                    comboBox.SelectedIndex = comboBox.Items.Count-1;
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    CaptureScreen();
        //    //printDocument1.Print();
        //    //printPreviewDialog1.Document = printDocument1;
        //    //rintPreviewDialog1.ShowDialog();
        //    dlgPageSetup.ShowDialog();
        //}
    }
}
