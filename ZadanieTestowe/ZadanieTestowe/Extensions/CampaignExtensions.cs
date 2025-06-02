using ZadanieTestowe.Exceptions;
using ZadanieTestowe.Models;

namespace ZadanieTestowe.Extensions;

public static class CampaignExtensions
{
    public static Campaign SetKeywords(this Campaign campaign, IEnumerable<Keyword> keywords)
    {
        campaign.Keywords = keywords;

        return campaign;
    }

    public static Campaign SetTown(this Campaign campaign, Town town)
    {
        campaign.Town = town;

        return campaign;
    }

    public static void UpdateFund(this Campaign campaign)
    {
        if (campaign.CampaignFund < campaign.BidAmount)
        {
            throw new CampaignFundInsufficientException();
        }
        campaign.CampaignFund -= campaign.BidAmount;
    }
}