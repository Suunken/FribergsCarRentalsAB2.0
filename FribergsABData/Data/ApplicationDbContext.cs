using FribergsABData.Constants;
using FribergsABData.Dto;
using FribergsABData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FribergsABData
{
    public class ApplicationDbContext : IdentityDbContext<ApiUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = ApiRoles.User,
                    NormalizedName = ApiRoles.User.ToUpper(),
                    Id = ApiRoles.UserId
                },
                new IdentityRole
                {
                    Name = ApiRoles.Admin,
                    NormalizedName = ApiRoles.Admin.ToUpper(),
                    Id = ApiRoles.AdminId
                }
                );


            builder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id = "07f01dac-0fd1-433b-a15d-f97c7bd95a90",
                    Email = "User@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    UserName = "user@user.com",
                    NormalizedUserName = "USER@USER.COM",
                    FirstName = "User",
                    LastName = "System",
                    PasswordHash = "AQAAAAEAACcQAAAAEF8Y6qP7pPKYcOzv0PsUcXqfEotJqniWTUpCML3I3nho4v3kXeRv5Hby7s3OI3I7JQ==\r\n",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "5afd18f5-b009-4d59-a90c-b78802dff3d2",
                    SecurityStamp = "b99e3840-2984-4d3f-a751-7335a57d34d2",


                },
                new ApiUser
                {
                    Id = "bd899403-27f1-45f8-a8b1-a1fde6d492d3",
                    Email = "Admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    UserName = "admin@admin.com",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    FirstName = "Admin",
                    LastName = "System",
                    PasswordHash = "AQAAAAEAACcQAAAAEF8Y6qP7pPKYcOzv0PsUcXqfEotJqniWTUpCML3I3nho4v3kXeRv5Hby7s3OI3I7JQ==\r\n",
                    EmailConfirmed = true,
                    ConcurrencyStamp = "da1c37c1-a86a-4a45-82d4-6357e00c6525",
                    SecurityStamp = "02a3466e-8967-4da3-ae9a-27c8e47a8b8b",

                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ApiRoles.UserId,
                    UserId = "07f01dac-0fd1-433b-a15d-f97c7bd95a90"
                },
                   new IdentityUserRole<string>
                   {
                       RoleId = ApiRoles.AdminId,
                       UserId = "bd899403-27f1-45f8-a8b1-a1fde6d492d3"
                   });





        }




    }
}
