using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoLesports.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LoLesports.Data.Jatekos, LoLesports.Web.Models.Jatekos>().
                 ForMember(dest => dest.Felhasznalonev, map => map.MapFrom(src => src.Felhasznalonev)).
                 ForMember(dest => dest.Vezeteknev, map => map.MapFrom(src => src.Vezeteknev)).
                 ForMember(dest => dest.Keresztnev, map => map.MapFrom(src => src.Keresztnev)).
                 ForMember(dest => dest.Eletkor, map => map.MapFrom(src => src.Eletkor)).
                 ForMember(dest => dest.Pozicio, map => map.MapFrom(src => src.Pozicio)).
                 ForMember(dest => dest.Nemzetiseg, map => map.MapFrom(src => src.Nemzetiseg)).
                 ForMember(dest => dest.Csapatnev, map => map.MapFrom(src => src.Csapatnev));
            });
            return config.CreateMapper();
        }
    }
}