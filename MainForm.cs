using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using iTunesLib;

namespace Lyrics
{
	public partial class MainForm : Form
	{
		private Dictionary<string, List<TrackInformation>> artistsSongs = new Dictionary<string, List<TrackInformation>>();
		private string BaseUrlFormat = "http://letras.terra.com.br/{0}";
		private iTunesApp itunes;

		public MainForm()
		{
			InitializeComponent();
		}

		private void listITunesSongsButton_Click(object sender, EventArgs e)
		{
			artistsListBox.Items.Clear();

			itunes = new iTunesAppClass();
			IITTrackCollection selectedTracks = itunes.SelectedTracks;

			if (selectedTracks == null)
			{
				return;
			}

			OrganizeArtists(selectedTracks);
			foreach (string artist in artistsSongs.Keys)
			{
				artistsListBox.Items.Add(artist);
			}
		}

		private void OrganizeArtists(IITTrackCollection selectedTracks)
		{
			artistsSongs = new Dictionary<string, List<TrackInformation>>();
			List<string> songs = new List<string>();

			for (int i = 1; i <= selectedTracks.Count; i++)
			{
				IITFileOrCDTrack currentTrack = (IITFileOrCDTrack)selectedTracks[i];

				if (!artistsSongs.ContainsKey(currentTrack.Artist))
				{
					artistsSongs.Add(currentTrack.Artist, new List<TrackInformation>());
				}

				artistsSongs[currentTrack.Artist].Add(new TrackInformation() { 
					Track = currentTrack,
					Index = i
				});
			}
		}

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

		private List<OnlineSongInformation> ListOnlineSongs(string artistName)
		{
			List<OnlineSongInformation> songs = new List<OnlineSongInformation>();
			string result = GetUrlContents(String.Format(BaseUrlFormat, NormalizeName(artistName)));

			if (result != null && result.Contains("identificador_artista"))
			{
				Match m = Regex.Match(result, "<a class=\"elemsug\" href=\"(.*)\">(.*)</a>");

				while (m.Success)
				{
					songs.Add(new OnlineSongInformation() {
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

		private string NormalizeName(string name)
		{
			byte[] b = Encoding.GetEncoding(1251).GetBytes(name);
			name = Encoding.ASCII.GetString(b).ToLower();
			name = name.Replace(' ', '-')
				.Replace("'", "")
				.Replace('&', 'e')
				.Replace('/', '-');
			return name;
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
		}
	}

	class TrackInformation
	{
		public IITFileOrCDTrack Track { get; set; }
		public int Index { get; set; }

		public override string ToString()
		{
			return Track.Name.ToLower();
		}
	}

	class OnlineSongInformation
	{
		public string Name { get; set; }
		public string Path { get; set; }
	}
}
