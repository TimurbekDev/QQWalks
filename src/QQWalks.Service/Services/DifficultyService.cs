using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QQWalks.Data.IRepositories;
using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Difficulties;
using QQWalks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Services;

public class DifficultyService : IDifficultyService
{
    private readonly IMapper mapper;
    private readonly IRepository<Difficulty> repository;

    public DifficultyService(IMapper mapper,
        IRepository<Difficulty> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<IEnumerable<DifficultyDTO>> GetAllAsync()
    {
        var difficulties = await this.repository.GetAllAsync().ToListAsync();

        return this.mapper.Map<IEnumerable<DifficultyDTO>>(difficulties);   
    }
}
