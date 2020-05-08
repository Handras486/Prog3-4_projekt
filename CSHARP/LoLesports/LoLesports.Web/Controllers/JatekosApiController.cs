using AutoMapper;
using LoLesports.Logic;
using LoLesports.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoLesports.Web.Controllers
{
    public class JatekosApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        IJatekosLogic jatekosLogic;
        IMapper mapper;

        public JatekosApiController()
        {
            jatekosLogic = new JatekosLogic();
            mapper = MapperFactory.CreateMapper();
        }

        // GET api/JatekosApi/all
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Models.Jatekos> GetAll()
        {
            var jatekosok = jatekosLogic.GetAll();
            return mapper.Map<IList<Data.Jatekos>, List<Models.Jatekos>>(jatekosok);
        }

        //api/JatekosApi/del/felhasznalonev
        [ActionName("del")]
        [HttpGet]
        public ApiResult DeleteOneJatekos(string felhasznalonev)
        {
            return new ApiResult() { OperationResult = jatekosLogic.DeleteJatekosElement(felhasznalonev) };
        }

        //api/JatekosApi/add + jatekos
        [ActionName("add")]
        [HttpPost]
        public ApiResult AddOneJatekos(Jatekos jatekos)
        {
            List<object> jatekoslist = new List<object>();
            jatekoslist.Add(jatekos.Felhasznalonev);
            jatekoslist.Add(jatekos.Vezeteknev);
            jatekoslist.Add(jatekos.Keresztnev);
            jatekoslist.Add(jatekos.Eletkor);
            jatekoslist.Add(jatekos.Pozicio);
            jatekoslist.Add(jatekos.Nemzetiseg);
            jatekoslist.Add(jatekos.Csapatnev);

            bool success = jatekosLogic.CreateJatekosElement(jatekoslist);
            return new ApiResult() { OperationResult = success };
        }

        //api/JatekosApi/mod + jatekos
        [ActionName("mod")]
        [HttpPost]
        public ApiResult ModOneJatekos(Jatekos jatekos)
        {
            List<object> jatekoslist = new List<object>();
            jatekoslist.Add(jatekos.Felhasznalonev);
            jatekoslist.Add(jatekos.Vezeteknev);
            jatekoslist.Add(jatekos.Keresztnev);
            jatekoslist.Add(jatekos.Eletkor);
            jatekoslist.Add(jatekos.Pozicio);
            jatekoslist.Add(jatekos.Nemzetiseg);
            jatekoslist.Add(jatekos.Csapatnev);

            bool success = jatekosLogic.UpdateJatekosElement(jatekoslist);
            return new ApiResult() { OperationResult = true };
        }
    }
}
