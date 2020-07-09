using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Demande_information
    {

        [Key]
        public Guid IdInf { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        //relation entre Categorie et demande d'info
        public virtual ICollection<Dem_Categorie> Dem_Categories { get; set; }

        //relation entre commentaire et demande d'info
        public ICollection<Commentaire> commentaires { get; set; }


    }
}
