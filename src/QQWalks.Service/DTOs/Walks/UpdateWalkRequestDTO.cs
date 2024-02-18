using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.DTOs.Walks;

public class UpdateWalkRequestDTO
{
    [Required]
    [MaxLength(255, ErrorMessage = "Name has to be a maximum 255 characters")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required]
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    //F-K
    [Required]
    public Guid DifficultyId { get; set; }
    [Required]
    public Guid RegionId { get; set; }
}
