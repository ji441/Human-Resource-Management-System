﻿// <auto-generated />
using System;
using Interview.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Interview.Infrastructure.Migrations
{
    [DbContext(typeof(InterviewDbContext))]
    partial class InterviewDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Interview.AppCore.Entities.InterviewFeedback", b =>
                {
                    b.Property<int>("InterviewFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterviewFeedbackId"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("InterviewFeedbackId");

                    b.ToTable("InterviewFeedbacks");
                });

            modelBuilder.Entity("Interview.AppCore.Entities.InterviewRecord", b =>
                {
                    b.Property<int>("InterviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterviewId"));

                    b.Property<int>("FeedbackId")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewFeedbackId")
                        .HasColumnType("int");

                    b.Property<int>("InterviewRound")
                        .HasColumnType("int");

                    b.Property<int>("InterviewTypeCode")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewTypeLookupCode")
                        .HasColumnType("int");

                    b.Property<int>("InterviewerId")
                        .HasColumnType("int");

                    b.Property<int>("RecruiterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ScheduledOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubmissionId")
                        .HasColumnType("int");

                    b.HasKey("InterviewId");

                    b.HasIndex("InterviewFeedbackId");

                    b.HasIndex("InterviewTypeLookupCode");

                    b.HasIndex("InterviewerId");

                    b.HasIndex("RecruiterId");

                    b.ToTable("InterviewRecords");
                });

            modelBuilder.Entity("Interview.AppCore.Entities.InterviewType", b =>
                {
                    b.Property<int>("LookupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LookupCode"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("LookupCode");

                    b.ToTable("InterviewTypes");
                });

            modelBuilder.Entity("Interview.AppCore.Entities.Interviewer", b =>
                {
                    b.Property<int>("InterviewerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterviewerId"));

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("InterviewerId");

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("Interview.AppCore.Entities.Recruiter", b =>
                {
                    b.Property<int>("RecruiterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecruiterId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("RecruiterId");

                    b.ToTable("Recruiters");
                });

            modelBuilder.Entity("Interview.AppCore.Entities.InterviewRecord", b =>
                {
                    b.HasOne("Interview.AppCore.Entities.InterviewFeedback", "InterviewFeedback")
                        .WithMany()
                        .HasForeignKey("InterviewFeedbackId");

                    b.HasOne("Interview.AppCore.Entities.InterviewType", "InterviewType")
                        .WithMany()
                        .HasForeignKey("InterviewTypeLookupCode");

                    b.HasOne("Interview.AppCore.Entities.Interviewer", "Interviewer")
                        .WithMany()
                        .HasForeignKey("InterviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Interview.AppCore.Entities.Recruiter", "Recruiter")
                        .WithMany()
                        .HasForeignKey("RecruiterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InterviewFeedback");

                    b.Navigation("InterviewType");

                    b.Navigation("Interviewer");

                    b.Navigation("Recruiter");
                });
#pragma warning restore 612, 618
        }
    }
}
