using QQWalks.Service.DTOs.Difficulties;
using QQWalks.Service.DTOs.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.DTOs.Walks;

public class WalkDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    //F-K
    public Guid DifficultyId { get; set; }
    public Guid RegionId { get; set; }
    // N-v prop
    public DifficultyDTO Difficulty { get; set; }
    public RegionDTO Region { get; set; }
}
