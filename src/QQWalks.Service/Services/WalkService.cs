using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QQWalks.Data.IRepositories;
using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Regions;
using QQWalks.Service.DTOs.Walks;
using QQWalks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Services;

public class WalkService : IWalkService
{
    private readonly IMapper mapper;
    private readonly IRepository<Walk> repository;

    public WalkService(IMapper mapper,
        IRepository<Walk> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<WalkDTO> CreateAsync(AddWalkRequestDTO addWalkRequestDTO)
    {
        var walk = this.mapper.Map<Walk>(addWalkRequestDTO);
        walk.CreatedAt = DateTime.UtcNow;

        var result = await this.repository.CreateAsync(walk);

        return this.mapper.Map<WalkDTO>(result);
    }

    public async Task<bool> DeleteAsync(Guid Id)
    {
        return await this.repository.DeleteAsync(Id);
    }

    public async Task<IEnumerable<WalkDTO>> GetAllAsync()
    {
        var walks = await this.repository.GetAllAsync()
            .Include("Difficulty")
            .Include("Region")
            .ToListAsync();

        return this.mapper.Map<IEnumerable<WalkDTO>>(walks);
    }

    public async Task<WalkDTO> GetByIdAsync(Guid Id)
    {
        var walk = await this.repository.GetByIdAsync(Id);

        if (walk == null)
            throw new ArgumentException("existWalk is null");

        return this.mapper.Map<WalkDTO>(walk);
    }

    public async Task<WalkDTO> UpdateAsync(Guid Id, UpdateWalkRequestDTO updateWalkRequestDTO)
    {
        var existWalk = await this.repository.GetByIdAsync(Id);

        existWalk.Name = updateWalkRequestDTO.Name;
        existWalk.Description = updateWalkRequestDTO.Description;
        existWalk.DifficultyId = updateWalkRequestDTO.DifficultyId;
        existWalk.RegionId = updateWalkRequestDTO.RegionId;
        existWalk.WalkImageUrl = updateWalkRequestDTO.WalkImageUrl;
        existWalk.LengthInKm = updateWalkRequestDTO.LengthInKm;
        existWalk.UpdatedAt = DateTime.UtcNow;

        var walk = await this.repository.UpdateAsync(existWalk);

        return this.mapper.Map<WalkDTO>(walk);
    }
}
