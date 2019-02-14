using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using ExamSystemModel.Models;
using OnlineExamSystem.Models;

namespace OnlineExamSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrganizationCreateForView, Organization>();
                cfg.CreateMap<Organization, OrganizationCreateForView>();
                cfg.CreateMap<CourseCreateForView, Course>();
                cfg.CreateMap<Course, CourseCreateForView>();
                cfg.CreateMap<BatchEntryCreateForView, Batch>();
                cfg.CreateMap<Batch, BatchEntryCreateForView>();
                cfg.CreateMap<ExamEntryForView, Exam>();
                cfg.CreateMap<Exam, ExamEntryForView>();
                cfg.CreateMap<ParticipantCreateForView, Participant>();
                cfg.CreateMap<Participant, ParticipantCreateForView>();
                cfg.CreateMap<TrainerCreateForPV, Trainer>();
                cfg.CreateMap<Trainer, TrainerCreateForPV>();
                cfg.CreateMap<QuestionCreateForView, Question>();
                cfg.CreateMap<Question, QuestionCreateForView>();
            });
        }
    }
}
