using API.Mapping;
using AutoMapper;
using Domain;

namespace API.DTO
{
    public class ZttnDTO : EntityBaseDTO, IMapWith<ZttnDTO>
    {
        public decimal SYSN { get; set; }

        public decimal? TD { get; set; }

        public decimal ND { get; set; }

        public DateTime DT { get; set; }

        public string KPL { get; set; }

        public string KPP { get; set; }

        public decimal? PD { get; set; }

        public string OKPO { get; set; }

        public string UNN { get; set; }

        public string ATP { get; set; }

        public string AVT { get; set; }

        public string VOD { get; set; }

        public decimal KEKS { get; set; }

        public string EKS { get; set; }

        public decimal? SUMP { get; set; }

        public decimal? SUMT { get; set; }

        public decimal? SUMD { get; set; }

        public decimal? SUMAM { get; set; }

        public decimal NSV { get; set; }

        public string KSMEN { get; set; }

        public decimal? NDOV { get; set; }

        public DateTime? DTDOV { get; set; }

        public string FIODOV { get; set; }

        public decimal NR { get; set; }

        public decimal? KATP { get; set; }

        public decimal? TABN { get; set; }

        public string KSK { get; set; }

        public string KAVT { get; set; }

        public string NPR { get; set; }

        public decimal? SUMNDS { get; set; }

        public decimal? SUMOP { get; set; }

        public decimal? KOLM { get; set; }

        public decimal? VB { get; set; }

        public decimal? SUMNC { get; set; }

        public decimal? PCS { get; set; }

        public decimal? SUM10 { get; set; }

        public decimal? SUM20 { get; set; }

        public decimal? NDS10 { get; set; }

        public decimal? NDS20 { get; set; }

        public decimal? NUMPL { get; set; }

        public decimal? KDETD { get; set; }

        public decimal? SUMST { get; set; }

        public decimal? VR { get; set; }

        public decimal? PS { get; set; }

        public DateTime? DTV { get; set; }

        public decimal? SROP { get; set; }

        public string KV { get; set; }

        public decimal? KURS { get; set; }

        public decimal? CPT { get; set; }

        public decimal? VSUMP { get; set; }

        public decimal? VSUMT { get; set; }

        public decimal? VSUMD { get; set; }

        public decimal? V_SUMNDS { get; set; }

        public decimal? V_SUM10 { get; set; }

        public decimal? V_SUM20 { get; set; }

        public decimal? V_NDS10 { get; set; }

        public decimal? V_NDS20 { get; set; }

        public decimal? SNSCP { get; set; }

        public decimal? VSUMOP { get; set; }

        public decimal? TIME { get; set; }

        public string CR_KPL { get; set; }

        public string CR_KPP { get; set; }

        public string CR_USER { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ZttnDTO, Zttn>();
            profile.CreateMap<Zttn, ZttnDTO>();
        }
    }
}