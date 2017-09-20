using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotNetSummitMobileApp.Models
{
	public class Speaker
	{
		[JsonProperty("photo")]
		public string Photo { get; set; }

		[JsonProperty("fullName")]
		public string FullName { get; set; }

		[JsonProperty("position")]
		public string Position { get; set; }

		[JsonProperty("bio")]
		public string Bio { get; set; }
	}

	public class Track
	{
		[JsonProperty("trackId")]
		public string TrackId { get; set; }

		[JsonProperty("time")]
		public DateTime Time { get; set; }

		[JsonProperty("fullName")]
		public string FullName { get; set; }

		[JsonProperty("topic")]
		public string Topic { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }
	}

	public class Conference
	{
		[JsonProperty("speakers")]
		public List<Speaker> Speakers { get; set; }

		[JsonProperty("program")]
		public List<Track> Tracks { get; set; }
	}
}
