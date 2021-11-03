using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.EFCore.FluentHelper;

namespace DataAccess.EFCore
{
    public class ZttnConfiguration : EntityBaseConfiguration<Zttn>
    {
        public override void Configure(EntityTypeBuilder<Zttn> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.SYSN).HasColumnType(SqlType.Numeric).HasPrecision(12, 0).IsRequired();
            builder.Property(e => e.TD).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.ND).HasColumnType(SqlType.Numeric).HasPrecision(9, 0).HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.DT).HasDefaultValue("1899-12-30T00:00:00.0000000").IsRequired();
            builder.Property(e => e.KPL).HasColumnType(SqlType.Char).HasMaxLength(8).HasDefaultValue(string.Empty)
                .IsRequired();
            builder.Property(e => e.KPP).HasColumnType(SqlType.Char).HasMaxLength(8).HasDefaultValue(string.Empty)
                .IsRequired();
            builder.Property(e => e.PD).HasColumnType(SqlType.Numeric).HasPrecision(5, 2);
            builder.Property(e => e.OKPO).HasColumnType(SqlType.Char).HasMaxLength(12);
            builder.Property(e => e.UNN).HasColumnType(SqlType.Char).HasMaxLength(12);
            builder.Property(e => e.ATP).HasColumnType(SqlType.Char).HasMaxLength(100);
            builder.Property(e => e.AVT).HasColumnType(SqlType.Char).HasMaxLength(32);
            builder.Property(e => e.VOD).HasColumnType(SqlType.Char).HasMaxLength(30);
            builder.Property(e => e.KEKS).HasColumnType(SqlType.Numeric).HasPrecision(5, 0).HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.EKS).HasColumnType(SqlType.Char).HasMaxLength(30);
            builder.Property(e => e.SUMP).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SUMT).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SUMD).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SUMAM).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.NSV).HasColumnType(SqlType.Numeric).HasPrecision(12, 0).HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.KSMEN).HasColumnType(SqlType.Char).HasMaxLength(3).HasDefaultValue(string.Empty)
                .IsRequired();
            builder.Property(e => e.NDOV).HasColumnType(SqlType.Numeric).HasPrecision(10, 0);
            builder.Property(e => e.DTDOV).HasColumnType(SqlType.DateTime);
            builder.Property(e => e.FIODOV).HasColumnType(SqlType.Char).HasMaxLength(20);
            builder.Property(e => e.NR).HasColumnType(SqlType.Numeric).HasPrecision(3, 0).HasDefaultValue(0)
                .IsRequired();
            builder.Property(e => e.KATP).HasColumnType(SqlType.Numeric).HasPrecision(5, 0);
            builder.Property(e => e.TABN).HasColumnType(SqlType.Numeric).HasPrecision(12, 0);
            builder.Property(e => e.KSK).HasColumnType(SqlType.Char).HasMaxLength(10);
            builder.Property(e => e.KAVT).HasColumnType(SqlType.Char).HasMaxLength(12);
            builder.Property(e => e.NPR).HasColumnType(SqlType.Char).HasMaxLength(7);
            builder.Property(e => e.SUMNDS).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SUMOP).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.KOLM).HasColumnType(SqlType.Numeric).HasPrecision(7, 0);
            builder.Property(e => e.VB).HasColumnType(SqlType.Numeric).HasPrecision(10, 3);
            builder.Property(e => e.SUMNC).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.PCS).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.SUM10).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SUM20).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.NDS10).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.NDS20).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.NUMPL).HasColumnType(SqlType.Numeric).HasPrecision(9, 0);
            builder.Property(e => e.KDETD).HasColumnType(SqlType.Numeric).HasPrecision(3, 0);
            builder.Property(e => e.SUMST).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.VR).HasColumnType(SqlType.Numeric).HasPrecision(3, 0);
            builder.Property(e => e.PS).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.DTV).HasColumnType(SqlType.DateTime);
            builder.Property(e => e.SROP).HasColumnType(SqlType.Numeric).HasPrecision(3, 0);
            builder.Property(e => e.KV).HasColumnType(SqlType.Char).HasMaxLength(3);
            builder.Property(e => e.KURS).HasColumnType(SqlType.Numeric).HasPrecision(16, 8);
            builder.Property(e => e.CPT).HasColumnType(SqlType.Numeric).HasPrecision(2, 0);
            builder.Property(e => e.VSUMP).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.VSUMT).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.VSUMD).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.V_SUMNDS).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.V_SUM10).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.V_SUM20).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.V_NDS10).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.V_NDS20).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.SNSCP).HasColumnType(SqlType.Numeric).HasPrecision(9, 0);
            builder.Property(e => e.VSUMOP).HasColumnType(SqlType.Numeric).HasPrecision(16, 4);
            builder.Property(e => e.TIME).HasColumnType(SqlType.Numeric).HasPrecision(5, 2);
            builder.Property(e => e.CR_KPL).HasColumnType(SqlType.Char).HasMaxLength(8);
            builder.Property(e => e.CR_KPP).HasColumnType(SqlType.Char).HasMaxLength(8);
            builder.Property(e => e.CR_USER).HasColumnType(SqlType.Char).HasMaxLength(15);

            builder.HasIndex(x => x.DT).HasDatabaseName("DT");
            builder.HasIndex(x => x.DT).IncludeProperties(x => x.KPL).HasDatabaseName("DTKPL");
            builder.HasIndex(x => x.ND).HasDatabaseName("ND");
            builder.HasIndex(x => x.NSV).HasDatabaseName("NSV");
            builder.HasIndex(x => x.KPL).IncludeProperties(x => x.DT).IncludeProperties(x => x.F_ID)
                .HasDatabaseName("PL_D");
            builder.HasIndex(x => x.SYSN).HasDatabaseName("SYSN");

            builder.HasMany(x => x.Sttns).WithOne(y => y.Zttn).HasPrincipalKey("SYSN").HasForeignKey("SYSN")
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("ZTTN_API");
        }
    }
}