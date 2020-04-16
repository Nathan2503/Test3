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
    public class ContactController : ApiController
    {
        private ContactDalService contactDalService =  ContactDalService.GetLoadBalancer();
        public List<ContactAPI> Get()
        {
            return contactDalService.GetAll().Select(p => p.GetContactAPI()).ToList();
        }
    }
}
