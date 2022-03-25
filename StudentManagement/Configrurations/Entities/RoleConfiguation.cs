using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentManagement.Configruations.Entities
{
    public class RoleConfiguation : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure (EntityTypeBuilder<IdentityRole> builder )
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "ADMINSTRATOR",
                    NormalizedName = "ADMINSTRATOR"
                }
                
                );
            
        }
    }
}
