using E_Learning_Platform.Core.Entities.Operations;
using E_Learning_Platform.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Learning_Platform.Infrastracture.Data.Configurations
{
    public class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.HasKey(s => new { s.StudentId, s.SessionId });
            builder.Property(x => x.AttendanceStatus).HasConversion<string>();
            builder
                .HasOne(St => St.Student)
                .WithMany(At => At.StudentAttendances)
                .HasForeignKey(StudAtt => StudAtt.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(User => User.RecordedByUser)
                .WithMany()
                .HasForeignKey(StudAtt => StudAtt.RecordedByUserId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(Sess => Sess.Session)
                .WithMany(S => S.StudentAttendances)
                .HasForeignKey(S => S.SessionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
