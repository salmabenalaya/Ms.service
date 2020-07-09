using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poulina.GestionMs.Domain.Models
{
    public class Vote
    {
        [Key]
        public Guid IdVote { get; set; }

        public string Note { get; set; }

        public ICollection<Comm_Vote> Comm_Votes { get; set; }
    }
}
