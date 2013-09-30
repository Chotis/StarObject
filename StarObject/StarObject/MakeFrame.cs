using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarObject
{
    public partial class MakeFrame : Form
    {
        public MakeFrame()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if (tb.Text == "")
                {
                    MessageBox.Show("You have left the " + tb.Name.ToString() + " parameter empty :(");
                    return; // Kevin's contribution to this code. I learned something new here.
                }
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "frames files (*.frames)| .frames ";
           
            if (save.ShowDialog() == DialogResult.OK)
            {
                int noOfFrames = Int32.Parse(txbNumOfAnim.Text);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(save.FileName, false))
                {
                    file.WriteLine("{");
                    file.WriteLine(" ");
                    file.WriteLine("  \"frameGrid\"" + " :" + " {");
                    file.WriteLine("      \"size\"" + " :" + " [" + txbWidth.Text + ", " + txbHeight.Text + "],");
                    file.WriteLine("      \"dimensions\"" + " :" + " [" + txbNumOfFrames.Text + ", " + txbColour.Text + "],");
                    file.WriteLine("      \"names\"" + " : " + "[ ");
                    file.Write("[ ");

                    for (int i = 0; i < noOfFrames; i++)
                    {
                        if (i == noOfFrames - 1)
                        {
                            file.Write("\"default" + "." + i + "\" ] ");
                        }
                        else
                        {
                            file.Write("\"default" + "." + i + "\", ");
                        }
                    }
                    file.WriteLine(" ");
                    file.WriteLine("    ]");
                    file.WriteLine("  }");
                    file.WriteLine("}");
                }

            }
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpFrame hfrm = new HelpFrame();
            hfrm.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            

        }
    }
}
