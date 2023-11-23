using App.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationCore.Interfaces
{
    public interface ICourseService : IService<Course>
    {
        IEnumerable<Course> GetPayedCourses(Chauffeur chauffeur, DateTime date);
        double GetBenefice(Chauffeur chauffeur, DateTime date);
    }
}
