using DalDbProjet.Models;
using DalDbProjet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiProjet.Helper;
using WebApiProjet.Models;
using WebApiProjet.Tools;

namespace WebApiProjet.Controllers
{
    public class CommandController : ApiController
    {
        private CommandDalService commandDalService =  CommandDalService.GetLoadBalancer();
        [Auth()]
        public List<CommandeAPI> Get()
        {
            return commandDalService.GetAll().Select(p => p.GetCommandeAPI()).ToList();
        }
        [Auth()]
        public CommandeAPI Get(int id)
        {
            return commandDalService.GetOne(id).GetCommandeAPI();
        }
        [Auth()]
        public List<CommandeAPI> Get(string login)
        {
            return commandDalService.GetByLogin(login).Select(p => p.GetCommandeAPI()).ToList();
        }
        [Auth()]
        public void Post(CommandeAPI commandeAPI)
        {
            commandDalService.Create(commandeAPI.GetCommandeDal());
        }
    }
}
