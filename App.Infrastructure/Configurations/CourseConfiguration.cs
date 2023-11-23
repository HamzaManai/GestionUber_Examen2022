using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    internal class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasOne(e => e.Voiture).WithMany(e => e.Courses).HasForeignKey(e => e.VoitureId);
            builder.HasOne(e => e.Client).WithMany(e => e.Courses).HasForeignKey(e => e.ClientId);
            builder.HasKey(e => new { e.VoitureId, e.ClientId, e.DateCourse });
        }
    }
}
