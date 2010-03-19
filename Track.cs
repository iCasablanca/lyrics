using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTunesLib;

namespace Lyrics
{
	public class Track
	{
		public Track(IITFileOrCDTrack itunesTrack)
		{
			this.ITunesTrack = itunesTrack;
		}

		public IITFileOrCDTrack ITunesTrack { get; set; }

		public string Name
		{
			get { return ITunesTrack.Name; }
		}

		public string Artist
		{
			get { return ITunesTrack.Artist; }
		}

		public string CustomArtistUrl { get; set; }
	}
}
