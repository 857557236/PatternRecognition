/*
 * Created by SharpDevelop.
 * User: Voldemar
 * Date: 23.02.2015
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PatternRecognition
{
	partial class MainForm
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
			this.managePatternsBtn = new System.Windows.Forms.Button();
			this.recognizeBtn = new System.Windows.Forms.Button();
			this.clearBtn = new System.Windows.Forms.Button();
			this.recognizedByOneLayerLabel = new System.Windows.Forms.Label();
			this.recognizedByOneLayerTextBox = new System.Windows.Forms.TextBox();
			this.teachBtn = new System.Windows.Forms.Button();
			this.patternsComboBox = new System.Windows.Forms.ComboBox();
			this.correctBtn = new System.Windows.Forms.Button();
			this.patternsLabel = new System.Windows.Forms.Label();
			this.showBtn = new System.Windows.Forms.Button();
			this.teachingSetSizeTextBox = new System.Windows.Forms.TextBox();
			this.teachingSetSizeLabel = new System.Windows.Forms.Label();
			this.recognizedByTwoLayerTextBox = new System.Windows.Forms.TextBox();
			this.recognizedByTwoLayerLabel = new System.Windows.Forms.Label();
			this.errorProbabilityTextBox = new System.Windows.Forms.TextBox();
			this.errorProbabilityLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// managePatternsBtn
			// 
			this.managePatternsBtn.Location = new System.Drawing.Point(179, 298);
			this.managePatternsBtn.Name = "managePatternsBtn";
			this.managePatternsBtn.Size = new System.Drawing.Size(94, 44);
			this.managePatternsBtn.TabIndex = 0;
			this.managePatternsBtn.Text = "Manage patterns";
			this.managePatternsBtn.UseVisualStyleBackColor = true;
			this.managePatternsBtn.Click += new System.EventHandler(this.ManagePatternsBtnClick);
			// 
			// recognizeBtn
			// 
			this.recognizeBtn.Location = new System.Drawing.Point(178, 12);
			this.recognizeBtn.Name = "recognizeBtn";
			this.recognizeBtn.Size = new System.Drawing.Size(94, 27);
			this.recognizeBtn.TabIndex = 1;
			this.recognizeBtn.Text = "Recognize";
			this.recognizeBtn.UseVisualStyleBackColor = true;
			this.recognizeBtn.Click += new System.EventHandler(this.RecognizeBtnClick);
			// 
			// clearBtn
			// 
			this.clearBtn.Location = new System.Drawing.Point(178, 45);
			this.clearBtn.Name = "clearBtn";
			this.clearBtn.Size = new System.Drawing.Size(93, 27);
			this.clearBtn.TabIndex = 2;
			this.clearBtn.Text = "Clear";
			this.clearBtn.UseVisualStyleBackColor = true;
			this.clearBtn.Click += new System.EventHandler(this.ClearBtnClick);
			// 
			// recognizedByOneLayerLabel
			// 
			this.recognizedByOneLayerLabel.Location = new System.Drawing.Point(12, 216);
			this.recognizedByOneLayerLabel.Name = "recognizedByOneLayerLabel";
			this.recognizedByOneLayerLabel.Size = new System.Drawing.Size(148, 17);
			this.recognizedByOneLayerLabel.TabIndex = 3;
			this.recognizedByOneLayerLabel.Text = "Recognized by one-layer net:";
			// 
			// recognizedByOneLayerTextBox
			// 
			this.recognizedByOneLayerTextBox.Location = new System.Drawing.Point(12, 236);
			this.recognizedByOneLayerTextBox.Name = "recognizedByOneLayerTextBox";
			this.recognizedByOneLayerTextBox.ReadOnly = true;
			this.recognizedByOneLayerTextBox.Size = new System.Drawing.Size(148, 20);
			this.recognizedByOneLayerTextBox.TabIndex = 4;
			// 
			// teachBtn
			// 
			this.teachBtn.Location = new System.Drawing.Point(179, 123);
			this.teachBtn.Name = "teachBtn";
			this.teachBtn.Size = new System.Drawing.Size(94, 27);
			this.teachBtn.TabIndex = 5;
			this.teachBtn.Text = "Teach";
			this.teachBtn.UseVisualStyleBackColor = true;
			this.teachBtn.Click += new System.EventHandler(this.TeachBtnClick);
			// 
			// patternsComboBox
			// 
			this.patternsComboBox.FormattingEnabled = true;
			this.patternsComboBox.Location = new System.Drawing.Point(179, 182);
			this.patternsComboBox.Name = "patternsComboBox";
			this.patternsComboBox.Size = new System.Drawing.Size(94, 21);
			this.patternsComboBox.TabIndex = 6;
			this.patternsComboBox.DropDown += new System.EventHandler(this.PatternsComboBoxDropDown);
			// 
			// correctBtn
			// 
			this.correctBtn.Location = new System.Drawing.Point(178, 209);
			this.correctBtn.Name = "correctBtn";
			this.correctBtn.Size = new System.Drawing.Size(95, 22);
			this.correctBtn.TabIndex = 7;
			this.correctBtn.Text = "Correct";
			this.correctBtn.UseVisualStyleBackColor = true;
			this.correctBtn.Click += new System.EventHandler(this.CorrectBtnClick);
			// 
			// patternsLabel
			// 
			this.patternsLabel.Location = new System.Drawing.Point(178, 167);
			this.patternsLabel.Name = "patternsLabel";
			this.patternsLabel.Size = new System.Drawing.Size(90, 12);
			this.patternsLabel.TabIndex = 8;
			this.patternsLabel.Text = "Patterns:";
			// 
			// showBtn
			// 
			this.showBtn.Location = new System.Drawing.Point(178, 232);
			this.showBtn.Name = "showBtn";
			this.showBtn.Size = new System.Drawing.Size(95, 22);
			this.showBtn.TabIndex = 9;
			this.showBtn.Text = "Show";
			this.showBtn.UseVisualStyleBackColor = true;
			this.showBtn.Click += new System.EventHandler(this.ShowBtnClick);
			// 
			// teachingSetSizeTextBox
			// 
			this.teachingSetSizeTextBox.Location = new System.Drawing.Point(179, 97);
			this.teachingSetSizeTextBox.Name = "teachingSetSizeTextBox";
			this.teachingSetSizeTextBox.Size = new System.Drawing.Size(93, 20);
			this.teachingSetSizeTextBox.TabIndex = 11;
			this.teachingSetSizeTextBox.Text = "100";
			// 
			// teachingSetSizeLabel
			// 
			this.teachingSetSizeLabel.Location = new System.Drawing.Point(179, 79);
			this.teachingSetSizeLabel.Name = "teachingSetSizeLabel";
			this.teachingSetSizeLabel.Size = new System.Drawing.Size(94, 15);
			this.teachingSetSizeLabel.TabIndex = 12;
			this.teachingSetSizeLabel.Text = "Teaching set size:";
			// 
			// recognizedByTwoLayerTextBox
			// 
			this.recognizedByTwoLayerTextBox.Location = new System.Drawing.Point(12, 279);
			this.recognizedByTwoLayerTextBox.Name = "recognizedByTwoLayerTextBox";
			this.recognizedByTwoLayerTextBox.ReadOnly = true;
			this.recognizedByTwoLayerTextBox.Size = new System.Drawing.Size(148, 20);
			this.recognizedByTwoLayerTextBox.TabIndex = 14;
			// 
			// recognizedByTwoLayerLabel
			// 
			this.recognizedByTwoLayerLabel.Location = new System.Drawing.Point(12, 259);
			this.recognizedByTwoLayerLabel.Name = "recognizedByTwoLayerLabel";
			this.recognizedByTwoLayerLabel.Size = new System.Drawing.Size(148, 17);
			this.recognizedByTwoLayerLabel.TabIndex = 13;
			this.recognizedByTwoLayerLabel.Text = "Recognized by two-layer net:";
			// 
			// errorProbabilityTextBox
			// 
			this.errorProbabilityTextBox.Location = new System.Drawing.Point(12, 322);
			this.errorProbabilityTextBox.Name = "errorProbabilityTextBox";
			this.errorProbabilityTextBox.ReadOnly = true;
			this.errorProbabilityTextBox.Size = new System.Drawing.Size(148, 20);
			this.errorProbabilityTextBox.TabIndex = 16;
			// 
			// errorProbabilityLabel
			// 
			this.errorProbabilityLabel.Location = new System.Drawing.Point(12, 302);
			this.errorProbabilityLabel.Name = "errorProbabilityLabel";
			this.errorProbabilityLabel.Size = new System.Drawing.Size(161, 17);
			this.errorProbabilityLabel.TabIndex = 15;
			this.errorProbabilityLabel.Text = "Error probability on teaching set:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 349);
			this.Controls.Add(this.errorProbabilityTextBox);
			this.Controls.Add(this.errorProbabilityLabel);
			this.Controls.Add(this.recognizedByTwoLayerTextBox);
			this.Controls.Add(this.recognizedByTwoLayerLabel);
			this.Controls.Add(this.teachingSetSizeLabel);
			this.Controls.Add(this.teachingSetSizeTextBox);
			this.Controls.Add(this.showBtn);
			this.Controls.Add(this.patternsLabel);
			this.Controls.Add(this.correctBtn);
			this.Controls.Add(this.patternsComboBox);
			this.Controls.Add(this.teachBtn);
			this.Controls.Add(this.recognizedByOneLayerTextBox);
			this.Controls.Add(this.recognizedByOneLayerLabel);
			this.Controls.Add(this.clearBtn);
			this.Controls.Add(this.recognizeBtn);
			this.Controls.Add(this.managePatternsBtn);
			this.Name = "MainForm";
			this.Text = "Pattern Recognition";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label errorProbabilityLabel;
		private System.Windows.Forms.TextBox errorProbabilityTextBox;
		private System.Windows.Forms.Label recognizedByTwoLayerLabel;
		private System.Windows.Forms.TextBox recognizedByTwoLayerTextBox;
		private System.Windows.Forms.Label teachingSetSizeLabel;
		private System.Windows.Forms.TextBox teachingSetSizeTextBox;
		private System.Windows.Forms.Button showBtn;
		private System.Windows.Forms.Label patternsLabel;
		private System.Windows.Forms.Button correctBtn;
		private System.Windows.Forms.ComboBox patternsComboBox;
		private System.Windows.Forms.Button teachBtn;
		private System.Windows.Forms.TextBox recognizedByOneLayerTextBox;
		private System.Windows.Forms.Label recognizedByOneLayerLabel;
		private System.Windows.Forms.Button clearBtn;
		private System.Windows.Forms.Button recognizeBtn;
		private System.Windows.Forms.Button managePatternsBtn;
	}
}
