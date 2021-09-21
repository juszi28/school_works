namespace Project
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.NévTB = new System.Windows.Forms.TextBox();
            this.Poszt_CB = new System.Windows.Forms.ComboBox();
            this.Kor_TB = new System.Windows.Forms.TextBox();
            this.NévLab = new System.Windows.Forms.Label();
            this.PosztLab = new System.Windows.Forms.Label();
            this.KorLab = new System.Windows.Forms.Label();
            this.Nemzet_TB = new System.Windows.Forms.TextBox();
            this.NemzetLab = new System.Windows.Forms.Label();
            this.Add_B = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // NévTB
            // 
            this.NévTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NévTB.Location = new System.Drawing.Point(3, 4);
            this.NévTB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NévTB.Name = "NévTB";
            this.NévTB.Size = new System.Drawing.Size(340, 26);
            this.NévTB.TabIndex = 0;
            // 
            // Poszt_CB
            // 
            this.Poszt_CB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Poszt_CB.FormattingEnabled = true;
            this.Poszt_CB.Location = new System.Drawing.Point(3, 32);
            this.Poszt_CB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Poszt_CB.Name = "Poszt_CB";
            this.Poszt_CB.Size = new System.Drawing.Size(340, 26);
            this.Poszt_CB.TabIndex = 2;
            // 
            // Kor_TB
            // 
            this.Kor_TB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Kor_TB.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.Kor_TB.Location = new System.Drawing.Point(3, 60);
            this.Kor_TB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Kor_TB.Name = "Kor_TB";
            this.Kor_TB.Size = new System.Drawing.Size(41, 30);
            this.Kor_TB.TabIndex = 3;
            // 
            // NévLab
            // 
            this.NévLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NévLab.AutoSize = true;
            this.NévLab.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.NévLab.Location = new System.Drawing.Point(102, 5);
            this.NévLab.Name = "NévLab";
            this.NévLab.Size = new System.Drawing.Size(35, 18);
            this.NévLab.TabIndex = 4;
            this.NévLab.Text = "Név:";
            this.NévLab.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PosztLab
            // 
            this.PosztLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PosztLab.AutoSize = true;
            this.PosztLab.Location = new System.Drawing.Point(93, 33);
            this.PosztLab.Name = "PosztLab";
            this.PosztLab.Size = new System.Drawing.Size(44, 18);
            this.PosztLab.TabIndex = 6;
            this.PosztLab.Text = "Poszt:";
            this.PosztLab.UseMnemonic = false;
            // 
            // KorLab
            // 
            this.KorLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.KorLab.AutoSize = true;
            this.KorLab.Location = new System.Drawing.Point(104, 61);
            this.KorLab.Name = "KorLab";
            this.KorLab.Size = new System.Drawing.Size(33, 18);
            this.KorLab.TabIndex = 7;
            this.KorLab.Text = "Kor:";
            // 
            // Nemzet_TB
            // 
            this.Nemzet_TB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Nemzet_TB.Location = new System.Drawing.Point(3, 88);
            this.Nemzet_TB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Nemzet_TB.Name = "Nemzet_TB";
            this.Nemzet_TB.Size = new System.Drawing.Size(340, 26);
            this.Nemzet_TB.TabIndex = 8;
            // 
            // NemzetLab
            // 
            this.NemzetLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NemzetLab.AutoSize = true;
            this.NemzetLab.Location = new System.Drawing.Point(56, 90);
            this.NemzetLab.Name = "NemzetLab";
            this.NemzetLab.Size = new System.Drawing.Size(81, 18);
            this.NemzetLab.TabIndex = 9;
            this.NemzetLab.Text = "Nemzetiség:";
            // 
            // Add_B
            // 
            this.Add_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Add_B.Location = new System.Drawing.Point(3, 3);
            this.Add_B.Name = "Add_B";
            this.Add_B.Size = new System.Drawing.Size(93, 70);
            this.Add_B.TabIndex = 10;
            this.Add_B.Text = "Hozzáad";
            this.Add_B.UseVisualStyleBackColor = true;
            this.Add_B.Click += new System.EventHandler(this.Add_B_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.64856F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.35144F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.78986F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.21014F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 211);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.NévLab, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PosztLab, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.KorLab, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.NemzetLab, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(140, 115);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.NévTB, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Poszt_CB, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.Nemzet_TB, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Kor_TB, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(149, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(592, 115);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Controls.Add(this.Add_B, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(642, 124);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(99, 76);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.Text = "Játékos hozzáadás";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NévTB;
        private System.Windows.Forms.ComboBox Poszt_CB;
        private System.Windows.Forms.TextBox Kor_TB;
        private System.Windows.Forms.Label NévLab;
        private System.Windows.Forms.Label PosztLab;
        private System.Windows.Forms.Label KorLab;
        private System.Windows.Forms.TextBox Nemzet_TB;
        private System.Windows.Forms.Label NemzetLab;
        private System.Windows.Forms.Button Add_B;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}