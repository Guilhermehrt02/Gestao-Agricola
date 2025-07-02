using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class UsersDbContext(DbContextOptions<UsersDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options), IUsersDbContext
    {
        public DbSet<User> IdentityUsers { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Harvest> Harvests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Guid> roleIds = [];
            Dictionary<string, object> roles = [];

            foreach (var role in RoleExtension.GetValues())
            {
                var roleId = Guid.NewGuid();
                roles.Add(role.ToFriendlyString(), new
                {
                    Id = roleId,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper()
                });
                roleIds.Add(roleId);
            }

            foreach (var role in roles)
            {
                modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
                {
                    Id = (Guid)role.Value.GetType().GetProperty("Id")!.GetValue(role.Value)!,
                    Name = (string)role.Value.GetType().GetProperty("Name")!.GetValue(role.Value)!,
                    NormalizedName = role.Value.GetType().GetProperty("NormalizedName")!.GetValue(role.Value)!.ToString()!.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }

            List<User> users =
            [
                new User("John", "Doe", "example1@gmail.com", "(99) 99999-9991"),
                new User("Jane", "Doe", "example2@gmail.com", "(99) 99999-9992"),
                new User("Alice", "Anderson", "example3@gmail.com", "(99) 99999-9993"),
                new User("Bob", "Anderson", "example4@gmail.com", "(99) 99999-9994"),
                new User("Charlie", "Smith", "example5@gmail.com", "(99) 99999-9995")
            ];

            foreach (var user in users)
            {
                user.UserName = user.FirstName.ToLower();
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email!.ToUpper();
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("test123");
            }

            modelBuilder.Entity<User>().HasData(users);

            for (int i = 0; i < users.Count; i++)
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
                {
                    UserId = users[i].Id,
                    RoleId = roleIds[i]
                });
            }

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                    .HasMaxLength(300);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Amount)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50);

                entity.Property(e => e.ReceiptUrl)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Revenue>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                    .HasMaxLength(300);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Amount)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.ReceiptUrl)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.UploadType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(d => d.PhotoUrl)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(d => d.Date)
                    .IsRequired();

                entity.Property(d => d.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(d => d.Result)
                    .HasMaxLength(1000);

                entity.Property(d => d.Latitude)
                    .HasPrecision(10, 8);

                entity.Property(d => d.Longitude)
                    .HasPrecision(11, 8);
            });

            modelBuilder.Entity<Plot>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Description)
                    .HasMaxLength(500);

                entity.Property(p => p.Area)
                    .IsRequired();

                entity.Property(p => p.Latitude)
                    .HasPrecision(10, 8);

                entity.Property(p => p.Longitude)
                    .HasPrecision(11, 8);

                entity.Property(p => p.CreatedAt)
                    .IsRequired();

                entity.Property(p => p.UpdatedAt)
                    .IsRequired();
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(f => f.Location)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(f => f.CreatedAt)
                    .IsRequired();

                entity.Property(f => f.UpdatedAt)
                    .IsRequired();
            });

            modelBuilder.Entity<Harvest>(entity =>
            {
                entity.HasKey(h => h.Id);

                entity.Property(h => h.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(h => h.StartDate)
                    .IsRequired();

                entity.Property(h => h.EndDate)
                    .IsRequired();

                entity.Property(h => h.CreatedAt)
                    .IsRequired();

                entity.Property(h => h.UpdatedAt)
                    .IsRequired();
            });
        }
    }
}
