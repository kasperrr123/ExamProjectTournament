using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Version5.Models
{
    public partial class db_examprojecttournamentContext : DbContext
    {
        public virtual DbSet<TblAnswer> TblAnswer { get; set; }
        public virtual DbSet<TblJudge> TblJudge { get; set; }
        public virtual DbSet<TblLogin> TblLogin { get; set; }
        public virtual DbSet<TblProject> TblProject { get; set; }
        public virtual DbSet<TblQuestionnaire> TblQuestionnaire { get; set; }
        public virtual DbSet<TblQuestions> TblQuestions { get; set; }
        public virtual DbSet<TblTeam> TblTeam { get; set; }
        public virtual DbSet<TblTopic> TblTopic { get; set; }
        public virtual DbSet<TblTournament> TblTournament { get; set; }

        public db_examprojecttournamentContext(DbContextOptions<db_examprojecttournamentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAnswer>(entity =>
            {
                entity.HasKey(e => e.FldAnswerId);

                entity.ToTable("tblAnswer");

                entity.Property(e => e.FldAnswerId).HasColumnName("fldAnswerID");

                entity.Property(e => e.FldAnswer)
                    .HasColumnName("fldAnswer")
                    .IsUnicode(false);

                entity.Property(e => e.FldJudgeId).HasColumnName("fldJudgeID");

                entity.Property(e => e.FldQuestionsId).HasColumnName("fldQuestionsID");

                entity.Property(e => e.FldTeamName)
                    .HasColumnName("fldTeamName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldJudge)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldJudgeId)
                    .HasConstraintName("FK__tblAnswer__fldJu__2B3F6F97");

                entity.HasOne(d => d.FldQuestions)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldQuestionsId)
                    .HasConstraintName("FK__tblAnswer__fldQu__2A4B4B5E");

                entity.HasOne(d => d.FldTeamNameNavigation)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldTeamName)
                    .HasConstraintName("FK__tblAnswer__fldTe__29572725");
            });

            modelBuilder.Entity<TblJudge>(entity =>
            {
                entity.HasKey(e => e.FldJudgeId);

                entity.ToTable("tblJudge");

                entity.HasIndex(e => e.FldJudgeLetter)
                    .HasName("UQ__tblJudge__B0CFFB7236760E10")
                    .IsUnique();

                entity.Property(e => e.FldJudgeId).HasColumnName("fldJudgeID");

                entity.Property(e => e.FldJudgeLetter)
                    .IsRequired()
                    .HasColumnName("fldJudgeLetter")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.Property(e => e.FldUsername)
                    .HasColumnName("fldUsername")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblJudge__fldTou__25869641");

                entity.HasOne(d => d.FldUsernameNavigation)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldUsername)
                    .HasConstraintName("FK__tblJudge__fldUse__267ABA7A");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.FldUsername);

                entity.ToTable("tblLogin");

                entity.Property(e => e.FldUsername)
                    .HasColumnName("fldUsername")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FldPassword)
                    .HasColumnName("fldPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldRank)
                    .HasColumnName("fldRank")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.FldProjectName);

                entity.ToTable("tblProject");

                entity.Property(e => e.FldProjectName)
                    .HasColumnName("fldProjectName")
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FldProjectFilePath)
                    .HasColumnName("fldProjectFilePath")
                    .IsUnicode(false);

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblProject)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblProjec__fldTo__145C0A3F");
            });

            modelBuilder.Entity<TblQuestionnaire>(entity =>
            {
                entity.HasKey(e => e.FldQuestionnaireId);

                entity.ToTable("tblQuestionnaire");

                entity.Property(e => e.FldQuestionnaireId).HasColumnName("fldQuestionnaireID");

                entity.Property(e => e.FldTopicId).HasColumnName("fldTopicID");

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.Property(e => e.FldType)
                    .HasColumnName("fldType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldTopic)
                    .WithMany(p => p.TblQuestionnaire)
                    .HasForeignKey(d => d.FldTopicId)
                    .HasConstraintName("FK__tblQuesti__fldTo__1A14E395");

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblQuestionnaire)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblQuesti__fldTo__1920BF5C");
            });

            modelBuilder.Entity<TblQuestions>(entity =>
            {
                entity.HasKey(e => e.FldQuestionsId);

                entity.ToTable("tblQuestions");

                entity.Property(e => e.FldQuestionsId).HasColumnName("fldQuestionsID");

                entity.Property(e => e.FldModifier).HasColumnName("fldModifier");

                entity.Property(e => e.FldQuestion)
                    .HasColumnName("fldQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.FldQuestionnaireId).HasColumnName("fldQuestionnaireID");

                entity.HasOne(d => d.FldQuestionnaire)
                    .WithMany(p => p.TblQuestions)
                    .HasForeignKey(d => d.FldQuestionnaireId)
                    .HasConstraintName("FK__tblQuesti__fldQu__1CF15040");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.FldTeamName);

                entity.ToTable("tblTeam");

                entity.Property(e => e.FldTeamName)
                    .HasColumnName("fldTeamName")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FldLeaderName)
                    .HasColumnName("fldLeaderName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldProjectName)
                    .HasColumnName("fldProjectName")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FldTopicId).HasColumnName("fldTopicID");

                entity.Property(e => e.FldUsername)
                    .HasColumnName("fldUsername")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldProjectNameNavigation)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldProjectName)
                    .HasConstraintName("FK__tblTeam__fldProj__1FCDBCEB");

                entity.HasOne(d => d.FldTopic)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldTopicId)
                    .HasConstraintName("FK__tblTeam__fldTopi__21B6055D");

                entity.HasOne(d => d.FldUsernameNavigation)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldUsername)
                    .HasConstraintName("FK__tblTeam__fldUser__20C1E124");
            });

            modelBuilder.Entity<TblTopic>(entity =>
            {
                entity.HasKey(e => e.FldTopicId);

                entity.ToTable("tblTopic");

                entity.Property(e => e.FldTopicId).HasColumnName("fldTopicID");

                entity.Property(e => e.FldTopic)
                    .HasColumnName("fldTopic")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTournament>(entity =>
            {
                entity.HasKey(e => e.FldTournamentId);

                entity.ToTable("tblTournament");

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.Property(e => e.FldAddress)
                    .HasColumnName("fldAddress")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FldEndDate)
                    .HasColumnName("fldEndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FldStartDate)
                    .HasColumnName("fldStartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FldTournamentName)
                    .HasColumnName("fldTournamentName")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
