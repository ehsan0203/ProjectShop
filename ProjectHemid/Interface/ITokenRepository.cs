using Microsoft.AspNetCore.Identity;

namespace ProjectHemid.Interface
{
    public interface ITokenRepository
    {
        string CreatJwtToken(IdentityUser user, List<string> roles);
    }
}
