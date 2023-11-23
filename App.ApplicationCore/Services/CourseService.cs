using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
        public double GetBenefice(Chauffeur chauffeur, DateTime date)
        {
            return GetPayedCourses(chauffeur, date).Sum(e => e.Montant * chauffeur.TauxBenefice);
        }
        public IEnumerable<Course> GetPayedCourses(Chauffeur chauffeur, DateTime date)
        {
            return GetMany(e => e.Etat == Etat.Payee && e.Voiture == chauffeur.Voiture && e.DateCourse.Date == date.Date);
        }
    }
}
