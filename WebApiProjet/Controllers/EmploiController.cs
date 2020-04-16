using DalDbProjet.Models;
using DalDbProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProjet.Models;
using WebApiProjet.Tools;

namespace WebApiProjet.Controllers
{
    public class EmploiController : ApiController
    {
        private OffreEmploiDalService offreEmploiDalService = OffreEmploiDalService.GetLoadBalancer();
        public List<OffreEmploiAPI> Get()
        {
            return offreEmploiDalService.GetAll().Select(p => p.GetEmploiAPI()).ToList();
        }
        public OffreEmploiAPI Get(int id)
        {
            return offreEmploiDalService.GetOne(id).GetEmploiAPI();
        }
    }
}
