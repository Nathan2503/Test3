using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProjet.Models
{
    public class AccueilAPI
    {
        public int brasserieId { get; set; }
        public string nomBrasserie { get; set; }
        public string brasseriePresentation { get; set; }
        public DateTime horraireDateDebut { get; set; }
        public DateTime horraireDateFin { get; set; }
        public string heureOuverture { get; set; }
        public string heureFermeture { get; set; }
    }
}