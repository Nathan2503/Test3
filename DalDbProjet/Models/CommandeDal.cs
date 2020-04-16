﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalDbProjet.Models
{
    public class CommandeDal
    {
        public int commandeId { get; set; }
        public DateTime commandeDate { get; set; }
        public int commandeQuantite { get; set; }
        public string clientLogin { get; set; }
        public string biereNom { get; set; }
        public decimal bierePrix { get; set; } 
    }
}
