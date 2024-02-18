using QQWalks.Service.DTOs.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Interfaces;

public interface IAuthenticationService
{
    Task<bool> RegisterAsync(RegisterRequestDTO registerRequestDTO);
    Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
}
