﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp2
{
    public partial class Form3 : Form

    {
        Random randomizer = new Random();

        Label plusLeftLabel, plusRightLabel, operatorLabel, equalsLabel;
        NumericUpDown sum;

        Label minusLeftLabel, minusRightLabel, minusOperatorLabel, minusEqualsLabel;
        NumericUpDown difference;

        Label timesLeftLabel, timesRightLabel, timesOperatorLabel, timesEqualsLabel;
        NumericUpDown product;

        Label dividedLeftLabel, dividedRightLabel, dividedOperatorLabel, dividedEqualsLabel;
        NumericUpDown quotient;

        Button startButton;
        int addend1, addend2;
        int minuend, subtrahend, multiplicand, multiplier, dividend, divisor;
        int timeLeft;
        Timer timer1 = new Timer();
        Label timeLabel;
        int player1Score, player2Score;
        bool isPlayer1Turn = true;

        CheckBox darkThemeCB, lightThemeCB;
        public Form3(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Width = w;
            this.Height = h;

            plusLeftLabel = CreateLabel("plusLeftLabel", "?", 50, 75);
            operatorLabel = CreateLabel("operatorLabel", "+", 120, 75);
            plusRightLabel = CreateLabel("plusRightLabel", "?", 190, 75);
            equalsLabel = CreateLabel("equalsLabel", "=", 260, 75);
            sum = CreateNumericUpDown("sum", 330, 85, 1);

            minusLeftLabel = CreateLabel("minusLeftLabel", "?", 50, 150);
            minusOperatorLabel = CreateLabel("minusOperatorLabel", "-", 120, 150);
            minusRightLabel = CreateLabel("minusRightLabel", "?", 190, 150);
            minusEqualsLabel = CreateLabel("minusEqualsLabel", "=", 260, 150);
            difference = CreateNumericUpDown("difference", 330, 160, 2);

            timesLeftLabel = CreateLabel("timesLeftLabel", "?", 50, 225);
            timesOperatorLabel = CreateLabel("timesOperatorLabel", "×", 120, 225);  
            timesRightLabel = CreateLabel("timesRightLabel", "?", 190, 225);
            timesEqualsLabel = CreateLabel("timesEqualsLabel", "=", 260, 225);
            product = CreateNumericUpDown("product", 330, 235, 3);

            dividedLeftLabel = CreateLabel("dividedLeftLabel", "?", 50, 300);
            dividedOperatorLabel = CreateLabel("dividedOperatorLabel", "÷", 120, 300);  
            dividedRightLabel = CreateLabel("dividedRightLabel", "?", 190, 300);
            dividedEqualsLabel = CreateLabel("dividedEqualsLabel", "=", 260, 300);
            quotient = CreateNumericUpDown("quotient", 330, 310, 4);

            startButton = new Button();
            startButton.Name = "startButton";
            startButton.Text = "Start the quiz";
            startButton.AutoSize = true;
            startButton.Font = new System.Drawing.Font("Arial", 14);
            startButton.TabIndex = 0; 
            startButton.Location = new System.Drawing.Point((this.Width - startButton.Width) / 2, 380);
            startButton.Click += startButton_Click;

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);


            timeLabel = new Label();
            timeLabel.AutoSize = false;
            timeLabel.BorderStyle = BorderStyle.FixedSingle;
            timeLabel.Width = 200;
            timeLabel.Height = 30;
            timeLabel.Font = new Font(timeLabel.Font.FontFamily, 15.75f);
            timeLabel.Location = new Point(300, 0);

            darkThemeCB = new CheckBox();
            darkThemeCB.Text = "black theme";
            darkThemeCB.Location = new Point(10, 10);
            darkThemeCB.CheckedChanged += Set_theme;

            lightThemeCB = new CheckBox();
            lightThemeCB.Text = "light theme";
            lightThemeCB.Location = new Point(150, 10);
            lightThemeCB.CheckedChanged += Set_theme;


            Controls.Add(plusLeftLabel);
            Controls.Add(operatorLabel);
            Controls.Add(plusRightLabel);
            Controls.Add(equalsLabel);
            Controls.Add(sum);

            Controls.Add(minusLeftLabel);
            Controls.Add(minusOperatorLabel);
            Controls.Add(minusRightLabel);
            Controls.Add(minusEqualsLabel);
            Controls.Add(difference);

            Controls.Add(timesLeftLabel);
            Controls.Add(timesOperatorLabel);
            Controls.Add(timesRightLabel);
            Controls.Add(timesEqualsLabel);
            Controls.Add(product);

            Controls.Add(dividedLeftLabel);
            Controls.Add(dividedOperatorLabel);
            Controls.Add(dividedRightLabel);
            Controls.Add(dividedEqualsLabel);
            Controls.Add(quotient);

            Controls.Add(startButton);
            Controls.Add(timeLabel);
            Controls.Add(darkThemeCB);
            Controls.Add(lightThemeCB);
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private Label CreateLabel(string name, string text, int x, int y)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.AutoSize = false;
            label.Size = new Size(60, 50);
            label.Font = new Font("Arial", 18);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(x, y);
            return label;
        }

        
        private NumericUpDown CreateNumericUpDown(string name, int x, int y, int tabIndex)
        {
            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Name = name;
            numericUpDown.Font = new Font("Arial", 18);
            numericUpDown.MaximumSize = new Size(100, 0);
            numericUpDown.Location = new Point(x, y);
            numericUpDown.Width = 100;
            numericUpDown.TabIndex = tabIndex;  
            return numericUpDown;
        }
        public void StartTheQuiz()
        {

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 20;
            timeLabel.Text = "30 seconds";
            timer1.Start();



        }
        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
        private void CheckAnswer(NumericUpDown answerBox, int correctAnswer)
        {
            if (answerBox.Value == correctAnswer)
            {
                answerBox.BackColor = Color.Green;  
            }
            else
            {
                answerBox.BackColor = Color.Red;    
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckAnswer(sum, addend1 + addend2);        
            CheckAnswer(difference, minuend - subtrahend); 
            CheckAnswer(product, multiplicand * multiplier); 
            CheckAnswer(quotient, dividend / divisor);
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");

                if (isPlayer1Turn)
                {
                    player1Score = timeLeft;  
                    isPlayer1Turn = false;    
                    StartTheQuiz();
                }
                else
                {
                    player2Score = timeLeft;
                    ShowWinner();
                    startButton.Enabled = true;
                }
            }
            else if (timeLeft > 0)
            {
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
                timeLabel.BackColor = Color.White;
                if (timeLeft < 6)
                {
                    timeLabel.BackColor = Color.Red;
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Time's up!", "Sorry!");

                if (isPlayer1Turn)
                {
                    player1Score = 0;  
                    isPlayer1Turn = false;
                    StartTheQuiz();
                }
                else
                {
                    player2Score = 0;
                    ShowWinner();
                    startButton.Enabled = true;
                }
            }
        }
        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void ShowWinner()
        {
            if (player1Score > player2Score)
            {
                MessageBox.Show("Player 1 wins!", "Result");
            }
            else if (player1Score < player2Score)
            {
                MessageBox.Show("Player 2 wins!", "Result");
            }
            else
            {
                MessageBox.Show("It's a tie!", "Result");
            }
        }
        private void Set_theme(object sender, EventArgs e)
        {
            if ( darkThemeCB.Checked)
            {
                lightThemeCB.Checked = false;  
                BackColor = Color.Black;
                ForeColor = Color.White;
            }
            else if (lightThemeCB.Checked)
            {
                darkThemeCB.Checked = false; 
                BackColor = Color.White;
                ForeColor = Color.Black;
            }
        }

    }
}
