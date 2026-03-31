using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext() { }
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options) : base(options) 
        {
            //this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public virtual DbSet<SecondaryContact> SecondaryContacts { get; set; }

        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<TrialStudent> TrialStudents { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<CourseDetails> CourseDetails { get; set; }
        public virtual DbSet<FeeStructure> FeeStructures { get; set; }
        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<ReturnFee> ReturnFees { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }
       
		    public virtual DbSet<QualificationMaster> QualificationMaster { get; set; }

        public virtual DbSet<RegistrationFee> RegistrationFees { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-PBRNQVI;Initial Catalog=Latest_Student_Managment_Database;Integrated Security=True;Trust Server Certificate=True").UseLazyLoadingProxies();

        }




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// ============================
			// CourseDetails → Course
			// ============================
			modelBuilder.Entity<CourseDetails>()
				.HasOne(cd => cd.Course)
				.WithMany(c => c.CourseDetails)
				.HasForeignKey(cd => cd.CourseId)
				.OnDelete(DeleteBehavior.NoAction);
			modelBuilder.Entity<CourseDetails>()
	.HasOne(cd => cd.Batch)
	.WithMany() // Batch doesn't have a CourseDetails collection property
	.HasForeignKey(cd => cd.BatchId)
	.OnDelete(DeleteBehavior.NoAction); // No cascade
										// ============================
										// CourseDetails → StudentProfile
										// ============================
			modelBuilder.Entity<CourseDetails>()
				.HasOne(cd => cd.Profile)
				.WithMany(p => p.Course)
				.HasForeignKey(cd => cd.StudentProfileId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// Qualification → StudentProfile
			// ============================
			modelBuilder.Entity<Qualification>()
				.HasOne(q => q.Profile)
				.WithMany(p => p.Qualification)
				.HasForeignKey(q => q.StudentId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// Experience → StudentProfile
			// ============================
			modelBuilder.Entity<Experience>()
				.HasOne(e => e.Profile)
				.WithMany(p => p.Experience)
				.HasForeignKey(e => e.StudentId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// FeeStructure → StudentProfile
			// ============================
			modelBuilder.Entity<FeeStructure>()
				.HasOne(fs => fs.StudentProfile)
				.WithMany(sp => sp.FeeStructure)
				.HasForeignKey(fs => fs.StudentId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// FeeStructure → CourseDetails
			// ============================
			modelBuilder.Entity<FeeStructure>()
				.HasOne(fs => fs.CourseDetail)
				.WithMany()
				.HasForeignKey(fs => fs.CourseDetailId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// FeeStructure → FeeInstallment
			// (ONLY cascade kept here)
			// ============================
			modelBuilder.Entity<FeeStructure>()
				.HasMany(fs => fs.FeeInstallment)
				.WithOne(fi => fi.FeeStructure)
				.HasForeignKey(fi => fi.FeeStructureId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// TrialStudent → RegistrationFee
			// ============================
			modelBuilder.Entity<TrialStudent>()
				.HasOne(ts => ts.RegistrationFee)
				.WithOne(rf => rf.TrialStudent)
				.HasForeignKey<RegistrationFee>(rf => rf.TrialStudentId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// Branch → StudentProfile
			// ============================
			modelBuilder.Entity<StudentProfile>()
				.HasOne(sp => sp.Branch)
				.WithMany(b => b.StudentProfiles)
				.HasForeignKey(sp => sp.BranchId)
				.OnDelete(DeleteBehavior.NoAction);

			// ============================
			// Branch → Batch
			// ============================
			modelBuilder.Entity<Batch>()
				.HasOne(b => b.Branch)
				.WithMany(br => br.Batches)
				.HasForeignKey(b => b.BranchId)
				.OnDelete(DeleteBehavior.NoAction);
			
			base.OnModelCreating(modelBuilder);



		}


		}
    }

