using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GP.Domain.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public int DossierMedicalFK { get; set; }
        [Required]
        public string Nom{ get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public DateTime DatedeNaissaonce { get; set; }
        public string ville { get; set; }
        public string adress { get; set; }
        public string sexe { get; set; }
        [Required]
        public long Tele { get; set; }
        [Required, EmailAddress]
        public string mail { get; set; }


        public virtual IList<Consultation> Consultations { get; set; }
        public virtual DossierMedical Dossier { get; set; }
    }
}
