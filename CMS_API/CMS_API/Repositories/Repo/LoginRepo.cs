using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMS_API.Repositories.Repo
{
    public static class LoginRepo
    {
        public static string GenerateToken(string userName)
        {
            var secutityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2AFE16A6D630D94CD07C68D5E35568655BF5F60BEF29C4F1321FC857816AFEC9"));
            var credentials = new SigningCredentials(secutityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserName", userName),
                new Claim("role", "1")
            };

            var token = new JwtSecurityToken("http://localhost:43159",
                "http://localhost:43159",
                claims,
                DateTime.UtcNow,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //ConfigureJwtLogin
        internal static TokenValidationParameters tokenValidationParams;
        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            var secutityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2AFE16A6D630D94CD07C68D5E35568655BF5F60BEF29C4F1321FC857816AFEC9"));
            var credentials = new SigningCredentials(secutityKey, SecurityAlgorithms.HmacSha256);

            tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:43159",
                ValidateLifetime = true,
                ValidAudience = "http://localhost:43159",
                ValidateAudience = true,
                IssuerSigningKey = credentials.Key,
                ClockSkew = TimeSpan.FromMinutes(30),

            };
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
#if PROD || UAT
                    options.IncludeErrorDetail = false;
#elif DEBUG
                options.RequireHttpsMetadata = false;
#endif
            });
        }
    }
}
