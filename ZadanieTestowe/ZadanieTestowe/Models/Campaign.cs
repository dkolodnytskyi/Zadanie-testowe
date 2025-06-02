namespace ZadanieTestowe.Models;

public class Campaign
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<Keyword> Keywords { get; set; }

    public decimal BidAmount { get; set; }

    public decimal CampaignFund { get; set; }

    public bool Status { get; set; }

    public Town Town { get; set; }

    public float Radius { get; set; }
}