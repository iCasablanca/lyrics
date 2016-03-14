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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.grid = new System.Windows.Forms.DataGridView();
			this.artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.song = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.searchLyricsButton = new System.Windows.Forms.Button();
			this.synITunes = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.showOnlyMissingLyrics = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.artistUrl = new System.Windows.Forms.TextBox();
			this.log = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.AllowUserToAddRows = false;
			this.grid.AllowUserToDeleteRows = false;
			this.grid.AllowUserToResizeRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artist,
            this.song,
            this.status});
			this.grid.Location = new System.Drawing.Point(12, 12);
			this.grid.MultiSelect = false;
			this.grid.Name = "grid";
			this.grid.ReadOnly = true;
			this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid.Size = new System.Drawing.Size(580, 340);
			this.grid.TabIndex = 8;
			this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
			// 
			// artist
			// 
			this.artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.artist.DataPropertyName = "Artist";
			this.artist.HeaderText = "Artista";
			this.artist.Name = "artist";
			this.artist.ReadOnly = true;
			// 
			// song
			// 
			this.song.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.song.DataPropertyName = "Name";
			this.song.HeaderText = "Música";
			this.song.Name = "song";
			this.song.ReadOnly = true;
			// 
			// status
			// 
			this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.status.HeaderText = "Status";
			this.status.Name = "status";
			this.status.ReadOnly = true;
			// 
			// searchLyricsButton
			// 
			this.searchLyricsButton.Location = new System.Drawing.Point(145, 476);
			this.searchLyricsButton.Name = "searchLyricsButton";
			this.searchLyricsButton.Size = new System.Drawing.Size(97, 23);
			this.searchLyricsButton.TabIndex = 2;
			this.searchLyricsButton.Text = "Procurar letras";
			this.searchLyricsButton.UseVisualStyleBackColor = true;
			this.searchLyricsButton.Click += new System.EventHandler(this.searchLyricsButton_Click);
			// 
			// synITunes
			// 
			this.synITunes.Location = new System.Drawing.Point(13, 476);
			this.synITunes.Name = "synITunes";
			this.synITunes.Size = new System.Drawing.Size(126, 23);
			this.synITunes.TabIndex = 1;
			this.synITunes.Text = "Sync iTunes";
			this.synITunes.UseVisualStyleBackColor = true;
			this.synITunes.Click += new System.EventHandler(this.listITunesSongsButton_Click);
			// 
			// showOnlyMissingLyrics
			// 
			this.showOnlyMissingLyrics.AutoSize = true;
			this.showOnlyMissingLyrics.Checked = true;
			this.showOnlyMissingLyrics.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showOnlyMissingLyrics.Location = new System.Drawing.Point(12, 505);
			this.showOnlyMissingLyrics.Name = "showOnlyMissingLyrics";
			this.showOnlyMissingLyrics.Size = new System.Drawing.Size(190, 17);
			this.showOnlyMissingLyrics.TabIndex = 9;
			this.showOnlyMissingLyrics.Text = "Mostrar apenas músicas sem letras";
			this.showOnlyMissingLyrics.UseVisualStyleBackColor = true;
			this.showOnlyMissingLyrics.CheckedChanged += new System.EventHandler(this.showOnlyMissingLyrics_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 361);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "URL:";
			// 
			// artistUrl
			// 
			this.artistUrl.Location = new System.Drawing.Point(50, 358);
			this.artistUrl.Name = "artistUrl";
			this.artistUrl.Size = new System.Drawing.Size(542, 20);
			this.artistUrl.TabIndex = 11;
			this.artistUrl.Leave += new System.EventHandler(this.artistUrl_Leave);
			// 
			// log
			// 
			this.log.FormattingEnabled = true;
			this.log.HorizontalScrollbar = true;
			this.log.Location = new System.Drawing.Point(598, 12);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(497, 524);
			this.log.TabIndex = 12;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 397);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Status: ";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(61, 397);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(41, 13);
			this.statusLabel.TabIndex = 14;
			this.statusLabel.Text = "Parado";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1107, 549);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.log);
			this.Controls.Add(this.artistUrl);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.showOnlyMissingLyrics);
			this.Controls.Add(this.synITunes);
			this.Controls.Add(this.searchLyricsButton);
			this.Controls.Add(this.grid);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sincronizador de letras / iTunes + letras.terra.com.br";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.DataGridViewTextBoxColumn artist;
		private System.Windows.Forms.DataGridViewTextBoxColumn song;
		private System.Windows.Forms.DataGridViewTextBoxColumn status;
		private System.Windows.Forms.Button searchLyricsButton;
		private System.Windows.Forms.Button synITunes;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox showOnlyMissingLyrics;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox artistUrl;
		private System.Windows.Forms.ListBox log;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label statusLabel;
	}
}

