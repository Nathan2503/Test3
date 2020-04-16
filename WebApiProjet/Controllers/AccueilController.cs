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
    public class AccueilController : ApiController
    {
        private AccueilService accueilService =  AccueilService.GetLoadBalancer();
        public List<AccueilAPI> GET()
        {
            return accueilService.GetAll().Select(a => a.GetAccueilAPI()).ToList();
        }
        public AccueilAPI Get(int id)
        {
            return accueilService.GetOne(id).GetAccueilAPI();
        }

    }
}
