using ChellengeE.Models;
using ChellengeE.Models.Dtos;

namespace ChellengeE.Repository.Interfaces
{
    public interface INewApiRepository
    {
        Task<PagedList<Article>> GetByFilter(string search, string? country, DateTime? startDate, DateTime? endDate, string page, string pageSize);
        Task<PagedList<Article>> GetByCountry(string country, string page, string pageSize);
    }
}
