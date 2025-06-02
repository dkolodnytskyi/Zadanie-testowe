namespace ZadanieTestowe.Dtos;

public class CampaignDto
{
    public string Name { get; set; }

    public Guid[] KeywordsIds { get; set; }

    public decimal BidAmount { get; set; }

    public decimal CampaignFund { get; set; }

    public bool Status { get; set; }

    public Guid TownId { get; set; }

    public float Radius { get; set; }
}