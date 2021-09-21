namespace projekt
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
            this.main = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pontszám = new System.Windows.Forms.Label();
            this.játékidő = new System.Windows.Forms.Timer(this.components);
            this.végüzenet = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.highscore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.main)).BeginInit();
            this.SuspendLayout();
            // 
            // main
            // 
            this.main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(91)))), ((int)(((byte)(232)))));
            this.main.Location = new System.Drawing.Point(27, 12);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(500, 530);
            this.main.TabIndex = 0;
            this.main.TabStop = false;
            this.main.Paint += new System.Windows.Forms.PaintEventHandler(this.main_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(535, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pontszám:";
            // 
            // Pontszám
            // 
            this.Pontszám.AutoSize = true;
            this.Pontszám.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Pontszám.Location = new System.Drawing.Point(772, 12);
            this.Pontszám.Name = "Pontszám";
            this.Pontszám.Size = new System.Drawing.Size(0, 29);
            this.Pontszám.TabIndex = 2;
            // 
            // végüzenet
            // 
            this.végüzenet.AutoSize = true;
            this.végüzenet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(91)))), ((int)(((byte)(232)))));
            this.végüzenet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.végüzenet.Location = new System.Drawing.Point(36, 62);
            this.végüzenet.Name = "végüzenet";
            this.végüzenet.Size = new System.Drawing.Size(60, 24);
            this.végüzenet.TabIndex = 3;
            this.végüzenet.Text = "label2";
            this.végüzenet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(533, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Legnagyobb pontszám:";
            // 
            // highscore
            // 
            this.highscore.AutoSize = true;
            this.highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.highscore.Location = new System.Drawing.Point(801, 130);
            this.highscore.Name = "highscore";
            this.highscore.Size = new System.Drawing.Size(0, 29);
            this.highscore.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(864, 581);
            this.Controls.Add(this.highscore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.végüzenet);
            this.Controls.Add(this.main);
            this.Controls.Add(this.Pontszám);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(880, 620);
            this.MinimumSize = new System.Drawing.Size(880, 620);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Pontszám;
        private System.Windows.Forms.Timer játékidő;
        private System.Windows.Forms.Label végüzenet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label highscore;
    }
}

