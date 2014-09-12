namespace ConsoleApplication3
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
			this.label2 = new System.Windows.Forms.Label();
			this.RunButton = new System.Windows.Forms.Button();
			this.websiteTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.StatusLabel = new System.Windows.Forms.Label();
			this.fileExtTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Website";
			// 
			// RunButton
			// 
			this.RunButton.Location = new System.Drawing.Point(336, 97);
			this.RunButton.Name = "RunButton";
			this.RunButton.Size = new System.Drawing.Size(75, 23);
			this.RunButton.TabIndex = 2;
			this.RunButton.Text = "Start";
			this.RunButton.UseVisualStyleBackColor = true;
			this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
			// 
			// websiteTextBox
			// 
			this.websiteTextBox.Location = new System.Drawing.Point(90, 64);
			this.websiteTextBox.Name = "websiteTextBox";
			this.websiteTextBox.Size = new System.Drawing.Size(321, 20);
			this.websiteTextBox.TabIndex = 4;
			this.websiteTextBox.Text = "http://www.talktomeinkorean.com/curriculum/";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "File Extension";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = true;
			this.StatusLabel.Location = new System.Drawing.Point(12, 102);
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 13);
			this.StatusLabel.TabIndex = 6;
			// 
			// fileExtTextBox
			// 
			this.fileExtTextBox.Location = new System.Drawing.Point(90, 38);
			this.fileExtTextBox.Name = "fileExtTextBox";
			this.fileExtTextBox.Size = new System.Drawing.Size(240, 20);
			this.fileExtTextBox.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(336, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Default";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 141);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.StatusLabel);
			this.Controls.Add(this.websiteTextBox);
			this.Controls.Add(this.fileExtTextBox);
			this.Controls.Add(this.RunButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TTMIK Helper";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button RunButton;
		private System.Windows.Forms.TextBox websiteTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.TextBox fileExtTextBox;
		private System.Windows.Forms.Button button1;
	}
}