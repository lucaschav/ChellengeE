using ChellengeE.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChellengeE.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewApiRepository _newApiRepository;

        public NewsController(INewApiRepository newApiRepository)
        {
            this._newApiRepository = newApiRepository;
        }

        [HttpGet("top-headlines")]
        public async Task<IActionResult> Get(string country, string page, string pageSize)
        {
            var result = await _newApiRepository.GetByCountry(country, page, pageSize);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByFilter(string search, string? country, DateTime? startDate, DateTime? endDate, string page, string pageSize)
        {
            var result = await _newApiRepository.GetByFilter(search, country, startDate, endDate, page, pageSize);

            return Ok(result);
        }
    }
}