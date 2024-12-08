// Data/SpaceResearchContext.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SpaceResearchManagementSystem.Data
{
    public class SpaceResearchContext : DbContext
    {
        public SpaceResearchContext(DbContextOptions<SpaceResearchContext> options) : base(options)
        {
        }

        // DbSet properties for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<ScientificData> ScientificDatas { get; set; }
        public DbSet<ProjectPlan> ProjectPlans { get; set; }
        public DbSet<SafetyLog> SafetyLogs { get; set; }
        public DbSet<MissionPerformance> MissionPerformances { get; set; }
        public DbSet<CostManagement> CostManagements { get; set; }
        public DbSet<EnvironmentalData> EnvironmentalDatas { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // Define Relationships
            // =========================

            // User-Mission (Director)
            modelBuilder.Entity<Mission>()
                .HasOne(m => m.Director)
                .WithMany(u => u.DirectedMissions)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mission-Equipment
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.AssignedMission)
                .WithMany(m => m.Equipments)
                .HasForeignKey(e => e.AssignedMissionId)
                .OnDelete(DeleteBehavior.SetNull);

            // Mission-ScientificData
            modelBuilder.Entity<ScientificData>()
                .HasOne(sd => sd.Mission)
                .WithMany(m => m.ScientificDatas)
                .HasForeignKey(sd => sd.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User-ScientificData (Researcher)
           modelBuilder.Entity<ScientificData>()
                .HasOne(sd => sd.Researcher)
                .WithMany()
                .HasForeignKey(sd => sd.ResearcherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mission-ProjectPlan
            modelBuilder.Entity<ProjectPlan>()
                .HasOne(pp => pp.Mission)
                .WithMany(m => m.ProjectPlans)
                .HasForeignKey(pp => pp.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User-ProjectPlan (Engineer)
            /*modelBuilder.Entity<ProjectPlan>()
                .HasOne(pp => pp.AssignedEngineer)
                .WithMany(u => u.ProjectPlans)
                .HasForeignKey(pp => pp.AssignedEngineerId)
                .OnDelete(DeleteBehavior.Restrict);*/

            // Mission-SafetyLog
            modelBuilder.Entity<SafetyLog>()
                .HasOne(sl => sl.Mission)
                .WithMany(m => m.SafetyLogs)
                .HasForeignKey(sl => sl.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Mission-MissionPerformance
            modelBuilder.Entity<MissionPerformance>()
                .HasOne(mp => mp.Mission)
                .WithMany(m => m.MissionPerformances)
                .HasForeignKey(mp => mp.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User-MissionPerformance (Supervisor)
            modelBuilder.Entity<MissionPerformance>()
                .HasOne(mp => mp.Supervisor)
                .WithMany()
                .HasForeignKey(mp => mp.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Mission-CostManagement
            modelBuilder.Entity<CostManagement>()
                .HasOne(cm => cm.Mission)
                .WithMany(m => m.CostManagements)
                .HasForeignKey(cm => cm.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Mission-EnvironmentalData
            modelBuilder.Entity<EnvironmentalData>()
                .HasOne(ed => ed.Mission)
                .WithMany(m => m.EnvironmentalDatas)
                .HasForeignKey(ed => ed.MissionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User-Report (CreatedBy)
            modelBuilder.Entity<Report>()
                .HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // User-Notification
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
