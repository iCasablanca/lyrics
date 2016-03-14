namespace Lyrics
{
    using iTunesLib;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class MainForm : Form
	{
		private Dictionary<string, List<Track>> artistsTracks = new Dictionary<string, List<Track>>();
		private string BaseUrlFormat = "http://letras.terra.com.br/{0}";
		private iTunesApp itunes = new iTunesAppClass();
		private int processedArtists;

		public MainForm()
		{
			InitializeComponent();
			grid.AutoGenerateColumns = false;
		}

		private void listITunesSongsButton_Click(object sender, EventArgs e)
		{
			ListSongsFromITunes();
		}

		private void ListSongsFromITunes()
		{
			List<Track> tracks = new List<Track>();

			foreach (IITFileOrCDTrack currentTrack in itunes.LibraryPlaylist.Tracks)
			{
				if (!String.IsNullOrEmpty(currentTrack.Location)
					&& (!showOnlyMissingLyrics.Checked || String.IsNullOrEmpty(currentTrack.Lyrics)))
				{
					tracks.Add(new Track(currentTrack));
				}
			}

			grid.DataSource = tracks;
		}

		private void showOnlyMissingLyrics_CheckedChanged(object sender, EventArgs e)
		{
			ListSongsFromITunes();
		}

		private void grid_SelectionChanged(object sender, EventArgs e)
		{
			if (grid.SelectedRows.Count == 1)
			{
				Track track = SelectedTrack;

				string url = String.IsNullOrEmpty(track.CustomArtistUrl)
					? String.Format(BaseUrlFormat, NormalizeName(track.Artist))
					: track.CustomArtistUrl;

				artistUrl.Text = url;
			}
		}

		private string NormalizeName(string name)
		{
            if (string.IsNullOrEmpty(name) == false)
            {
                byte[] b = Encoding.GetEncoding(1251).GetBytes(name);
                name = Encoding.ASCII.GetString(b).ToLower();
                name = name.Replace(' ', '-')
                    .Replace("'", "")
                    .Replace('&', 'e')
                    .Replace('/', '-');
            }
			return name;
		}

		private Track SelectedTrack
		{
			get { return (Track)grid.SelectedRows[0].DataBoundItem; }
		}

		private void artistUrl_Leave(object sender, EventArgs e)
		{
			if (grid.SelectedRows.Count == 1)
			{
				Track track = SelectedTrack;
				track.CustomArtistUrl = artistUrl.Text;

				foreach (DataGridViewRow row in grid.Rows)
				{
					Track currentTrack = (Track)row.DataBoundItem;

					if (track != currentTrack && track.Artist == currentTrack.Artist)
					{
						currentTrack.CustomArtistUrl = track.CustomArtistUrl;
					}
				}
			}
		}

		private void searchLyricsButton_Click(object sender, EventArgs e)
		{
			OrganizeTracks();
			FetchLyrics();
		}

		private void FetchLyrics()
		{
			backgroundWorker = new BackgroundWorker();

			backgroundWorker.DoWork += (sender, e) => {
				foreach (string artist in artistsTracks.Keys)
				{
					UpdateStatus();
					processedArtists++;
				}

				UpdateStatus();
			};

			backgroundWorker.RunWorkerAsync();
		}

		private void OrganizeTracks()
		{
			artistsTracks = new Dictionary<string, List<Track>>();

			foreach (DataGridViewRow row in grid.Rows)
			{
				Track track = (Track)row.DataBoundItem;

                if (string.IsNullOrEmpty(track.Artist) == false)
                {
                    if (!artistsTracks.ContainsKey(track.Artist))
                    {
                        artistsTracks.Add(track.Artist, new List<Track>());
                    }

                    artistsTracks[track.Artist].Add(track);
                }
			}
		}

		private void UpdateStatus()
		{
			if (statusLabel.InvokeRequired)
			{
				statusLabel.Invoke(new Action(UpdateStatus));
			}
			else
			{
				statusLabel.Text = String.Format("Processado {0}/{1} artistas", artistsTracks.Count, processedArtists);
			}
		}

        private List<OnlineTrackInfo> ListOnlineSongs(string artistName)
		{
			List<OnlineTrackInfo> songs = new List<OnlineTrackInfo>();
			string result = GetUrlContents(String.Format(BaseUrlFormat, NormalizeName(artistName)));

			if (result != null && result.Contains("identificador_artista"))
			{
				Match m = Regex.Match(result, "<a class=\"elemsug\" href=\"(.*)\">(.*)</a>");

				while (m.Success)
				{
					songs.Add(new OnlineTrackInfo()
					{
						Path = m.Groups[1].Value,
						Name = m.Groups[2].Value.ToLower()
					});

					m = m.NextMatch();
				}
			}

			return songs;
		}

		private string GetUrlContents(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "GET";
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-1"));
			string result = reader.ReadToEnd();
			reader.Close();
			return result;
		}

		/*
		private void searchLyricsButton_Click(object sender, EventArgs e)
		{
			if (artistsListBox.SelectedIndex > -1)
			{
				backgroundWorker = new BackgroundWorker();

				backgroundWorker.DoWork += (bwSender, bwe) => {
					ChangeCurrentStatus("Procurando artista e relação de letras...");
					List<OnlineSongInformation> onlineSongs = ListOnlineSongs(SelectedArtist);

					if (onlineSongs.Count == 0)
					{
						MessageBox.Show(this, String.Format("Nenhum resultado encontrado (artista: '{0}')",
							NormalizeName(SelectedArtist)), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					foreach (OnlineSongInformation songInfo in onlineSongs)
					{
						IITFileOrCDTrack track = GetTrackFromListBox(songInfo.Name);

						if (track != null)
						{
							ChangeCurrentStatus("Procurando letra para " + songInfo.Name);
							string lyrics = GetSongLyrics(songInfo.Path);
							int index = songsListBox.Items.IndexOf(songInfo.Name);

							if (!String.IsNullOrEmpty(lyrics))
							{
								track.Lyrics = lyrics;
								ChangeCurrentStatus("Encontrado letra para " + songInfo.Name);
							}
							else
							{
								ChangeCurrentStatus("Não encontrada letra para " + songInfo.Name);
							}
						}
					}

					ChangeCurrentStatus("Finalizado");
				};

				backgroundWorker.RunWorkerAsync();
			}
		}

		private IITFileOrCDTrack GetTrackFromListBox(string onlineTrackName)
		{
			foreach (IITFileOrCDTrack track in songsListBox.Items)
			{
				if (track.Name.ToLower() == onlineTrackName)
				{
					return track;
				}
			}

			return null;
		}

		private void ChangeCurrentStatus(string status)
		{
			if (statusLabel.InvokeRequired)
			{
				statusLabel.Invoke(new Action<string>(ChangeCurrentStatus), status);
			}
			else
			{
				statusLabel.Text = status;
			}
		}

		private string SelectedArtist
		{
			get { return artistsListBox.SelectedItem.ToString(); }
		}

		private string GetSongLyrics(string path)
		{
			string lyrics = null;
			string result = GetUrlContents(String.Format(BaseUrlFormat, path));

			if (result != null && result.Contains("div_letra"))
			{
				string div = "<div id=\"div_letra\" >";
				int index = result.IndexOf(div);
				lyrics = result.Substring(index + div.Length, result.IndexOf("</div>", index) - (index + div.Length));
			}

			return lyrics;
		}

		private void artistsListBox_SelectedValueChanged(object sender, EventArgs e)
		{
			if (artistsListBox.SelectedIndex > -1)
			{
				songsListBox.Items.Clear();
				List<TrackInformation> songs = artistsSongs[SelectedArtist];

				foreach (TrackInformation info in songs)
				{
					songsListBox.Items.Add(info.Track);
				}
			}
		}*/
	}
}
