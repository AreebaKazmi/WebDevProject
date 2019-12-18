namespace WebDevProject.Views.Account
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BSEKDatabase")
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Principle> Principles { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Status_2> Status_2 { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Admit_Card> Admit_Cards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Religion)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Picture)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Candidate>()
                .HasMany(e => e.Admit_Card)
                .WithRequired(e => e.Candidate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Examination>()
                .Property(e => e.Exam_Group)
                .IsUnicode(false);

            modelBuilder.Entity<Examination>()
                .HasMany(e => e.Candidates)
                .WithMany(e => e.Examinations)
                .Map(m => m.ToTable("Candidate took Examination").MapLeftKey("ExamID").MapRightKey("Roll Number"));

            modelBuilder.Entity<Examination>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Examinations)
                .Map(m => m.ToTable("Examination has Subject").MapLeftKey("ExamID").MapRightKey("Code"));

            modelBuilder.Entity<Guardian>()
                .HasMany(e => e.Candidates)
                .WithRequired(e => e.Guardian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guardian>()
                .HasMany(e => e.Admit_Card)
                .WithRequired(e => e.Guardian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Candidates)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Guardians)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Principles)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Principle>()
                .HasMany(e => e.Schools)
                .WithRequired(e => e.Principle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.Admit_Card)
                .WithRequired(e => e.School)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status_2>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Status_2>()
                .HasMany(e => e.Candidates)
                .WithRequired(e => e.Status_2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
    }
}
