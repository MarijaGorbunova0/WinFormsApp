using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

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
        ListBox lb;
        DataGridView dg;
        DataSet ds;
        TextBox txt;
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
            tn.Nodes.Add(new TreeNode("tabel"));
            tn.Nodes.Add(new TreeNode("Loetelu"));
            tn.Nodes.Add(new TreeNode("Dialoogi"));

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
            pBox.Location = new Point(150, 150);
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
 
        //private void Txt_textChanged(object? sender, EventArgs e) {
        //    lbl.Text = txt.Text;
        //}
        private void Lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb.SelectedIndex != -1)
            {
                switch (lb.SelectedItem.ToString())
                {
                    case "uks":
                        tree.BackColor = Color.LightBlue;   
                        break;
                    case "kaks":
                        tree.BackColor = Color.LightGreen;  
                        break;
                    case "kolm":
                        tree.BackColor = Color.LightCoral; 
                        break;
                }
            }
        }
            private void Dg_RowHeaderMouseClick(object? sender,DataGridViewCellMouseEventArgs e )
        {
            lbl.Text = dg.Rows[e.RowIndex].Cells[0].Value.ToString() + "hind" + dg.Rows[e.RowIndex].Cells[1].Value.ToString();

        }
        private void Dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dg.Rows[e.RowIndex];
                lbl.Text = row.Cells["name"].Value.ToString();
            }
        }
        private void AddItemsXml(object? sender, EventArgs e)
        {
            ds = new DataSet();
            ds.ReadXml(@"..\..\..\menu.xml");
           
            DataRow newROW = ds.Tables["food"].NewRow();
            newROW["name"] = Interaction.InputBox("name");
            newROW["price"] = Interaction.InputBox("price");
            newROW["description"] = Interaction.InputBox("description");
            newROW["calories"] = Interaction.InputBox("calories");

            ds.Tables["food"].Rows.Add(newROW);
            try
            {
                ds.WriteXml(@"..\..\..\menu.xml");
                MessageBox.Show("andmed on edukalt tabelis");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"problem {ex.Message}");
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
            else if (e.Node.Text == "Markiruut")
            {
                Controls.Add(chk1);
                Controls.Add(chk2);
            }
            else if (e.Node.Text == "Loetelu")
            {
                lb = new ListBox();
                lb.Items.Add("uks");
                lb.Items.Add("kaks");
                lb.Items.Add("kolm");
                lb.Location = new Point(450, 300);
                Controls.Add(lb);
                lb.SelectedIndexChanged += Lb_SelectedIndexChanged;
            }
            else if (e.Node.Text == "tabel")
            {
                ds = new DataSet("XML fail");
                ds.ReadXml(@"..\..\..\menu.xml");
                dg = new DataGridView();
                dg.Location = new Point(150, 400);
                dg.DataSource = ds;
                dg.DataMember = "food";
                dg.CellClick += Dg_CellClick; 
                Controls.Add(dg);

            }
            else if (e.Node.Text == "Dialoogi")
            {
                
                MessageBox.Show("Dialoog", "see on lihtne aken");
                var vastus = MessageBox.Show("Sisesatme andmes", "kas tahad input button kustutada?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vastus == DialogResult.Yes)
                {
                    AddItemsXml(sender, e);
                }   
            }
        }  
    }
}
