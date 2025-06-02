using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ZadanieTestowe.Dtos;
using ZadanieTestowe.Extensions;
using ZadanieTestowe.Models;
using ZadanieTestowe.Services.Interfaces;

namespace ZadanieTestowe.Services;

public class CampaignService(AppDbContext dbContext, IHelperService helperService, IValidator<CampaignDto> validator) : ICampaignService
{
    public void UpdateCampaignsFund(Guid campaignId)
    {
        var campaign = helperService.GetCampaignBy(x => x.Id == campaignId);

        campaign.UpdateFund();

        dbContext.Campaigns.Update(campaign);
        dbContext.SaveChanges();
    }

    public void AddCampaignForProduct(CampaignDto campaignDto, Guid productId)
    {
        var validationResult = validator.Validate(campaignDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Validation failed", validationResult.Errors);
        }

        var currentProduct = helperService.GetProductBy(x => x.Id == productId);

        var currentTown = helperService.GetTownBy(x => x.Id == campaignDto.TownId);

        var keywords = helperService.GetKeywords();

        var campaignKeywords = helperService.GetCampaignKeywordsBy(campaignDto.KeywordsIds, keywords);

        var newCampaign = campaignDto.Adapt<Campaign>();

        newCampaign
            .SetKeywords(campaignKeywords)
            .SetTown(currentTown);

        currentProduct.Campaign = newCampaign;

        dbContext.Campaigns.Add(newCampaign);
        dbContext.Products.Update(currentProduct);
        dbContext.SaveChanges();
    }

    public void EditCampaign(CampaignDto campaignDto, Guid productId)
    {
        var validationResult = validator.Validate(campaignDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException("Validation failed", validationResult.Errors);
        }

        var campaign = helperService.GetProductBy(x => x.Id == productId).Campaign;

        var currentTown = helperService.GetTownBy(x => x.Id == campaignDto.TownId);

        var keywords = helperService.GetKeywords();

        var campaignKeywords = helperService.GetCampaignKeywordsBy(campaignDto.KeywordsIds, keywords);

        campaign.Name = campaignDto.Name;
        campaign.BidAmount = campaignDto.BidAmount;
        campaign.CampaignFund = campaignDto.CampaignFund;
        campaign.Status = campaignDto.Status;
        campaign.Radius = campaignDto.Radius;
        campaign
            .SetKeywords(campaignKeywords)
            .SetTown(currentTown);

        dbContext.Campaigns.Update(campaign);
        dbContext.SaveChanges();
    }

    public void DeleteCampaign(Guid id)
    {
        var campaign = helperService.GetCampaignBy(x => x.Id == id);

        dbContext.Campaigns.Remove(campaign);
        dbContext.SaveChanges();
    }
}