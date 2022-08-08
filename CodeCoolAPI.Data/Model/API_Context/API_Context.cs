using CodeCoolAPI.Data.Model.API_Context.Seeder;

namespace CodeCoolAPI.Data.Model.API_Context
{
    public class API_Context : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<BaseUser>? BaseUsers { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Material>? Materials { get; set; }
        public DbSet<MaterialType>? MaterialTypes { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<CredentialsContainer>? CredentialsContainers { get; set; }
        public API_Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(m => m.Materials).WithOne(a => a.Author);
            modelBuilder.Entity<MaterialType>().HasMany(m => m.Materials).WithOne(m => m.MaterialType);
            modelBuilder.Entity<Material>().HasMany(r => r.Reviews).WithOne(m => m.Material);
            modelBuilder.Entity<Material>()
                        .Property(p => p.PublicationDate)
                        .HasColumnType("date");

            modelBuilder.SeedDatabase();
        }
    }
}
