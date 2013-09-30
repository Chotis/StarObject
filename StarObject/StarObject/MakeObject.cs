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
    public partial class MakeObject : Form
    {
        OpenFileDialog getName = new OpenFileDialog();
        String savePath = "";

        public MakeObject()
        {
            InitializeComponent();
            cmbRace.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            cmbAnchors.SelectedIndex = 0;
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
            save.Filter = "object files (*.object)| .object ";

            if (save.ShowDialog() == DialogResult.OK)
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(save.FileName, false))
                {
                    file.WriteLine("{");
                    file.WriteLine("  \"objectName\"" + " :" + " \"" + txbObjName.Text + "\",");
                    file.WriteLine("  \"description\"" + " :" + " \"" + txbObjDescr.Text + "\",");
                    file.WriteLine("  \"shortdescription\"" + " :" + " \"" + txbObjShortDescr.Text + "\",");
                    file.WriteLine("  \"race\"" + " :" + " \"" + cmbRace.Text + "\",");
                    file.WriteLine("  \"dropItem\"" + " :" + " \"" + txbDropItem.Text + "\",");
                    file.WriteLine("  \"category\"" + " :" + " \"" + cmbCategory.Text + "\",");
                    file.WriteLine(" ");
                    file.WriteLine("  \"orientations\"" + " :" + " [");
                    file.WriteLine("    {");
                    file.WriteLine("      \"image\"" + " :" + " \"" + txbImage.Text + ":{color}.{frame}" + "\",");
                    file.WriteLine("      \"imagePosition\"" + " :" + " [" + txbImgPosX.Text + ", " + txbImgPosY.Text + "],");
                    file.WriteLine("      \"frames\"" + " : " + txbFrame.Text + ",");
                    file.WriteLine("      \"animationCycle\"" + " : " + txbAnimCycle.Text + ",");
                    file.WriteLine(" ");
                    file.WriteLine("      \"spaceScan\"" + " : " + txbSpaceScan.Text + ",");
                    file.WriteLine("      \"anchors\"" + " : " + "[ \"" + cmbAnchors.Text + "\" ]");
                    file.WriteLine(" ");
                    file.WriteLine("    }");
                    file.WriteLine("  ]");
                    file.WriteLine(" }");
                    file.Close();
                }

                MessageBox.Show("Saved Succesfully :D");

            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpObject helpObj = new HelpObject();
            helpObj.Show();
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            if (txbImage.Text == "")
            {
                getName.Filter = "Png Files (*.png)|*.png";
                getName.ShowDialog();
                String imageName = System.IO.Path.GetFileName(getName.FileName);
                txbImage.Text = imageName;
            }
            else if(txbImage.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to change the image?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    txbImage.Text = "";
                    getName.Filter = "Png Files (*.png)|*.png";
                    getName.ShowDialog();
                    String imageName = System.IO.Path.GetFileName(getName.FileName);
                    txbImage.Text = imageName;
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
        }

    }
}
