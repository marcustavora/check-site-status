using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteStatus.Domain.Entities;

namespace SiteStatus.Infra.Data.Map
{
    public class StatusMap : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Uri).HasMaxLength(128).IsRequired();
            entity.Property(x => x.IsUp).IsRequired();
            entity.Property(x => x.CheckDate).IsRequired();
        }
    }
}
