using AutoMapper;
using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Auths;
using QQWalks.Service.DTOs.Difficulties;
using QQWalks.Service.DTOs.Images;
using QQWalks.Service.DTOs.Regions;
using QQWalks.Service.DTOs.Walks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        //Regions
        CreateMap<Region,AddRegionRequestDTO>().ReverseMap();
        CreateMap<Region,RegionDTO>().ReverseMap();
        CreateMap<Region,UpdateRegionRequestDTO>().ReverseMap();

        //Walks
        CreateMap<Walk,AddWalkRequestDTO>().ReverseMap();
        CreateMap<Walk,WalkDTO>().ReverseMap();
        CreateMap<Walk,UpdateWalkRequestDTO>().ReverseMap();

        //Difficulties
        CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        
        //Images
        CreateMap<Image,ImageDTO>().ReverseMap();
        CreateMap<ImageUploadRequestDTO, Image>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File))
            .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => Path.GetExtension(src.File.FileName)))
            .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.File.Length))
            .ForMember(dest => dest.FilePath, opt => opt.Ignore()).ReverseMap();

        //Auth
        CreateMap<string, LoginResponseDTO>()
            .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src));
    }
}
