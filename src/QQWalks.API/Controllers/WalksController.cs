using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QQWalks.API.CustomActionFilters;
using QQWalks.Service.DTOs.Walks;
using QQWalks.Service.Interfaces;

namespace QQWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ValidateModel]
public class WalksController : ControllerBase
{
    private readonly IWalkService walkService;

    public WalksController(IWalkService walkService)
    {
        this.walkService = walkService;
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
    {
        return Ok(await this.walkService.CreateAsync(addWalkRequestDTO));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await this.walkService.GetAllAsync());
    }
    [HttpGet]
    [Route("{Id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid Id)
    {
        return Ok(await this.walkService.GetByIdAsync(Id));
    }
    [HttpPut]
    [Route("{Id:Guid}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] Guid Id ,
        [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
    {
        return Ok(await this.walkService.UpdateAsync(Id, updateWalkRequestDTO));    
    }
    [HttpDelete]
    [Route("{Id:Guid}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] Guid Id)
    {
        return Ok(await this.walkService.DeleteAsync(Id));
    }
}
