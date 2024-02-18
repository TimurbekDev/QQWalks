using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QQWalks.Service.DTOs.Auths;
using QQWalks.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQWalks.Service.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly ITokenService tokenService;
    private readonly IMapper mapper;

    public AuthenticationService(UserManager<IdentityUser> userManager,
        ITokenService tokenService,
        IMapper mapper)
    {
        this.userManager = userManager;
        this.tokenService = tokenService;
        this.mapper = mapper;
    }
    public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
    {
        var user = await this.userManager.FindByEmailAsync(loginRequestDTO.Username);
        if (user != null)
        {
            var checkPasswordResult = await this.userManager.CheckPasswordAsync(user,
                loginRequestDTO.Password);
            if (checkPasswordResult)
            {
                var roles = await this.userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    var token = this.tokenService.CreateJwtToken(user, roles.ToList());
                    return this.mapper.Map<string, LoginResponseDTO>(token);
                }
            }
        }
        return this.mapper.Map<string, LoginResponseDTO>(""); ;
    }

    public async Task<bool> RegisterAsync(RegisterRequestDTO registerRequestDTO)
    {
        var identityUser = new IdentityUser
        {
            UserName = registerRequestDTO.Username,
            Email = registerRequestDTO.Username
        };

        var identityResult = await this.userManager.CreateAsync(identityUser,
            registerRequestDTO.Password);
        if (identityResult.Succeeded)
        {
            if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
            {
                var identity = await this.userManager.AddToRolesAsync(identityUser,
                    registerRequestDTO.Roles);
                if (identity.Succeeded)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
