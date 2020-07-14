using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Dto
{
    public class SousCategorieQuestionDto
    {
        public Guid IdSC { get; set; }

        public string Label { get; set; }

        public Guid CategorieFK { get; set; }

        public string nameCategorie{ get; set; }


    }
}
