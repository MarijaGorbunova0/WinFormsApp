using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        CheckBox chk;
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
            tn.Nodes.Add(new TreeNode("Märkiruut"));
            
            
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
            pBox.Size = new Size(60, 60);
            pBox.Location = new Point(150, btn.Height + btn.Width + 5);
            pBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pBox.Image = Image.FromFile(@"..\..\..\esimene.jpg");
            pBox.DoubleClick += Pbox_DoubleClick;
        }
        int t = 0;
        int tt = 0;
        private void Pbox_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "esimene.png", "teine.png", "kolmas.png" };
            string fail = pildid[tt];
            pBox.Image = Image.FromFile(@"..\..\..\" + fail);
            tt++;
            if (tt == 3) { tt = 0; }
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
            else if ( e.Node.Text == "Märkiruut")
            {
                chk = new CheckBox();

            }
        }
    }
}
