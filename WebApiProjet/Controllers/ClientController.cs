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
    public class ClientController : ApiController
    {
        private ClientDalService clientDalService =  ClientDalService.GetLoadBalancer();
        [Auth()]
        public List<ClientAPI> Get()
        {
            return clientDalService.GetAll().Select(c => c.GetClientAPI()).ToList();
        }
        [Auth()]
        public ClientAPI Get(int id)
        {
            return clientDalService.GetOne(id).GetClientAPI();
        }
        [Auth()]
        public void Post(ClientAPI clientAPI)
        {
            clientDalService.Create(clientAPI.GetClientDal());
        }
        [Auth()]
        public void PUT(ClientAPI clientAPI)
        {
            clientDalService.Update(clientAPI.GetClientDal());
        }
        [Auth()]
        public void Delete(int id)
        {
            clientDalService.Delete(id);
        }
        [Auth()]
        public int? Get(string login,string pwd)
        {
           int? id =clientDalService.Connection(login, pwd);
            return id;
        }
    }
}
