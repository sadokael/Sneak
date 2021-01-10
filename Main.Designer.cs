namespace Sneak
{
    partial class SneakGame
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
            this.PB_Canvas = new System.Windows.Forms.PictureBox();
            this.TXT_Score = new System.Windows.Forms.Label();
            this.L_score = new System.Windows.Forms.Label();
            this.EndGame = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Canvas
            // 
            this.PB_Canvas.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PB_Canvas.Location = new System.Drawing.Point(13, 13);
            this.PB_Canvas.Name = "PB_Canvas";
            this.PB_Canvas.Size = new System.Drawing.Size(540, 560);
            this.PB_Canvas.TabIndex = 0;
            this.PB_Canvas.TabStop = false;
            this.PB_Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGramphics);
            // 
            // TXT_Score
            // 
            this.TXT_Score.AutoSize = true;
            this.TXT_Score.Location = new System.Drawing.Point(617, 53);
            this.TXT_Score.Name = "TXT_Score";
            this.TXT_Score.Size = new System.Drawing.Size(38, 13);
            this.TXT_Score.TabIndex = 1;
            this.TXT_Score.Text = "Score:";
            // 
            // L_score
            // 
            this.L_score.AutoSize = true;
            this.L_score.Location = new System.Drawing.Point(670, 53);
            this.L_score.Name = "L_score";
            this.L_score.Size = new System.Drawing.Size(19, 13);
            this.L_score.TabIndex = 2;
            this.L_score.Text = "00";
            // 
            // EndGame
            // 
            this.EndGame.AutoSize = true;
            this.EndGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndGame.Location = new System.Drawing.Point(241, 245);
            this.EndGame.Name = "EndGame";
            this.EndGame.Size = new System.Drawing.Size(56, 13);
            this.EndGame.TabIndex = 3;
            this.EndGame.Text = "tempEnd";
            this.EndGame.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.updateGame);
            // 
            // SneakGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 631);
            this.Controls.Add(this.EndGame);
            this.Controls.Add(this.L_score);
            this.Controls.Add(this.TXT_Score);
            this.Controls.Add(this.PB_Canvas);
            this.Name = "SneakGame";
            this.Text = "SneakGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Canvas;
        private System.Windows.Forms.Label TXT_Score;
        private System.Windows.Forms.Label L_score;
        private System.Windows.Forms.Label EndGame;
        private System.Windows.Forms.Timer timer1;
    }
}

