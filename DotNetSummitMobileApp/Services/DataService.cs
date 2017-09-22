using System.Threading;
using System.Threading.Tasks;
using DotNetSummitMobileApp.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DotNetSummitMobileApp.Services
{
	public class DataService : IDataService
	{
		private Conference _conference = new Conference();

		private RestClient _restClient = new RestClient("http://dotnetsummit.mybluemix.net/");
		private RestRequest _restRequest = new RestRequest("api/conference", Method.GET);

		public async Task<Conference> GetAllData()
		{
			if (_conference.Speakers == null || _conference.Tracks == null)
			{
				var restResponse = await _restClient.ExecuteTaskAsync(_restRequest, new CancellationTokenSource().Token);
				_conference = JsonConvert.DeserializeObject<Conference>(restResponse.Content);
			}

			return _conference;
		}
	}

	public interface IDataService
	{
		Task<Conference> GetAllData();
	}
}
