using Microsoft.AspNetCore.Identity;
using ProjectHemid.Data;
using ProjectHemid.Interface;
using ProjectHemid.Repository;

namespace ProjectHemid.Services
{
    public class TokenService : ITokenRepository
    {
        private readonly TokenRepository _tokenRepository;

        public TokenService(AuthDbContext tokenRepository , IConfiguration configuration)
        {
            _tokenRepository =new TokenRepository(tokenRepository , configuration);
        }

        public string CreatJwtToken(IdentityUser user, List<string> roles)
        {
            return _tokenRepository.CreatJwtToken(user, roles);
        }
    }
}
