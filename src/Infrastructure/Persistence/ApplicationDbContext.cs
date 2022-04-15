using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{   
    // EntityFrameworkCore\
    // Update-Database -Migration {migration name} -Context ApplicationDbContext
    // Remove-Migration -Context ApplicationDbContext

    // Add-Migration -OutputDir "Persistence/Migrations" -Name "Initial" -Context ApplicationDbContext
    // Update-Database -Context ApplicationDbContext
    // Optimize-DbContext -Context ApplicationDbContext
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<FolderFile> Files { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
