using System.Net;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int id)
    {
        var catalogItemDto = await _catalogService.GetCatalogItemByIdAsync(id);
        return Ok(catalogItemDto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(string brandName)
    {
        var catalogItemDto = await _catalogService.GetCatalogItemByBrandAsync(brandName);
        return Ok(catalogItemDto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(string type)
    {
        var catalogItemDto = await _catalogService.GetCatalogItemByTypeAsync(type);
        return Ok(catalogItemDto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Brands(string brandName)
    {
        var catalogItemDto = await _catalogService.CatalogBrandBrandsAsync(brandName);
        return Ok(catalogItemDto);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Types(string type)
    {
        var catalogItemDto = await _catalogService.CatalogTypeTypesAsync(type);
        return Ok(catalogItemDto);
    }
}