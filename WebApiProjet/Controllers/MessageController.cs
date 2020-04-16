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
    public class MessageController : ApiController
    {
        private MessageDalService messageDalService =  MessageDalService.GetLoadBalancer();
        public List<MessageAPI> Get()
        {
            return messageDalService.GetAll().Select(p => p.GetMessageAPI()).ToList();
        }
    }
}
