namespace Lyrics
{
	partial class MainForm
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
			this.listITunesSongsButton = new System.Windows.Forms.Button();
			this.searchLyricsButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.artistsListBox = new System.Windows.Forms.ListBox();
			this.songsListBox = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// listITunesSongsButton
			// 
			this.listITunesSongsButton.Location = new System.Drawing.Point(12, 289);
			this.listITunesSongsButton.Name = "listITunesSongsButton";
			this.listITunesSongsButton.Size = new System.Drawing.Size(126, 23);
			this.listITunesSongsButton.TabIndex = 1;
			this.listITunesSongsButton.Text = "Listar músicas (itunes)";
			this.listITunesSongsButton.UseVisualStyleBackColor = true;
			this.listITunesSongsButton.Click += new System.EventHandler(this.listITunesSongsButton_Click);
			// 
			// searchLyricsButton
			// 
			this.searchLyricsButton.Location = new System.Drawing.Point(144, 289);
			this.searchLyricsButton.Name = "searchLyricsButton";
			this.searchLyricsButton.Size = new System.Drawing.Size(97, 23);
			this.searchLyricsButton.TabIndex = 2;
			this.searchLyricsButton.Text = "Procurar letras";
			this.searchLyricsButton.UseVisualStyleBackColor = true;
			this.searchLyricsButton.Click += new System.EventHandler(this.searchLyricsButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Artistas";
			// 
			// artistsListBox
			// 
			this.artistsListBox.FormattingEnabled = true;
			this.artistsListBox.Location = new System.Drawing.Point(12, 25);
			this.artistsListBox.Name = "artistsListBox";
			this.artistsListBox.Size = new System.Drawing.Size(165, 238);
			this.artistsListBox.TabIndex = 4;
			this.artistsListBox.SelectedValueChanged += new System.EventHandler(this.artistsListBox_SelectedValueChanged);
			// 
			// songsListBox
			// 
			this.songsListBox.DisplayMember = "Name";
			this.songsListBox.FormattingEnabled = true;
			this.songsListBox.Location = new System.Drawing.Point(183, 25);
			this.songsListBox.Name = "songsListBox";
			this.songsListBox.Size = new System.Drawing.Size(252, 238);
			this.songsListBox.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 270);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Status: ";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(67, 269);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(40, 13);
			this.statusLabel.TabIndex = 7;
			this.statusLabel.Text = "parado";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 324);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.songsListBox);
			this.Controls.Add(this.artistsListBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.searchLyricsButton);
			this.Controls.Add(this.listITunesSongsButton);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button listITunesSongsButton;
		private System.Windows.Forms.Button searchLyricsButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox artistsListBox;
		private System.Windows.Forms.ListBox songsListBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label statusLabel;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
	}
}

