using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoMode
{
    public partial class InspectPage2 : Common.Wizard.CCInteriorWizardPage
    {
        public InspectPage2()
        {
            InitializeComponent();
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

        }      
        
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectPic(sender);
        }

        private void SelectPic(object sender)
        {            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Image File";
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()

            // Get the selected file name and display in a TextBox
            //if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlg.FileName != null)
            {
                //pictureBox1.Image = Image.FromFile(dlg.FileName);
                System.Drawing.Image image = System.Drawing.Image.FromFile("E:\\Picture\\2013-08-29-水災\\照片\\P_20130829_165503.jpg");
                System.Drawing.Imaging.ImageFormat thisFormat = image.RawFormat;
                int fixWidth = 0;
                int fixHeight = 0;

                int maxPx = ((Button)sender).Size.Width >= ((Button)sender).Size.Height ? ((Button)sender).Size.Width : ((Button)sender).Size.Height;
                if (image.Width > maxPx || image.Height > maxPx)
                {
                    if (image.Width >= image.Height)
                    {
                        fixWidth = maxPx;
                        fixHeight = Convert.ToInt32((Convert.ToDouble(fixWidth) / Convert.ToDouble(image.Width)) * Convert.ToDouble(image.Height));
                    }
                    else
                    {
                        fixHeight = maxPx;
                        fixWidth = Convert.ToInt32((Convert.ToDouble(fixHeight) / Convert.ToDouble(image.Height)) * Convert.ToDouble(image.Width));
                    }
                }
                else
                {
                    fixHeight = image.Height;
                    fixWidth = image.Width;
                }

                Bitmap imageOutput = new Bitmap(image, fixWidth, fixHeight);
                ((Button)sender).BackgroundImage = imageOutput;
                ((Button)sender).Text = "";

                //imageOutput.Dispose();
                image.Dispose();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();
            int index = listBox1.FindString(curItem);
            if( index == 0 )
            {
                AutoMode.Input input = new AutoMode.Input();
                DialogResult dr = input.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    listBox1.Items.Add(input.GetMsg());
                }
            }
        }
    }
}
