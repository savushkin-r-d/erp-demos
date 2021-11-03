using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZTTN_API",
                columns: table => new
                {
                    F_GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    SYSN = table.Column<decimal>(type: "numeric(12,0)", precision: 12, scale: 0, nullable: false),
                    TD = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    ND = table.Column<decimal>(type: "numeric(9,0)", precision: 9, scale: 0, nullable: false, defaultValue: 0m),
                    DT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1899, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    KPL = table.Column<string>(type: "char(8)", maxLength: 8, nullable: false, defaultValue: ""),
                    KPP = table.Column<string>(type: "char(8)", maxLength: 8, nullable: false, defaultValue: ""),
                    PD = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    OKPO = table.Column<string>(type: "char(12)", maxLength: 12, nullable: true),
                    UNN = table.Column<string>(type: "char(12)", maxLength: 12, nullable: true),
                    ATP = table.Column<string>(type: "char(100)", maxLength: 100, nullable: true),
                    AVT = table.Column<string>(type: "char(32)", maxLength: 32, nullable: true),
                    VOD = table.Column<string>(type: "char(30)", maxLength: 30, nullable: true),
                    KEKS = table.Column<decimal>(type: "numeric(5,0)", precision: 5, scale: 0, nullable: false, defaultValue: 0m),
                    EKS = table.Column<string>(type: "char(30)", maxLength: 30, nullable: true),
                    SUMP = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SUMT = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SUMD = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SUMAM = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    NSV = table.Column<decimal>(type: "numeric(12,0)", precision: 12, scale: 0, nullable: false, defaultValue: 0m),
                    KSMEN = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false, defaultValue: ""),
                    NDOV = table.Column<decimal>(type: "numeric(10,0)", precision: 10, scale: 0, nullable: true),
                    DTDOV = table.Column<DateTime>(type: "datetime", nullable: true),
                    FIODOV = table.Column<string>(type: "char(20)", maxLength: 20, nullable: true),
                    NR = table.Column<decimal>(type: "numeric(3,0)", precision: 3, scale: 0, nullable: false, defaultValue: 0m),
                    KATP = table.Column<decimal>(type: "numeric(5,0)", precision: 5, scale: 0, nullable: true),
                    TABN = table.Column<decimal>(type: "numeric(12,0)", precision: 12, scale: 0, nullable: true),
                    KSK = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    KAVT = table.Column<string>(type: "char(12)", maxLength: 12, nullable: true),
                    NPR = table.Column<string>(type: "char(7)", maxLength: 7, nullable: true),
                    SUMNDS = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SUMOP = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    KOLM = table.Column<decimal>(type: "numeric(7,0)", precision: 7, scale: 0, nullable: true),
                    VB = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: true),
                    SUMNC = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    PCS = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    SUM10 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SUM20 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    NDS10 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    NDS20 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    NUMPL = table.Column<decimal>(type: "numeric(9,0)", precision: 9, scale: 0, nullable: true),
                    KDETD = table.Column<decimal>(type: "numeric(3,0)", precision: 3, scale: 0, nullable: true),
                    SUMST = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    VR = table.Column<decimal>(type: "numeric(3,0)", precision: 3, scale: 0, nullable: true),
                    PS = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    DTV = table.Column<DateTime>(type: "datetime", nullable: true),
                    SROP = table.Column<decimal>(type: "numeric(3,0)", precision: 3, scale: 0, nullable: true),
                    KV = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    KURS = table.Column<decimal>(type: "numeric(16,8)", precision: 16, scale: 8, nullable: true),
                    CPT = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    VSUMP = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    VSUMT = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    VSUMD = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    V_SUMNDS = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    V_SUM10 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    V_SUM20 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    V_NDS10 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    V_NDS20 = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    SNSCP = table.Column<decimal>(type: "numeric(9,0)", precision: 9, scale: 0, nullable: true),
                    VSUMOP = table.Column<decimal>(type: "numeric(16,4)", precision: 16, scale: 4, nullable: true),
                    TIME = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    CR_KPL = table.Column<string>(type: "char(8)", maxLength: 8, nullable: true),
                    CR_KPP = table.Column<string>(type: "char(8)", maxLength: 8, nullable: true),
                    CR_USER = table.Column<string>(type: "char(15)", maxLength: 15, nullable: true),
                    F_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_TM = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    F_DEL = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("F_GUID_BD_ZTTN_API", x => x.F_GUID)
                        .Annotation("SqlServer:Clustered", false);
                    table.UniqueConstraint("AK_ZTTN_API_SYSN", x => x.SYSN);
                });

            migrationBuilder.CreateTable(
                name: "STTN_API",
                columns: table => new
                {
                    F_GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    SYSN = table.Column<decimal>(type: "numeric(12,0)", precision: 12, scale: 0, nullable: false),
                    KMC = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: false),
                    NMC = table.Column<string>(type: "char(35)", maxLength: 35, nullable: true),
                    KT = table.Column<string>(type: "char(10)", maxLength: 10, nullable: true),
                    NMT = table.Column<string>(type: "char(7)", maxLength: 7, nullable: true),
                    EMK = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: true),
                    ED = table.Column<string>(type: "char(5)", maxLength: 5, nullable: true),
                    KOLM = table.Column<decimal>(type: "numeric(7,3)", precision: 7, scale: 3, nullable: true),
                    KOLE = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: true),
                    VB = table.Column<decimal>(type: "numeric(10,3)", precision: 10, scale: 3, nullable: true),
                    CENA = table.Column<decimal>(type: "numeric(16,8)", precision: 16, scale: 8, nullable: true),
                    SNDS = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    SUMP = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    SUMNDS = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    SUMIT = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    PAM = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SUMAM = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    DTV = table.Column<DateTime>(type: "datetime", nullable: true),
                    VRV = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: true),
                    SRR = table.Column<decimal>(type: "numeric(5,0)", precision: 5, scale: 0, nullable: true),
                    SERT = table.Column<string>(type: "char(35)", maxLength: 35, nullable: true),
                    PRC = table.Column<string>(type: "char(35)", maxLength: 35, nullable: true),
                    KVC = table.Column<decimal>(type: "numeric(3,0)", precision: 3, scale: 0, nullable: true),
                    PAV = table.Column<decimal>(type: "numeric(2,0)", precision: 2, scale: 0, nullable: false, defaultValue: 0m),
                    PNC = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true),
                    SUMNC = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    CENT = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    KPL = table.Column<string>(type: "char(8)", maxLength: 8, nullable: true),
                    NUK = table.Column<decimal>(type: "numeric(9,0)", precision: 9, scale: 0, nullable: true),
                    VCENA = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    VSUMP = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    VSUMNDS = table.Column<decimal>(type: "numeric(17,4)", precision: 17, scale: 4, nullable: true),
                    F_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_TM = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    F_DEL = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("F_GUID_BD_STTN_API", x => x.F_GUID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_STTN_API_ZTTN_API_SYSN",
                        column: x => x.SYSN,
                        principalTable: "ZTTN_API",
                        principalColumn: "SYSN");
                });

            migrationBuilder.CreateIndex(
                name: "F_ID",
                table: "STTN_API",
                column: "F_ID",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "SYSN",
                table: "STTN_API",
                column: "SYSN");

            migrationBuilder.CreateIndex(
                name: "DTKPL",
                table: "ZTTN_API",
                column: "DT")
                .Annotation("SqlServer:Include", new[] { "KPL" });

            migrationBuilder.CreateIndex(
                name: "F_ID",
                table: "ZTTN_API",
                column: "F_ID",
                unique: true)
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "ND",
                table: "ZTTN_API",
                column: "ND");

            migrationBuilder.CreateIndex(
                name: "NSV",
                table: "ZTTN_API",
                column: "NSV");

            migrationBuilder.CreateIndex(
                name: "PL_D",
                table: "ZTTN_API",
                column: "KPL")
                .Annotation("SqlServer:Include", new[] { "F_ID" });

            migrationBuilder.CreateIndex(
                name: "SYSN",
                table: "ZTTN_API",
                column: "SYSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STTN_API");

            migrationBuilder.DropTable(
                name: "ZTTN_API");
        }
    }
}
