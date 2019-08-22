namespace BallGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.vertical = new System.Windows.Forms.Timer(this.components);
            this.horizontal = new System.Windows.Forms.Timer(this.components);
            this.ball = new System.Windows.Forms.PictureBox();
            this.slider = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.PictureBox();
            this.key_watch = new System.Windows.Forms.Timer(this.components);
            this.pblPause = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).BeginInit();
            this.pblPause.SuspendLayout();
            this.SuspendLayout();
            // 
            // vertical
            // 
            this.vertical.Enabled = true;
            this.vertical.Interval = 1;
            this.vertical.Tick += new System.EventHandler(this.Vert_Tick);
            // 
            // horizontal
            // 
            this.horizontal.Enabled = true;
            this.horizontal.Interval = 1;
            this.horizontal.Tick += new System.EventHandler(this.Horizontal_Tick);
            // 
            // ball
            // 
            this.ball.Image = ((System.Drawing.Image)(resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(12, 12);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(91, 98);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ball.TabIndex = 0;
            this.ball.TabStop = false;
            // 
            // slider
            // 
            this.slider.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.slider.BackColor = System.Drawing.Color.Lime;
            this.slider.Location = new System.Drawing.Point(324, 696);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(228, 14);
            this.slider.TabIndex = 1;
            this.slider.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(1102, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(43, 40);
            this.exitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitButton.TabIndex = 2;
            this.exitButton.TabStop = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // key_watch
            // 
            this.key_watch.Enabled = true;
            this.key_watch.Interval = 1;
            this.key_watch.Tick += new System.EventHandler(this.Key_watch_Tick);
            // 
            // pblPause
            // 
            this.pblPause.Controls.Add(this.label1);
            this.pblPause.Dock = System.Windows.Forms.DockStyle.Top;
            this.pblPause.Location = new System.Drawing.Point(0, 0);
            this.pblPause.Name = "pblPause";
            this.pblPause.Size = new System.Drawing.Size(1157, 178);
            this.pblPause.TabIndex = 3;
            this.pblPause.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1157, 178);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Paused";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1157, 722);
            this.Controls.Add(this.pblPause);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.ball);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitButton)).EndInit();
            this.pblPause.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox slider;
        private System.Windows.Forms.Timer vertical;
        private System.Windows.Forms.Timer horizontal;
        private System.Windows.Forms.PictureBox exitButton;
        private System.Windows.Forms.Timer key_watch;
        private System.Windows.Forms.Panel pblPause;
        private System.Windows.Forms.Label label1;
    }
}

