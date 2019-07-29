﻿using Microsoft.EntityFrameworkCore;
using SFA.DAS.Payments.Application.Data.Configurations;
using SFA.DAS.Payments.Model.Core.Entities;

namespace SFA.DAS.Payments.Application.Repositories
{
    public class PaymentsDataContext : DbContext, IPaymentsDataContext
    {
        private readonly string connectionString;
        public DbSet<LevyAccountModel> LevyAccount { get; protected set; }
        public virtual DbSet<PaymentModel> Payment { get; set; }
        public virtual DbSet<ApprenticeshipModel> Apprenticeship { get; protected set; }
        public virtual DbSet<ApprenticeshipPriceEpisodeModel> ApprenticeshipPriceEpisode { get; protected set; }
        public virtual DbSet<SubmittedLearnerAimModel> SubmittedLearnerAim { get; protected set; }
        public virtual DbSet<SubmittedPriceEpisodeModel> SubmittedPriceEpisode { get; protected set; }
        public virtual DbSet<ApprenticeshipDuplicateModel> ApprenticeshipDuplicate { get; protected set; }
        public virtual DbSet<DataLockFailureModel> DataLockFailure { get; protected set; }
        public virtual DbSet<EmployerProviderPriorityModel> EmployerProviderPriority { get; protected set; }
        public virtual DbSet<ApprenticeshipPauseModel> ApprenticeshipPause { get; protected set; }

        public PaymentsDataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Payments2");
            modelBuilder.ApplyConfiguration(new PaymentModelConfiguration());
            modelBuilder.ApplyConfiguration(new ApprenticeshipModelConfiguration());
            modelBuilder.ApplyConfiguration(new ApprenticeshipPriceEpisodeModelConfiguration());
            modelBuilder.ApplyConfiguration(new LevyAccountModelConfiguration());
            modelBuilder.ApplyConfiguration(new SubmittedLearnerAimModelConfiguration());
            modelBuilder.ApplyConfiguration(new SubmittedPriceEpisodeModelConfiguration());
            modelBuilder.ApplyConfiguration(new ApprenticeshipDuplicateModelConfiguration());
            modelBuilder.ApplyConfiguration(new DataLockFailureModelConfiguration());
            modelBuilder.ApplyConfiguration(new EmployerProviderPriorityModelConfiguration());
            modelBuilder.ApplyConfiguration(new ApprenticeshipPauseModelConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
