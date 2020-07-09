using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class sous_categorie
    {
        [Key]
        public Guid IdSC { get; set; }

        public string Label { get; set; }
        public Categorie  Categorie{ get; set; }

        public Guid CategorieFK { get; set; }

    }
}
