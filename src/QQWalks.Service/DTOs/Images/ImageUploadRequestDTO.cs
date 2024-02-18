using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.DTOs.Images;

public class ImageUploadRequestDTO
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
    public string? FileDescription { get; set; }
}
