﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using FitCard.Domain.DTOs.User;
using FitCard.Domain.Interfaces.Services.User;
using FitCard.Domain.Repository;
using FitCard.Domain.Security;
using System.Threading.Tasks;
using FitCard.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FitCard.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration { get; }

        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDTO user)
        {
            var baseUser = new UserEntity();
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar"
                    };
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(baseUser.Email), new[]{
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti o id do token
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                    });

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds); //segundos definido no arquivo de configuracao

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObject(createDate, expirationDate, token, user);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }

        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                username = user.Email,
                message = "Usuário Logado com sucesso"
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }
    }
}