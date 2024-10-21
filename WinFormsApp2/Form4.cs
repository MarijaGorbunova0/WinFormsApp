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
        Label timeLabel;
        int score = 0;
        Timer timer2 = new Timer();
        int timeLeft;
        FlowLayoutPanel flowLayoutPanel;
        Button startButton;
        int pairs = 0;
        ComboBox colorComboBox;
        ComboBox iconComboBox;
        List<string> defaultIcons = new List<string>() { "!", "!", "N", "N", ",", ",", "k", "k", "b", "b", "v", "v", "w", "w", "z", "z" };
        List<string> alternativeIcons = new List<string>() {"A", "A", "B", "B", "C", "C", "D", "D","E", "E", "F", "F", "G", "G", "H", "H" };

        List<string> icons;


        public Form4(int w, int h)
        {
            Width = w;
            Height = h;

            flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Top;
            flowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel.Size = new Size(200, 30);

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


            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));

            Controls.Add(flowLayoutPanel);
            
            

            timer.Interval = 750;
            timer.Tick += new EventHandler(timer1_Tick);

            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);

            timeLabel = new Label();
            timeLabel.AutoSize = false;
            timeLabel.BorderStyle = BorderStyle.FixedSingle;
            timeLabel.Width = 200;
            timeLabel.Height = 30;
            timeLabel.Font = new Font(timeLabel.Font.FontFamily, 15.75f);
            timeLabel.TextAlign = ContentAlignment.MiddleCenter; 
            timeLabel.Text = "30 seconds";

            colorComboBox = new ComboBox();
            colorComboBox.Name = "colorComboBox";
            colorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            colorComboBox.Location = new Point(10, 10);
            colorComboBox.Width = 200;
            colorComboBox.Items.AddRange(new string[] { "punane", "roheline", "sinine", "kollane", "valge" });
            colorComboBox.SelectedIndexChanged += Change_Colors;

            iconComboBox = new ComboBox();
            iconComboBox.Name = "iconComboBox";
            iconComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            iconComboBox.Location = new Point(120, 10);
            iconComboBox.Width = 100;
            iconComboBox.Text = "ikonki";
            iconComboBox.Items.AddRange(new string[] { "tavaliset", "teised" });
            iconComboBox.SelectedIndexChanged += Change_Icons;
         


            flowLayoutPanel.Controls.Add(colorComboBox);
            flowLayoutPanel.Controls.Add(iconComboBox);
            flowLayoutPanel.Controls.Add(timeLabel);

            for (int i = 0; i < 16; i++)
            {
                Label label = new Label();
                kvadrati(label, 0, i);
               
            }
            Controls.Add(tableLayoutPanel);
            

            startButton = new Button();
            startButton.Name = "startButton";
            startButton.Text = "Start";
            startButton.AutoSize = true;
            startButton.Font = new System.Drawing.Font("Arial", 14);
            startButton.TabIndex = 0;
            startButton.Location = new System.Drawing.Point((this.Width - startButton.Width) / 2, 380);
            startButton.Click += new EventHandler(StartButton_Click);
            flowLayoutPanel.Controls.Add(startButton);
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
            List<string> iconCopy = new List<string>(icons); 
            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label iconLabel)
                {
                    int randomNumber = random.Next(iconCopy.Count);
                    iconLabel.Text = iconCopy[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    iconCopy.RemoveAt(randomNumber); 
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
            
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                CheckForWinner();
                if (firstClicked.Text == secondClicked.Text)
                {

                    firstClicked = null;
                    secondClicked = null;
                    pairs++;
                    return;
                }
                else
                {
                    firstClicked.ForeColor = Color.Red;
                    secondClicked.ForeColor = Color.Red;

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
            if (pairs == 8) 
            {
                MessageBox.Show("You matched all the icons!", "Congratulations");
                Close();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            timeLeft = 10;
            timeLabel.Text = $"{timeLeft} seconds";
            timer2.Start();
            pairs = 0;
            AssignIconsToSquares();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; 
                timeLabel.Text = $"{timeLeft} seconds";
            }
            else
            {
                timeLeft = 10;

                if (pairs == 0)
                {
                    AssignIconsToSquares(); 
                    MessageBox.Show("Time's up! The icons have been shuffled.");
                }

                pairs = 0; 
            }
        }
        private void Change_Colors(object sender, EventArgs e)
        {
            Color selectedColor;

            switch (colorComboBox.SelectedItem.ToString())
            {
                case "punane":
                    selectedColor = Color.IndianRed;
                    break;
                case "roheline":
                    selectedColor = Color.MediumSeaGreen;
                    break;
                case "sinine":
                    selectedColor = Color.CornflowerBlue;
                    break;
                case "kollane":
                    selectedColor = Color.LightYellow;
                    break;
                case "valge":
                    selectedColor = Color.White;
                    break;
                default:
                    selectedColor = this.BackColor;
                    break;
            }


            BackColor = selectedColor;
            tableLayoutPanel.BackColor = selectedColor;

            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label)
                {
                    label.BackColor = selectedColor;
                }
            }
        }
        private void Change_Icons(object sender, EventArgs e)
        {
            if (iconComboBox.SelectedIndex == 0) // Стандартные
            {
                icons = defaultIcons;
            }
            else if (iconComboBox.SelectedIndex == 1)
            {
                icons = alternativeIcons;
            }

            AssignIconsToSquares(); 
        }

    }
}
