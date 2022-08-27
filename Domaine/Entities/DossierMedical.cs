using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GP.Domain.Entities
{
   public class DossierMedical
    {
        [Key]
        public int CIN { get; set; }
        public string NomPatient { get; set; }
        public string PrenomPatient { get; set; }
        public string Maladies { get; set; }

        public virtual IList<Patient> Patients { get; set; }
    }
}
