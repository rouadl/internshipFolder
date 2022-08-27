using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
namespace GP.Domain.Entities
{
     public class Consultation
    {
        [Key]
        public int CodeConsultation { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime RendezVous { get; set; }
        public string Motif { get; set; }
        public string MedecinFK { get; set; }
        public int PatientFK { get; set; }

        public virtual Patient Patients { get; set; }
        public virtual Medecin Medecins { get; set; }
    }
}
