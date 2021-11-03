using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.EFCore
{
    public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            string entityName = typeof(T).Name;
            builder.HasKey(e => e.F_GUID).IsClustered(false).HasName($"F_GUID_BD_{entityName.ToUpper()}_API");
            builder.Property(e => e.F_GUID).HasDefaultValueSql("newsequentialid()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.F_ID).UseIdentityColumn();
            builder.Property(e => e.F_ID).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            builder.Property(e => e.F_TM).IsRowVersion().IsRequired();
            builder.Property(e => e.F_DEL).HasDefaultValue(byte.MinValue).IsRequired();

            builder.HasIndex(x => x.F_ID).IsClustered().IsUnique().HasDatabaseName("F_ID");
        }
    }
}