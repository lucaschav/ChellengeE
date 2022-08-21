using ChellengeE.Models;
using ChellengeE.Models.Dtos;
using ChellengeE.Repository.Interfaces;
using ChellengeE.Services;

namespace ChellengeE.Repository
{
    public class NewApiRepository : BaseService, INewApiRepository
    {
        public NewApiRepository(IHttpClientFactory httpClient) : base(httpClient)
        {

        }

        public async Task<PagedList<Article>> GetByCountry(string country, string page, string pageSize)
        {
            var response = await SendAsync<NewRequest>(new ApiRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UrlApiBase}top-headlines?country={country}&page={page}&pageSize={pageSize}"
            });

            return new PagedList<Article>()
            {
                ActualPage = int.Parse(page),
                TotalPages = response.TotalResults,
                Items = response.Articles
            };
        }

        public async Task<PagedList<Article>> GetByFilter(string search, string? country, DateTime? startDate, DateTime? endDate, string page, string pageSize)
        {
            var searchQuery = string.IsNullOrEmpty(search) ? "" : $"q={search}&";
            var startDateQuery = startDate == null ? "" : $"from={startDate.Value.ToString("yyyy/MM/dd")}&";
            var endDateQuery = endDate == null ? "" : $"to={endDate.Value.ToString("yyyy/MM/dd")}&";
            var countryQuery = string.IsNullOrEmpty(country) ? "" : $"language={country}&";

            var response = await SendAsync<NewRequest>(new ApiRequest 
            { 
                ApiType = SD.ApiType.GET,
                Url = $"{SD.UrlApiBase}everything?{searchQuery}{startDateQuery}{endDateQuery}{countryQuery}page={page}&pageSize={pageSize}"
            });

            return new PagedList<Article>()
            {
                ActualPage = int.Parse(page),
                TotalPages = response.TotalResults,
                Items = response.Articles
            };
        }
    }
}
