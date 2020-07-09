using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Commentaire
    {
        [Key]
        public Guid IdCom { get; set; }

        public string Description { get; set; }

        //relation entre Vote et commentaire

        public ICollection<Comm_Vote> Comm_Votes { get; set; }

        //relation entre demande d'info et commentaire


        public Demande_information demande_Information { get; set; }

        public Guid IdQuestion { get; set; }
    }
}
