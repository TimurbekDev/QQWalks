using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using QQWalks.Data.IRepositories;
using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Images;
using QQWalks.Service.Interfaces;

namespace QQWalks.Service.Services;

public class ImageService : IImageService
{
    private readonly IMapper mapper;
    private readonly IRepository<Image> repository;
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly IHttpContextAccessor httpContextAccessor;

    public ImageService(IMapper mapper,
        IRepository<Image> repository,
        IWebHostEnvironment webHostEnvironment,
        IHttpContextAccessor httpContextAccessor)
    {
        this.mapper = mapper;
        this.repository = repository;
        this.webHostEnvironment = webHostEnvironment;
        this.httpContextAccessor = httpContextAccessor;
    }
    public async Task<ImageDTO> Upload(ImageUploadRequestDTO imageUploadRequestDTO)
    {
        var image = this.mapper.Map<Image>(imageUploadRequestDTO);

        var localFilePath = Path.Combine(this.webHostEnvironment.ContentRootPath,
                "Images",
                $"{image.FileName}{image.FileExtension}");

        using var stream = new FileStream(localFilePath, FileMode.Create);

        await image.File.CopyToAsync(stream);

        var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}:" +
            $"//{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}" +
            $"/Images/{image.FileName}{image.FileExtension}";

        image.FilePath = urlFilePath;
        image.CreatedAt = DateTime.UtcNow;

         var result = await this.repository.CreateAsync(image);

        return this.mapper.Map<ImageDTO>(result);
    }
}
