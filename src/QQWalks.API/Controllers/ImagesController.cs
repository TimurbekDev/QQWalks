using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QQWalks.API.CustomActionFilters;
using QQWalks.Service.DTOs.Images;
using QQWalks.Service.Interfaces;

namespace QQWalks.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[ValidateModel]
public class ImagesController : ControllerBase
{
    private readonly IImageService imageService;

    public ImagesController(IImageService imageService)
    {
        this.imageService = imageService;
    }
    [HttpPost]
    [Route("Upload")]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO imageUploadRequestDTO)
    {
        ValidateFileUpload(imageUploadRequestDTO);

        if(ModelState.IsValid)
            return Ok(await this.imageService.Upload(imageUploadRequestDTO));

        return BadRequest(ModelState);
    }
    private void ValidateFileUpload(ImageUploadRequestDTO imageUploadRequestDTO)
    {
        var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDTO.File.FileName)))
        {
            ModelState.AddModelError("file", "Unsupported file extension");
        }
        if (imageUploadRequestDTO.File.Length > 10485760)
        {
            ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size image.");
        }
    }
}
