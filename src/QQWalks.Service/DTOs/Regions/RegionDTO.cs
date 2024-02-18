using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.DTOs.Regions;

public class RegionDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string? RegionImageUrl { get; set; }
}
