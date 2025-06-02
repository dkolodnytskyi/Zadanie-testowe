using ZadanieTestowe.Dtos;
using ZadanieTestowe.Models;

namespace ZadanieTestowe.Services.Interfaces;

public interface ICampaignService
{
    void UpdateCampaignsFund(Guid campaignId);

    void AddCampaignForProduct(CampaignDto campaignDto, Guid productId);

    void EditCampaign(CampaignDto campaignDto, Guid productId);

    void DeleteCampaign(Guid id);
}