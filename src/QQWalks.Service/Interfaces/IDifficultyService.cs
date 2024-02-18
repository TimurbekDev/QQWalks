using QQWalks.Service.DTOs.Difficulties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Interfaces;

public interface IDifficultyService
{
    Task<IEnumerable<DifficultyDTO>> GetAllAsync();
}
