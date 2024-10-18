using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;
namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        TableLayoutPanel tableLayoutPanel;
        PictureBox pictureBox1;
        Button btn_bkg, btn_Simage, btn_Clear, btn_Close;
        ColorDialog colorDialog1;
        OpenFileDialog openFileDialog1;
        CheckBox checkBox1;
        FlowLayoutPanel flowLayoutPanel;
        Button borderBTN;
        Panel picturePanel;
        Graphics graphics;
        Button drowBTN;
        public Form2(int w, int h)
        {

            this.Width = w;
            this.Height = h;

            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));


            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;


            checkBox1 = new CheckBox();
            checkBox1.Text = "Stretch";
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;


            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;

            btn_bkg = new Button();
            btn_bkg.Text = "color";
            btn_bkg.Height = 20;
            btn_bkg.Width = 50;
            btn_bkg.Location = new Point(150, 50);
            btn_bkg.Click += new EventHandler(backgroundButton_Click);

            btn_Simage = new Button();
            btn_Simage.Text = "image";
            btn_Simage.Height = 20;
            btn_Simage.Width = 50;
            btn_Simage.Location = new Point(150, 70);
            btn_Simage.Click += ShowImage;

            btn_Close = new Button();
            btn_Close.Text = "close";
            btn_Close.Height = 20;
            btn_Close.Width = 50;
            btn_Close.Location = new Point(150, 50);
            btn_Close.Click += closeButton_Click;

            btn_Clear = new Button();
            btn_Clear.Text = "clear";
            btn_Clear.Height = 20;
            btn_Clear.Width = 50;
            btn_Clear.Location = new Point(150, 50);
            btn_Clear.Click += clearButton_Click;

            borderBTN = new Button();
            borderBTN.Text = "Border";
            borderBTN.Height = 20;
            borderBTN.Width = 50;
            borderBTN.Location = new Point(150, 50);
            borderBTN.Click += Drow;

            drowBTN = new Button();
            drowBTN.Text = "Drow";
            drowBTN.Height = 20;
            drowBTN.Width = 50;
            drowBTN.Location = new Point(150, 50);
            drowBTN.Click += AddBorder;

            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a picture file";

            colorDialog1 = new ColorDialog();

       
            Controls.Add(tableLayoutPanel);

            flowLayoutPanel.Controls.Add(btn_Simage);
            flowLayoutPanel.Controls.Add(btn_bkg);
            flowLayoutPanel.Controls.Add(btn_Close);
            flowLayoutPanel.Controls.Add(btn_Clear);
            flowLayoutPanel.Controls.Add(borderBTN);

            tableLayoutPanel.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel.SetColumnSpan(pictureBox1, 2);
            tableLayoutPanel.Controls.Add(checkBox1, 0, 1);
            tableLayoutPanel.Controls.Add(flowLayoutPanel, 1, 1);


   

            picturePanel = new Panel();
            picturePanel.Dock = DockStyle.Fill;
            picturePanel.Padding = new Padding(5); 

            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BorderStyle = BorderStyle.None;
            picturePanel.Controls.Add(pictureBox1);
            tableLayoutPanel.Controls.Add(picturePanel, 0, 0);
            tableLayoutPanel.SetColumnSpan(picturePanel, 2);

            Controls.Add(tableLayoutPanel);
           
        }
        private void backgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }
        private void ShowImage(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AddBorder(object sender, EventArgs e )    
        {
            if (pictureBox1.Image != null)
            {
                picturePanel.BackColor = Color.Red;
            }
            else
            {
                MessageBox.Show("teil ei ole pildi");
            }
        }
        private void Drow()
        {
            if (pictureBox1 == null)
                return;

            Graphics.DrawImage(
                pictureBox1,
                picturePanel.AutoScrollPosition.X,
                picturePanel.AutoScrollPosition.Y,
                pictureBox1.Size.Width,
                pictureBox1.Size.Height
            );
        }
            
    }
}
