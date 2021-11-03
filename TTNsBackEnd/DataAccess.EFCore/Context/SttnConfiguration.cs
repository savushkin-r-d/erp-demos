using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.EFCore.FluentHelper;

namespace DataAccess.EFCore
{
    public class SttnConfiguration : EntityBaseConfiguration<Sttn>
    {
        public override void Configure(EntityTypeBuilder<Sttn> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.SYSN).HasColumnType(SqlType.Numeric).HasPrecision(12, 0).IsRequired();
            builder.Property(e => e.KMC).HasColumnType(SqlType.Char).HasMaxLength(10).IsFixedLength().IsRequired();
            builder.Property(e => e.NMC).HasColumnType(SqlType.Char).HasMaxLength(35);
            builder.Property(e => e.KT).HasColumnType(SqlType.Char).HasMaxLength(10);
            builder.Property(e => e.NMT).HasColumnType(SqlType.Char).HasMaxLength(7);
            builder.Property(e => e.EMK).HasColumnType(SqlType.Numeric).HasPrecision(10, 3);
            builder.Property(e => e.ED).HasColumnType(SqlType.Char).HasMaxLength(5);
            builder.Property(e => e.KOLM).HasColumnType(SqlType.Numeric).HasPrecision(7, 3);
            builder.Property(e => e.KOLE).HasColumnType(SqlType.Numeric).HasPrecision(10, 3);
            builder.Property(e => e.VB).HasColumnType(SqlType.Numeric).HasPrecision(10, 3);
            builder.Property(e => e.CENA).HasColumnType(SqlType.Numeric).HasPrecision(16, 8);
            builder.Property(e => e.SNDS).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.SUMP).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.SUMNDS).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.SUMIT).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.PAM).HasColumnType(SqlType.Numeric).HasPrecision(5, 2);
            builder.Property(e => e.SUMAM).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.DTV).HasColumnType(SqlType.DateTime);
            builder.Property(e => e.VRV).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.SRR).HasColumnType(SqlType.Numeric).HasPrecision(5, 0);
            builder.Property(e => e.SERT).HasColumnType(SqlType.Char).HasMaxLength(35);
            builder.Property(e => e.PRC).HasColumnType(SqlType.Char).HasMaxLength(35);
            builder.Property(e => e.KVC).HasColumnType(SqlType.Numeric).HasPrecision(3, 0);
            builder.Property(e => e.PAV).HasColumnType(SqlType.Numeric).HasPrecision(2, 0).HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.PNC).HasColumnType(SqlType.Numeric).HasPrecision(5, 2);
            builder.Property(e => e.SUMNC).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.CENT).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.KPL).HasColumnType(SqlType.Char).HasMaxLength(8);
            builder.Property(e => e.NUK).HasColumnType(SqlType.Numeric).HasPrecision(9, 0);
            builder.Property(e => e.VCENA).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.VSUMP).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);
            builder.Property(e => e.VSUMNDS).HasColumnType(SqlType.Numeric).HasPrecision(17, 4);

            builder.HasIndex(x => x.SYSN).HasDatabaseName("SYSN");

            builder.ToTable("STTN_API");
        }
    }
}