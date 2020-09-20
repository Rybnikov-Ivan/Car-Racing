namespace MycarRacing
{
    partial class CarView
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
            this.tmrRacing = new System.Windows.Forms.Timer(this.components);
            this.Score_txt = new System.Windows.Forms.Label();
            this.High_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tmrRacing
            // 
            this.tmrRacing.Enabled = true;
            this.tmrRacing.Interval = 50;
            this.tmrRacing.Tick += new System.EventHandler(this.tmrRacing_Tick);
            // 
            // Score_txt
            // 
            this.Score_txt.AutoSize = true;
            this.Score_txt.Location = new System.Drawing.Point(350, 70);
            this.Score_txt.Name = "Score_txt";
            this.Score_txt.Size = new System.Drawing.Size(45, 17);
            this.Score_txt.TabIndex = 0;
            this.Score_txt.Text = "Score";
            // 
            // High_txt
            // 
            this.High_txt.AutoSize = true;
            this.High_txt.Location = new System.Drawing.Point(333, 107);
            this.High_txt.Name = "High_txt";
            this.High_txt.Size = new System.Drawing.Size(78, 17);
            this.High_txt.TabIndex = 2;
            this.High_txt.Text = "High Score";
            // 
            // CarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 615);
            this.Controls.Add(this.High_txt);
            this.Controls.Add(this.Score_txt);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CarView";
            this.Text = "Car Racing";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CarView_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CarView_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CarView_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrRacing;
        private System.Windows.Forms.Label Score_txt;
        private System.Windows.Forms.Label High_txt;
    }
}

