using inCommodities.test.external.Services;
using Microsoft.AspNetCore.Mvc;

namespace inCommodities.test.external.Controllers;

[ApiController]
[Route("[controller]")]
public class WindStationController : ControllerBase
{
    [HttpGet("MarketPrice", Name = "GetMarketPrice")]
    public IActionResult GetCurrentMarketPrice()
    {
        var response = LogicService.GetCurrentMarketPrice();
        return convertHttpRequestMessageToIActionResult(response);
    }

    [HttpPut("MarketPrice/{marketPrice}", Name = "SetMarketPrice")]
    public IActionResult SetCurrentMarketPrice(uint marketPrice)
    {
        var response = LogicService.SetCurrentMarketPrice(marketPrice);
        return convertHttpRequestMessageToIActionResult(response);
    }

    [HttpGet("ProductionTarget", Name = "GetProductionTarget")]
    public IActionResult GetCurrentProductionTarget()
    {
        var response = LogicService.GetCurrentProductionTarget();
        return convertHttpRequestMessageToIActionResult(response);
    }

    [HttpPut("ProductionTarget/{delta}", Name = "UpdateProductionTarget")]
    public IActionResult UpdateCurrentProductionTarget(int delta)
    {
        var response = LogicService.UpdateCurrentProductionTarget(delta);
        return convertHttpRequestMessageToIActionResult(response);
    }

    [HttpGet("ExpectedProduction", Name = "GetExpectedProduction")]
    public IActionResult GetExpectedProduction()
    {
        var response = LogicService.GetExpectedProduction();
        return convertHttpRequestMessageToIActionResult(response);
    }

    private IActionResult convertHttpRequestMessageToIActionResult(HttpResponseMessage response)
    {
        using var reader = new StreamReader(response.Content.ReadAsStream());
        var content = reader.ReadToEnd();
        return StatusCode((int)response.StatusCode, content);
    }
}


