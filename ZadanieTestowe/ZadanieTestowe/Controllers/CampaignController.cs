using Microsoft.AspNetCore.Mvc;
using ZadanieTestowe.Dtos;
using ZadanieTestowe.Models;
using ZadanieTestowe.Services;
using ZadanieTestowe.Services.Interfaces;

namespace ZadanieTestowe.Controllers;

[Route("[controller]")]
[ApiController]
public class CampaignController(ICampaignService campaignService) : ControllerBase
{
    [HttpPost("interact")]
    public IActionResult Interact(Guid campaignId)
    {
        campaignService.UpdateCampaignsFund(campaignId);

        return Ok();
    }

    [HttpPost("add-to-product")]
    public IActionResult Post(CampaignDto campaignDto, Guid productId)
    {
        campaignService.AddCampaignForProduct(campaignDto, productId);

        return Ok();
    }

    [HttpPut("edit")]
    public IActionResult Edit(CampaignDto campaignDto, Guid productId)
    {
        campaignService.EditCampaign(campaignDto, productId);

        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(Guid id)
    {
        campaignService.DeleteCampaign(id);

        return Ok();
    }
}