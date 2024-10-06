using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp2
{
    public partial class StartVorm : Form
    {
        //List<string> elemendid = new List<string>("nupp", "silt", "Pilt");
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pBox;
        CheckBox chk1, chk2;
        private int pictureIndex = 0;
        public StartVorm()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("Pilt"));
            tn.Nodes.Add(new TreeNode("Markiruut"));
            
            
            //tn.Nodes.Add(new TreeNode(Silt));

            this.Controls.Add(tree);
            tree.Nodes.Add(tn);

            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;
            // silt - label
            
            lbl = new Label();
            lbl.Text = "Alande";
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
            lbl.Size = new Size(200, 50);
            lbl.Location = new Point(150, 0);

            pBox = new PictureBox();
            pBox.Size = new Size(200, 200);
            pBox.Location = new Point(200, 150);
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.Image = Image.FromFile(@"..\..\..\esimene.jpg");
            pBox.DoubleClick += Pbox_DoubleClick;


            chk1 = new CheckBox();
            chk1.Text = "esimene vaade";
            chk1.Location = new Point(450, 200);
            chk1.CheckedChanged += Chk_CheckedChanged;

            chk2 = new CheckBox();
            chk2.Text = "teine vaade";
            chk2.Location = new Point(450, 230);
            chk2.CheckedChanged += Chk_CheckedChanged;
        }
        int t = 0;
            
        private void Pbox_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "esimene.jpg", "teine.png", "kolmas.jpg" };
            pictureIndex = (pictureIndex + 1) % pildid.Length;
            pBox.Image = Image.FromFile(@"..\..\..\" + pildid[pictureIndex]);
        }
        private void Btn_Click(object? sender, EventArgs e)
        {
            btn.BackColor = Color.White;
            t++;
            if (t % 2 == 0)
            {
                btn.BackColor = Color.Red;

            }
        }
        private void Lbl_MouseHover(object? sender, MouseEventArgs e)
        {
            lbl.Font = new Font("Arial", 30, FontStyle.Underline);
        }
        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (chk1.Checked && chk2.Checked)
            {
                lbl.BorderStyle = BorderStyle.Fixed3D;
                pBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (chk1.Checked)
            {
                lbl.BorderStyle = BorderStyle.Fixed3D;
                pBox.BorderStyle = BorderStyle.None;
            }
            else if (chk2.Checked)
            {
                pBox.BorderStyle = BorderStyle.Fixed3D;
                lbl.BorderStyle = BorderStyle.None;
            }
            else
            {
                lbl.BorderStyle = BorderStyle.None;
                pBox.BorderStyle = BorderStyle.None;
            }
        }
        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pBox);
            }
            else if ( e.Node.Text == "Markiruut")
            {
                Controls.Add(chk1);
                Controls.Add(chk2);
            }
        }
    }
}
