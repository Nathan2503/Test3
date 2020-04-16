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
    public class EvenementController : ApiController
    {
        private EvenementDalService evenementDalService =  EvenementDalService.GetLoadBalancer();
        public List<EvenementAPI> Get()
        {
            return evenementDalService.GetAll().Select(p => p.GetEvenementAPI()).ToList();
        }
    }
}
