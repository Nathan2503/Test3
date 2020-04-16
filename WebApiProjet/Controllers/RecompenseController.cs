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
    public class RecompenseController : ApiController
    {
        private RecompenseDalService dalService =  RecompenseDalService.GetLoadBalancer();
        public List<RecompenseAPI> Get(int id)
        {
            return dalService.GetAll(id).Select(p => p.GetRecompenseAPI()).ToList();
        }
    }
}
