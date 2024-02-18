using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.DTOs.Regions;

public class UpdateRegionRequestDTO
{
    [Required]
    [MaxLength(255, ErrorMessage = "Name has to be a maximum 255 characters")]
    public string Name { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a maximum 3 characters")]
    public string Code { get; set; }
    public string? RegionImageUrl { get; set; }
}
