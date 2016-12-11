namespace PatternRecognition
{
    partial class AddPatternForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.putPatternBtn = new System.Windows.Forms.Button();
            this.patternNameTextBox = new System.Windows.Forms.TextBox();
            this.patternNameLabel = new System.Windows.Forms.Label();
            this.patternListBox = new System.Windows.Forms.ListBox();
            this.patternsLabel = new System.Windows.Forms.Label();
            this.removePatternBtn = new System.Windows.Forms.Button();
            this.savePatternsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // putPatternBtn
            // 
            this.putPatternBtn.Location = new System.Drawing.Point(161, 52);
            this.putPatternBtn.Name = "putPatternBtn";
            this.putPatternBtn.Size = new System.Drawing.Size(101, 23);
            this.putPatternBtn.TabIndex = 0;
            this.putPatternBtn.Text = "Put pattern";
            this.putPatternBtn.UseVisualStyleBackColor = true;
            this.putPatternBtn.Click += new System.EventHandler(this.PutPatternBtnClick);
            // 
            // patternNameTextBox
            // 
            this.patternNameTextBox.Location = new System.Drawing.Point(161, 26);
            this.patternNameTextBox.Name = "patternNameTextBox";
            this.patternNameTextBox.Size = new System.Drawing.Size(101, 20);
            this.patternNameTextBox.TabIndex = 1;
            // 
            // patternNameLabel
            // 
            this.patternNameLabel.Location = new System.Drawing.Point(161, 9);
            this.patternNameLabel.Name = "patternNameLabel";
            this.patternNameLabel.Size = new System.Drawing.Size(83, 14);
            this.patternNameLabel.TabIndex = 2;
            this.patternNameLabel.Text = "Pattern name:";
            // 
            // patternListBox
            // 
            this.patternListBox.FormattingEnabled = true;
            this.patternListBox.Location = new System.Drawing.Point(161, 105);
            this.patternListBox.Name = "patternListBox";
            this.patternListBox.Size = new System.Drawing.Size(147, 160);
            this.patternListBox.TabIndex = 3;
            this.patternListBox.SelectedIndexChanged += new System.EventHandler(this.PatternListBoxSelectedIndexChanged);
            // 
            // patternsLabel
            // 
            this.patternsLabel.Location = new System.Drawing.Point(161, 82);
            this.patternsLabel.Name = "patternsLabel";
            this.patternsLabel.Size = new System.Drawing.Size(100, 20);
            this.patternsLabel.TabIndex = 5;
            this.patternsLabel.Text = "Patterns:";
            // 
            // removePatternBtn
            // 
            this.removePatternBtn.Location = new System.Drawing.Point(161, 271);
            this.removePatternBtn.Name = "removePatternBtn";
            this.removePatternBtn.Size = new System.Drawing.Size(55, 22);
            this.removePatternBtn.TabIndex = 6;
            this.removePatternBtn.Text = "Remove";
            this.removePatternBtn.UseVisualStyleBackColor = true;
            this.removePatternBtn.Click += new System.EventHandler(this.RemovePatternBtnClick);
            // 
            // savePatternsBtn
            // 
            this.savePatternsBtn.Location = new System.Drawing.Point(226, 271);
            this.savePatternsBtn.Name = "savePatternsBtn";
            this.savePatternsBtn.Size = new System.Drawing.Size(81, 22);
            this.savePatternsBtn.TabIndex = 7;
            this.savePatternsBtn.Text = "Save patterns";
            this.savePatternsBtn.UseVisualStyleBackColor = true;
            this.savePatternsBtn.Click += new System.EventHandler(this.SavePatternsBtnClick);
            // 
            // AddPatternForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 302);
            this.Controls.Add(this.savePatternsBtn);
            this.Controls.Add(this.removePatternBtn);
            this.Controls.Add(this.patternsLabel);
            this.Controls.Add(this.patternListBox);
            this.Controls.Add(this.patternNameLabel);
            this.Controls.Add(this.patternNameTextBox);
            this.Controls.Add(this.putPatternBtn);
            this.Name = "AddPatternForm";
            this.Text = "Manage Patterns";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Button savePatternsBtn;
        private System.Windows.Forms.Button removePatternBtn;
        private System.Windows.Forms.Label patternsLabel;
        private System.Windows.Forms.ListBox patternListBox;
        private System.Windows.Forms.Label patternNameLabel;
        private System.Windows.Forms.TextBox patternNameTextBox;
        private System.Windows.Forms.Button putPatternBtn;
    }
}
