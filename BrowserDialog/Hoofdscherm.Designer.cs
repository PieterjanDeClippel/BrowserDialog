namespace BrowserDialog
{
	partial class Hoofdscherm
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
			if(disposing && (components != null))
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
			this.btnKiesBrowser = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnKiesBrowser
			// 
			this.btnKiesBrowser.Location = new System.Drawing.Point(12, 12);
			this.btnKiesBrowser.Name = "btnKiesBrowser";
			this.btnKiesBrowser.Size = new System.Drawing.Size(115, 25);
			this.btnKiesBrowser.TabIndex = 0;
			this.btnKiesBrowser.Text = "Kies een browser";
			this.btnKiesBrowser.UseVisualStyleBackColor = true;
			this.btnKiesBrowser.Click += new System.EventHandler(this.btnKiesBrowser_Click);
			// 
			// Hoofdscherm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btnKiesBrowser);
			this.Name = "Hoofdscherm";
			this.Text = "Hoofdscherm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnKiesBrowser;
	}
}