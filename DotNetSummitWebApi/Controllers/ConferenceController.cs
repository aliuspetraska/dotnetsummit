using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSummitWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSummitWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ConferenceController : Controller
    {
		private static DataService _dataService;

		public ConferenceController()
		{
			_dataService = new DataService();
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
            var data = await _dataService.GetData();
			return Ok(data);
		}
    }
}
