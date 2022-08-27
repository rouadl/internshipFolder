using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Domain.Entities
{
   public class Medecin
    {
        public int MedecinId { get; set; }
        public string CodeMedecin { get; set; }
        public string NomMedecin { get; set; }
        public string Specialite { get; set; }


        public virtual IList<Consultation> Consultations { get; set; }
    }
}
