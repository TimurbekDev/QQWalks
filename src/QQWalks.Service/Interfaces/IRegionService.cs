using QQWalks.Service.DTOs.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Interfaces;

public interface IRegionService
{
    public Task<RegionDTO> CreateAsync(AddRegionRequestDTO addRegionRequestDTO);
    public Task<RegionDTO> UpdateAsync(Guid Id,UpdateRegionRequestDTO updateRegionRequestDTO);
    public Task<IEnumerable<RegionDTO>> GetAllAsync();
    public Task<RegionDTO> GetByIdAsync(Guid Id);
    public Task<bool> DeleteAsync(Guid Id);
}
