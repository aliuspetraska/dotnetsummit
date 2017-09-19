using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using DotNetSummitWebApi.Models;

namespace DotNetSummitWebApi.Services
{
	public class DataService : IDataService
	{
		public DataService()
		{
		}

		private static string Url = @"https://dotnetsummit.by";

		public async Task<Conference> GetData()
		{
			var htmlDocument = await BrowsingContext.New(Configuration.Default.WithDefaultLoader()).OpenAsync(Url);

			var speakerElements = htmlDocument.QuerySelectorAll("div.speakers ul li");

			var speakers = new List<Speaker>();

			foreach (var speakerElement in speakerElements)
			{
				speakers.Add(new Speaker
				{
					Photo = string.Concat(Url, speakerElement.QuerySelector("div.speakerphotoandname img").GetAttribute("src").Trim()),
					FullName = speakerElement.QuerySelector("div.speakername .full-name").TextContent.Trim(),
					Position = speakerElement.QuerySelector("div.speakername .position").TextContent.Trim(),
					Bio = speakerElement.QuerySelector("p").TextContent.Trim()
				});
			}

			var program = new List<Track>();

			program = AddProgramItems(program, htmlDocument.QuerySelectorAll("div.program ul.track1 li"), "Track 1");
			program = AddProgramItems(program, htmlDocument.QuerySelectorAll("div.program ul.track2 li"), "Track 2");

			return new Conference
			{
				Speakers = speakers,
				Tracks = program.OrderBy(o => o.Time).ToList()
			};
		}

		private static List<Track> AddProgramItems(
			List<Track> program, AngleSharp.Dom.IHtmlCollection<AngleSharp.Dom.IElement> trackElements, string trackId)
		{
			foreach (var trackElement in trackElements)
			{
				var topic = trackElement.QuerySelector("h3").TextContent.Trim();

				if (topic != "skip")
				{
					program.Add(new Track
					{
						TrackId = trackId,
						Time = DateTime.ParseExact(
							trackElement.QuerySelector("time").TextContent.Trim().Split('-')[0], "H:mm",
							CultureInfo.InvariantCulture, DateTimeStyles.None),
						FullName = trackElement.QuerySelector("div.speakername .full-name").TextContent.Trim(),
						Topic = topic,
						Description = trackElement.QuerySelector("p").TextContent.Trim()
					});
				}
			}

			return program;
		}
	}

	public interface IDataService
	{
		Task<Conference> GetData();
	}
}
