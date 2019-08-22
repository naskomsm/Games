namespace BallGame
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private const int ballSpeed = 5;
        private const int sliderSpeed = 10;

        private int verticalDir = 1;
        private int horizontalDir = 1;

        private bool left = false;
        private bool right = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Vert_Tick(object sender, EventArgs e)
        {
            if (ball.Top < 0)
            {
                verticalDir = 1;
            }

            else if (ball.Top > (this.Height - ball.Height - slider.Height))
            {
                verticalDir = -1;

                if(ball.Left < slider.Left || (ball.Left + ball.Width) > (slider.Left + slider.Width))
                {
                    vertical.Enabled = false;
                    horizontal.Enabled = false;

                    label1.BackColor = Color.DarkRed;
                    label1.Text = "Game over!";
                    pblPause.Visible = true;
                }
            }

            ball.Top += (verticalDir * ballSpeed);
        }

        private void Horizontal_Tick(object sender, EventArgs e)
        {
            if (ball.Left < 0)
            {
                horizontalDir = 1;
            }

            else if (ball.Left > (this.Width - ball.Width))
            {
                horizontalDir = -1;
            }

            ball.Left += (horizontalDir * ballSpeed);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            else if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            else if (e.KeyCode == Keys.Escape)
            {
                //pause game
                pblPause.Visible = true;
                vertical.Enabled = false;
                horizontal.Enabled = false;
            }

            else if (e.KeyCode == Keys.Enter)
            {
                //pause game
                label1.BackColor = Color.Black;
                label1.Text = "Game Paused";
                pblPause.Visible = false;
                vertical.Enabled = true;
                horizontal.Enabled = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                right = false;
                left = false; 
            }
        }

        private void Key_watch_Tick(object sender, EventArgs e)
        {
            if(right == true && slider.Left < (this.Width - slider.Width))
            {
                slider.Left += sliderSpeed;
            }

            else if (left == true && slider.Left > 0)
            {
                slider.Left -= sliderSpeed;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
