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
                cfg.CreateMap<LoLesports.Data.Jatekos, LoLesports.Web.Models.Jatekos>();
            });
            return config.CreateMapper();
        }
    }
}