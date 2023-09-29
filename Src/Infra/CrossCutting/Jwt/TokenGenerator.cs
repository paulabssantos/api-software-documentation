using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
public class TokenGenerator : ITokenGenerator
{
    private IConfiguration _configuration;

    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateMailToken(int projectId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Convert.FromBase64String(_configuration["Jwt:Secret"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]{
                    new Claim("projectId",projectId.ToString())
                }),
            Expires = DateTime.Now.AddHours(1),
            SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}