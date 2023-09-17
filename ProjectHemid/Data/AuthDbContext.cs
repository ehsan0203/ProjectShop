


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ProjectHemid.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "3A1CE3D3-274F-410D-807C-2D3E31019C72";
            var writerRoleId = "F6E67F19-AAFC-451C-A039-E5B0BD62715F";
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp=readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName="Writer".ToUpper(),
                    ConcurrencyStamp=writerRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var adminUserId = "0620B618-7A87-409C-AB74-E35C9E16050C";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "Ehsan@gmail.com",
                Email = "Ehsan@gmail.com",
                NormalizedEmail = "Ehsan@gmail.com",
                NormalizedUserName = "Ehsan@gmail.com"
            };
            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Ehsan@123");
            builder.Entity<IdentityUser>().HasData(admin);

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
