using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace file_service.Config;

public static class JwtConfig
{
    private static TokenValidationParameters _tokenValidationParameters;

    public static TokenValidationParameters TokenValidationParameters
    {
        get { return _tokenValidationParameters ?? null; }
    }

    public static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration configuration)
    {
        SetTokenValidationParameters(configuration);

        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            jwt.RequireHttpsMetadata = false;
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = _tokenValidationParameters;
        });
    }

    private static void SetTokenValidationParameters(IConfiguration configuration)
    {
        _tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidIssuer = configuration[ConfigConsts.IssuerKeyName],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration[ConfigConsts.CryptoKeyName])),
            ClockSkew = TimeSpan.Zero
        };
    }
}