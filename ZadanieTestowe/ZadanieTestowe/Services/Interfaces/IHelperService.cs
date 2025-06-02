using ZadanieTestowe.Models;

namespace ZadanieTestowe.Services.Interfaces;

public interface IHelperService
{
    IEnumerable<Campaign> GetCampaigns();

    IEnumerable<Town> GetTowns();

    IEnumerable<Product> GetProducts();

    IEnumerable<Keyword> GetKeywords();

    Product GetProductBy(Func<Product, bool> predicate);

    Town GetTownBy(Func<Town, bool> predicate);

    List<Keyword> GetCampaignKeywordsBy(Guid[] keywordsIds, IEnumerable<Keyword> keywords);

    Campaign GetCampaignBy(Func<Campaign, bool> predicate);
}