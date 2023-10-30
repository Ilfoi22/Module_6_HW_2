using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogBrandController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CatalogTypeDto request)
    {
        var result = await _catalogTypeService.Add(request.Id, request.Type);
        return Ok(new ItemResponse<int?>() { Id = result });
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int itemId)
    {
        var result = await _catalogTypeService.Delete(itemId);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(CatalogTypeDto request)
    {
        var result = await _catalogTypeService.Update(request.Id, request.Type);
        return Ok(result);
    }
}