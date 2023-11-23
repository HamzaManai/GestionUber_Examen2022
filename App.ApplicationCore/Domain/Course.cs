using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Domain
{
    public class Course
    {
        public DateTime DateCourse { get; set; }
        public string LieuDepart { get; set; }
        public string LieuArrive { get; set; }
        public double Montant { get; set; }
        public bool PaiementEnLigne { get; set; }
        public Etat Etat { get; set; }
        public string VoitureId { get; set; }
        public virtual Voiture Voiture { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}