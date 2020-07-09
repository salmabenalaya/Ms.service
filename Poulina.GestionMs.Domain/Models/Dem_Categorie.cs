using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Dem_Categorie
    {
        [Key]
        public Guid Id { get; set; }
        public virtual Demande_information Demande_information { get; set; }
        public Guid IdInf { get; set; }
        public virtual Categorie Categories { get; set; }
        public Guid IdCategorie { get; set; }

    }
}
