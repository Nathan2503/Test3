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
    public class BiereController : ApiController
    {
        private BiereDalService biereDalService =  BiereDalService.GetLoadBalancer();
        public List<BiereAPI> Get()
        {
            return biereDalService.GetAll().Select(p => p.GetBiereAPI()).ToList();
        }
        public BiereAPI Get(int id)
        {
            return biereDalService.GetOne(id).GetBiereAPI();
        }
        [AcceptVerbs("GET")]
        public BiereAPI GetByName(string name)
        {
            return biereDalService.getByName(name).GetBiereAPI();
        }
    }
}
