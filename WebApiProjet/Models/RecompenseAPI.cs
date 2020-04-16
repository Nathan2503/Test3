using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProjet.Models
{
    public class RecompenseAPI
    {
        public int recompenseId { get; set; }
        public string recompenseNom { get; set; }
        public int biereId { get; set; }
    }
}