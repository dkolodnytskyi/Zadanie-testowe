using Microsoft.AspNetCore.Mvc;
using ZadanieTestowe.Services.Interfaces;

namespace ZadanieTestowe.Controllers;

[Route("[controller]")]
[ApiController]
public class HelperController(IHelperService helperService) : ControllerBase
{
    [HttpGet("campaigns")]
    public IActionResult GetCampaigns()
    {
        var result = helperService.GetCampaigns();

        return Ok(result);
    }

    [HttpGet("towns")]
    public IActionResult GetTowns()
    {
        var result = helperService.GetTowns();

        return Ok(result);
    }

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        var result = helperService.GetProducts();

        return Ok(result);
    }

    [HttpGet("keywords")]
    public IActionResult GetKeywords()
    {
        var result = helperService.GetKeywords();

        return Ok(result);
    }
}