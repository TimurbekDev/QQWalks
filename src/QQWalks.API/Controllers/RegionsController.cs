using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QQWalks.API.CustomActionFilters;
using QQWalks.Service.DTOs.Regions;
using QQWalks.Service.Interfaces;

namespace QQWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModel]
public class RegionsController : ControllerBase
{
    private readonly IRegionService regionService;

    public RegionsController(IRegionService regionService)
    {
        this.regionService = regionService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDTO)
    {
        return Ok(await this.regionService.CreateAsync(addRegionRequestDTO));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll() 
    { 
        return Ok(await this.regionService.GetAllAsync());
    }
    [HttpGet]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid Id) 
    { 
        return Ok(await this.regionService.GetByIdAsync(Id));
    }
    [HttpDelete]
    [Route("{Id:Guid}")]
    [Authorize]
    public async Task<bool> Delete([FromRoute] Guid Id)
    {
        return (await this.regionService.DeleteAsync(Id));
    }
    [HttpPut]
    [Route("{Id:Guid}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] Guid Id,
        [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
    {
        return Ok(await this.regionService.UpdateAsync(Id, updateRegionRequestDTO));
    }
}
