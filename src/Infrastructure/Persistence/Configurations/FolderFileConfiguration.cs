using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public partial class FolderFileConfiguration : IEntityTypeConfiguration<FolderFile>
    {
        public void Configure(EntityTypeBuilder<FolderFile> entity)
        {
            entity.ToTable("File");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Folder)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.FolderId);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FolderFile> entity);
    }
}
