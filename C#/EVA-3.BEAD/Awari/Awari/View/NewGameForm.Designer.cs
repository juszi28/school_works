namespace Awari.View
{
    partial class NewGameForm
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
            this.binLabel = new System.Windows.Forms.Label();
            this.binComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // binLabel
            // 
            this.binLabel.AutoSize = true;
            this.binLabel.Location = new System.Drawing.Point(13, 13);
            this.binLabel.Name = "binLabel";
            this.binLabel.Size = new System.Drawing.Size(93, 15);
            this.binLabel.TabIndex = 0;
            this.binLabel.Text = "Number of bins:";
            // 
            // binComboBox
            // 
            this.binComboBox.FormattingEnabled = true;
            this.binComboBox.Items.AddRange(new object[] {
            "4",
            "8",
            "12"});
            this.binComboBox.Location = new System.Drawing.Point(146, 10);
            this.binComboBox.Name = "binComboBox";
            this.binComboBox.Size = new System.Drawing.Size(121, 23);
            this.binComboBox.TabIndex = 1;
            this.binComboBox.Text = "4";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(31, 56);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(146, 55);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 91);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.binComboBox);
            this.Controls.Add(this.binLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewGameForm";
            this.Text = "NewGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label binLabel;
        private System.Windows.Forms.ComboBox binComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}