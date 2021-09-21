namespace Project
{
	partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.HCSL = new System.Windows.Forms.Label();
            this.VCSL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HazaiCSCB = new System.Windows.Forms.ComboBox();
            this.VendégCSCB = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TipusCB = new System.Windows.Forms.ComboBox();
            this.MeccsAddB = new System.Windows.Forms.Button();
            this.HazaiG = new System.Windows.Forms.NumericUpDown();
            this.VendégG = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.HazaiG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VendégG)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // HCSL
            // 
            this.HCSL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.HCSL.AutoSize = true;
            this.HCSL.Location = new System.Drawing.Point(20, 32);
            this.HCSL.Name = "HCSL";
            this.HCSL.Size = new System.Drawing.Size(86, 18);
            this.HCSL.TabIndex = 0;
            this.HCSL.Text = "Hazai csapat";
            // 
            // VCSL
            // 
            this.VCSL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.VCSL.AutoSize = true;
            this.VCSL.Location = new System.Drawing.Point(11, 115);
            this.VCSL.Name = "VCSL";
            this.VCSL.Size = new System.Drawing.Size(95, 18);
            this.VCSL.TabIndex = 1;
            this.VCSL.Text = "Vendég csapat";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dátum";
            // 
            // HazaiCSCB
            // 
            this.HazaiCSCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HazaiCSCB.FormattingEnabled = true;
            this.HazaiCSCB.Location = new System.Drawing.Point(3, 28);
            this.HazaiCSCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HazaiCSCB.Name = "HazaiCSCB";
            this.HazaiCSCB.Size = new System.Drawing.Size(333, 26);
            this.HazaiCSCB.TabIndex = 3;
            // 
            // VendégCSCB
            // 
            this.VendégCSCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VendégCSCB.FormattingEnabled = true;
            this.VendégCSCB.Location = new System.Drawing.Point(3, 111);
            this.VendégCSCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VendégCSCB.Name = "VendégCSCB";
            this.VendégCSCB.Size = new System.Drawing.Size(333, 26);
            this.VendégCSCB.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dateTimePicker1.Location = new System.Drawing.Point(3, 194);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(333, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hazai cs. gól";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Vendég cs. gól";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Típus";
            // 
            // TipusCB
            // 
            this.TipusCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TipusCB.FormattingEnabled = true;
            this.TipusCB.Location = new System.Drawing.Point(3, 278);
            this.TipusCB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TipusCB.Name = "TipusCB";
            this.TipusCB.Size = new System.Drawing.Size(333, 26);
            this.TipusCB.TabIndex = 11;
            // 
            // MeccsAddB
            // 
            this.MeccsAddB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MeccsAddB.Location = new System.Drawing.Point(640, 353);
            this.MeccsAddB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MeccsAddB.Name = "MeccsAddB";
            this.MeccsAddB.Size = new System.Drawing.Size(99, 32);
            this.MeccsAddB.TabIndex = 12;
            this.MeccsAddB.Text = "Hozzáad";
            this.MeccsAddB.UseVisualStyleBackColor = true;
            this.MeccsAddB.Click += new System.EventHandler(this.MeccsAddB_Click);
            // 
            // HazaiG
            // 
            this.HazaiG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HazaiG.Location = new System.Drawing.Point(3, 28);
            this.HazaiG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HazaiG.Name = "HazaiG";
            this.HazaiG.Size = new System.Drawing.Size(49, 26);
            this.HazaiG.TabIndex = 13;
            // 
            // VendégG
            // 
            this.VendégG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.VendégG.Location = new System.Drawing.Point(3, 111);
            this.VendégG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VendégG.Name = "VendégG";
            this.VendégG.Size = new System.Drawing.Size(49, 26);
            this.VendégG.TabIndex = 14;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MeccsAddB, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 399);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.HCSL, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.VCSL, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(109, 333);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.HazaiCSCB, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.VendégCSCB, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePicker1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TipusCB, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(118, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(339, 333);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(463, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(147, 333);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.HazaiG, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.VendégG, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(616, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(148, 333);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 399);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form3";
            this.Text = "Meccs hozzáadása";
            ((System.ComponentModel.ISupportInitialize)(this.HazaiG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VendégG)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label HCSL;
		private System.Windows.Forms.Label VCSL;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox HazaiCSCB;
		private System.Windows.Forms.ComboBox VendégCSCB;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox TipusCB;
		private System.Windows.Forms.Button MeccsAddB;
		private System.Windows.Forms.NumericUpDown HazaiG;
		private System.Windows.Forms.NumericUpDown VendégG;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
	}
}