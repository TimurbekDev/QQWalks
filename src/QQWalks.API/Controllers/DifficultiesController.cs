using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QQWalks.Service.Interfaces;

namespace QQWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DifficultiesController : ControllerBase
{
    private readonly IDifficultyService difficultyService;

    public DifficultiesController(IDifficultyService difficultyService)
    {
        this.difficultyService = difficultyService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await this.difficultyService.GetAllAsync());
    }
}
