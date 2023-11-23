using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class VoitureService : Service<Voiture>, IVoitureService
    {
        public VoitureService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
        public Voiture GetMustDemanded()
        {
            int max = GetAll().Max(e => e.Courses.Count);
            return GetMany(e => e.Courses.Count >= max).FirstOrDefault();
        }
    }
}
