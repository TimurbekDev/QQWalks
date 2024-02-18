using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QQWalks.Data.IRepositories;
using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Regions;
using QQWalks.Service.Interfaces;

namespace QQWalks.Service.Services;

public class RegionService : IRegionService
{
    private readonly IMapper mapper;
    private readonly IRepository<Region> repository;

    public RegionService(IMapper mapper,
        IRepository<Region> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<RegionDTO> CreateAsync(AddRegionRequestDTO addRegionRequestDTO)
    {
        var region = this.mapper.Map<Region>(addRegionRequestDTO);
        region.CreatedAt = DateTime.UtcNow;

        var result = await this.repository.CreateAsync(region);

        return this.mapper.Map<RegionDTO>(result);
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
        return await this.repository.DeleteAsync(Id);
    }

    public async Task<IEnumerable<RegionDTO>> GetAllAsync()
    {
        var regions = await this.repository.GetAllAsync().ToListAsync();
        return this.mapper.Map<IEnumerable<RegionDTO>>(regions);
    }

    public async Task<RegionDTO> GetByIdAsync(Guid Id)
    {
        var region = await this.repository.GetByIdAsync(Id);

        if (region == null)
            throw new ArgumentException("region is null");

        return this.mapper.Map<RegionDTO>(region);
    }

    public async Task<RegionDTO> UpdateAsync(Guid Id, UpdateRegionRequestDTO updateRegionRequestDTO)
    {
        var region = await this.repository.GetByIdAsync(Id);

        region.Code = updateRegionRequestDTO.Code;
        region.Name = updateRegionRequestDTO.Name;
        region.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;

        region.UpdatedAt = DateTime.UtcNow;

        var result = await this.repository.UpdateAsync(region);

        return this.mapper.Map<RegionDTO>(result);
    }
}
