using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemModel.Models
{
    public class BatchParticipantAss
    {
        public int Id { get; set; }

        public int BatchId { get; set; }

        public int ParticipantId { get; set; }

        public Participant Participant { get; set; }
        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public string Profession { get; set; }
        [NotMapped]
        public virtual List<BatchParticipantAss> BatchPartiAssList { get; set; }
    }
}
