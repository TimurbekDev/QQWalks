using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Interfaces;

public interface IImageService
{
    Task<ImageDTO> Upload(ImageUploadRequestDTO imageUploadRequestDTO);
}
