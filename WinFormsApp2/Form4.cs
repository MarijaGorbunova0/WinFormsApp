using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp2
{
    public partial class Form4 : Form
    {
        TableLayoutPanel tableLayoutPanel;
        Random random = new Random();

        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer = new Timer();
        TextBox txb;
        Label labelscore;
        int score = 0;

        List<string> icons = new List<string>()
            {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
            };

        public Form4(int w, int h)
        {
            this.Width = w;
            this.Height = h;

            
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.BackColor = Color.CornflowerBlue;
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            

            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            Controls.Add(tableLayoutPanel);

            timer.Interval = 750;
            timer.Tick += new EventHandler(timer1_Tick);
            
            Label labelscore = new Label();
            labelscore.Text = score.ToString();
            labelscore.Location = new Point(300, 100);
            Controls.Add(labelscore);
            //нужно вывести счет попыток
            

            for (int i = 0; i < 16; i++)
            {
                Label label = new Label();
                kvadrati(label, 0, i);
               
            }

            AssignIconsToSquares();


        }
        private void kvadrati(Label label1, int row, int column)
        {

                label1 = new Label();
                label1.BackColor = Color.CornflowerBlue;
                label1.AutoSize = false;
                label1.Dock = DockStyle.Fill;
                label1.TextAlign = ContentAlignment.MiddleCenter;
                label1.Font = new Font("Webdings", 48, FontStyle.Bold);
                label1.Text = "c";
                label1.UseCompatibleTextRendering = true;
                label1.Click += label1_Click;
                tableLayoutPanel.Controls.Add(label1, column, row);
                
        }
        private void AssignIconsToSquares()
        {
      
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
  
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    tableLayoutPanel.BackColor = Color.CornflowerBlue;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {

                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                else
                {
                    firstClicked.ForeColor = Color.Red;
                    secondClicked.ForeColor = Color.Red;
                    score++;
                }
                timer.Start();

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (firstClicked != null)
            {
                firstClicked.ForeColor = firstClicked.BackColor;
            }

            if (secondClicked != null)
            {
                secondClicked.ForeColor = secondClicked.BackColor;
            }

            firstClicked = null;
            secondClicked = null;
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
        }
    }
}
