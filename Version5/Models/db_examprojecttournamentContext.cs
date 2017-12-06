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
        public virtual DbSet<TblQuestionaire> TblQuestionaire { get; set; }
        public virtual DbSet<TblTeam> TblTeam { get; set; }
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

                entity.Property(e => e.FldFirstQuestionScore).HasColumnName("fldFirstQuestionScore");

                entity.Property(e => e.FldFourthQuestionScore).HasColumnName("fldFourthQuestionScore");

                entity.Property(e => e.FldJudgeId).HasColumnName("fldJudgeID");

                entity.Property(e => e.FldQuestionaireId).HasColumnName("fldQuestionaireID");

                entity.Property(e => e.FldSecondQuestionScore).HasColumnName("fldSecondQuestionScore");

                entity.Property(e => e.FldThirdQuestionScore).HasColumnName("fldThirdQuestionScore");

                entity.HasOne(d => d.FldJudge)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldJudgeId)
                    .HasConstraintName("FK__tblAnswer__fldJu__1FCDBCEB");

                entity.HasOne(d => d.FldQuestionaire)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldQuestionaireId)
                    .HasConstraintName("FK__tblAnswer__fldQu__1ED998B2");
            });

            modelBuilder.Entity<TblJudge>(entity =>
            {
                entity.HasKey(e => e.FldJudgeId);

                entity.ToTable("tblJudge");

                entity.HasIndex(e => e.FldJudgeLetter)
                    .HasName("UQ__tblJudge__B0CFFB72D2449B30")
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
                    .HasConstraintName("FK__tblJudge__fldTou__1B0907CE");

                entity.HasOne(d => d.FldUsernameNavigation)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldUsername)
                    .HasConstraintName("FK__tblJudge__fldUse__1BFD2C07");
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

            modelBuilder.Entity<TblQuestionaire>(entity =>
            {
                entity.HasKey(e => e.FldQuestionaireId);

                entity.ToTable("tblQuestionaire");

                entity.Property(e => e.FldQuestionaireId).HasColumnName("fldQuestionaireID");

                entity.Property(e => e.FldFirstQuestion)
                    .HasColumnName("fldFirstQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.FldFourthQuestion)
                    .HasColumnName("fldFourthQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.FldSecondQuestion)
                    .HasColumnName("fldSecondQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.FldThirdQuestion)
                    .HasColumnName("fldThirdQuestion")
                    .IsUnicode(false);

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblQuestionaire)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblQuesti__fldTo__173876EA");
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

                entity.Property(e => e.FldTopic)
                    .HasColumnName("fldTopic")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FldUsername)
                    .HasColumnName("fldUsername")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldProjectNameNavigation)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldProjectName)
                    .HasConstraintName("FK__tblTeam__fldProj__22AA2996");

                entity.HasOne(d => d.FldUsernameNavigation)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldUsername)
                    .HasConstraintName("FK__tblTeam__fldUser__239E4DCF");
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
