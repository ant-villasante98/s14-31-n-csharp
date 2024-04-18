using S14.MenuSystem.Common.Dtos;
using System.Collections.ObjectModel;

namespace S14.MenuSystem.Services
{
    public interface ISearchService
    {
        Task<SearchResponse> Search(string term, int? mallId = null, int? shopId = null, int? categoryId = null);
        Task<SearchGroupedResponse> Search(string term);
    }
}