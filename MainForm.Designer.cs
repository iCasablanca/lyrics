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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            resources.ApplyResources(this.grid, "grid");
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artist,
            this.song,
            this.status});
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.toolTip1.SetToolTip(this.grid, resources.GetString("grid.ToolTip"));
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // artist
            // 
            this.artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.artist.DataPropertyName = "Artist";
            resources.ApplyResources(this.artist, "artist");
            this.artist.Name = "artist";
            this.artist.ReadOnly = true;
            // 
            // song
            // 
            this.song.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.song.DataPropertyName = "Name";
            resources.ApplyResources(this.song, "song");
            this.song.Name = "song";
            this.song.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // searchLyricsButton
            // 
            resources.ApplyResources(this.searchLyricsButton, "searchLyricsButton");
            this.searchLyricsButton.Name = "searchLyricsButton";
            this.toolTip1.SetToolTip(this.searchLyricsButton, resources.GetString("searchLyricsButton.ToolTip"));
            this.searchLyricsButton.UseVisualStyleBackColor = true;
            this.searchLyricsButton.Click += new System.EventHandler(this.searchLyricsButton_Click);
            // 
            // synITunes
            // 
            resources.ApplyResources(this.synITunes, "synITunes");
            this.synITunes.Name = "synITunes";
            this.toolTip1.SetToolTip(this.synITunes, resources.GetString("synITunes.ToolTip"));
            this.synITunes.UseVisualStyleBackColor = true;
            this.synITunes.Click += new System.EventHandler(this.listITunesSongsButton_Click);
            // 
            // showOnlyMissingLyrics
            // 
            resources.ApplyResources(this.showOnlyMissingLyrics, "showOnlyMissingLyrics");
            this.showOnlyMissingLyrics.Checked = true;
            this.showOnlyMissingLyrics.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showOnlyMissingLyrics.Name = "showOnlyMissingLyrics";
            this.toolTip1.SetToolTip(this.showOnlyMissingLyrics, resources.GetString("showOnlyMissingLyrics.ToolTip"));
            this.showOnlyMissingLyrics.UseVisualStyleBackColor = true;
            this.showOnlyMissingLyrics.CheckedChanged += new System.EventHandler(this.showOnlyMissingLyrics_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // artistUrl
            // 
            resources.ApplyResources(this.artistUrl, "artistUrl");
            this.artistUrl.Name = "artistUrl";
            this.toolTip1.SetToolTip(this.artistUrl, resources.GetString("artistUrl.ToolTip"));
            this.artistUrl.Leave += new System.EventHandler(this.artistUrl_Leave);
            // 
            // log
            // 
            resources.ApplyResources(this.log, "log");
            this.log.FormattingEnabled = true;
            this.log.Name = "log";
            this.toolTip1.SetToolTip(this.log, resources.GetString("log.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // statusLabel
            // 
            resources.ApplyResources(this.statusLabel, "statusLabel");
            this.statusLabel.Name = "statusLabel";
            this.toolTip1.SetToolTip(this.statusLabel, resources.GetString("statusLabel.ToolTip"));
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.DataGridView grid;
		private System.Windows.Forms.Button searchLyricsButton;
		private System.Windows.Forms.Button synITunes;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox showOnlyMissingLyrics;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox artistUrl;
		private System.Windows.Forms.ListBox log;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn song;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}

