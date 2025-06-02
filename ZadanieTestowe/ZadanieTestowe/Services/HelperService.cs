using Microsoft.EntityFrameworkCore;
using ZadanieTestowe.Exceptions;
using ZadanieTestowe.Extensions;
using ZadanieTestowe.Models;
using ZadanieTestowe.Services.Interfaces;

namespace ZadanieTestowe.Services;

public class HelperService(AppDbContext dbContext) : IHelperService
{
    public IEnumerable<Campaign> GetCampaigns()
    {
        var campaigns = dbContext.Campaigns.ToList();

        return campaigns;
    }

    public IEnumerable<Town> GetTowns()
    {
        var towns = dbContext.Towns.ToList();

        return towns;
    }

    public IEnumerable<Product> GetProducts()
    {
        var products = dbContext.Products
            .Include(p => p.Campaign)
            .ThenInclude(c => c.Town)
            .Include(p => p.Campaign.Keywords)
            .ToList();

        return products;
    }

    public IEnumerable<Keyword> GetKeywords()
    {
        var keywords = dbContext.Keywords.ToList();

        return keywords;
    }

    public Campaign GetCampaignBy(Func<Campaign, bool> predicate)
    {
        var currentCampaign = GetCampaigns().FirstOrDefault(predicate);

        if (currentCampaign == null)
        {
            throw new CampaignNotFoundException();
        }

        return currentCampaign;
    }

    public Product GetProductBy(Func<Product, bool> predicate)
    {
        var currentProduct = GetProducts().FirstOrDefault(predicate);

        if (currentProduct == null)
        {
            throw new ProductNotFoundException();
        }

        return currentProduct;
    }

    public Town GetTownBy(Func<Town, bool> predicate)
    {
        var currentTown = GetTowns().FirstOrDefault(predicate);

        if (currentTown == null)
        {
            throw new TownNotFoundException();
        }

        return currentTown;
    }

    public List<Keyword> GetCampaignKeywordsBy(Guid[] keywordsIds, IEnumerable<Keyword> keywords)
    {
        return keywords.Where(keyword => keywordsIds.Contains(keyword.Id)).ToList();
    }
}