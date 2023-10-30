using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CatalogBrandDto request)
    {
        var result = await _catalogBrandService.Add(request.Id, request.Brand);
        return Ok(new ItemResponse<int?>() { Id = result });
    }

    [HttpDelete]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int itemId)
    {
        var result = await _catalogBrandService.Delete(itemId);
        return Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(CatalogBrandDto request)
    {
        var result = await _catalogBrandService.Update(request.Id, request.Brand);
        return Ok(result);
    }
}