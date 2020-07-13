using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Dto
{
    public class CommentaireQuestionDto
    {
        public Guid IdCom { get; set; }

        public string Description { get; set; }

        public Guid IdQuestion { get; set; }

        public string nameQuestion { get; set; }
    }
}
