using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
   public class Categorie
    {
         [Key]
        public Guid IdCategorie { get; set; }

        public string Label { get; set; }
        //relation entre Demande et categorie

        public virtual ICollection<Dem_Categorie> Dem_Categories { get; set; }

        //relation entre categories et sous categories
        public ICollection<sous_categorie> Sous_categories { get; set; }


    }

}
