using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamSystemModel.Models;

namespace ExamSystemDataBaseContext.DataBaseContext
{
    public class OnlineExamDb:DbContext
    {
        public DbSet<Organization> Organizationss { get; set; }
        public DbSet<Course> Coursess { get; set; }
        public DbSet<Batch> Batchss { get; set; }
        public DbSet<Trainer> Trainerss { get; set; }
        public DbSet<Participant> Participantss { get; set; }
        public DbSet<Exam> Examss { get; set; }
        public DbSet<CourseAssing> CourseAssingss { get; set; }
        public DbSet<BatchParticipantAss> BatchPartiAss { get; set; }
        public DbSet<BatchTrainerAss> BatchTrainerAss { get; set; }
        public DbSet<ExamType> ExamTypess { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QOption> QOptions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<UserLogin> users { get; set; }
        public DbSet<AdminLogIn> Admins { get; set; }
    }
}
