using QQWalks.Domain.Entities;
using QQWalks.Service.DTOs.Walks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Interfaces;

public interface IWalkService
{
    public Task<WalkDTO> CreateAsync(AddWalkRequestDTO addWalkRequestDTO);
    public Task<WalkDTO> UpdateAsync(Guid Id, UpdateWalkRequestDTO updateWalkRequestDTO);
    public Task<IEnumerable<WalkDTO>> GetAllAsync();
    public Task<WalkDTO> GetByIdAsync(Guid Id);
    public Task<bool> DeleteAsync(Guid Id);
}
