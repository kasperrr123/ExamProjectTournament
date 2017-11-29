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

        public db_examprojecttournamentContext(DbContextOptions<db_examprojecttournamentContext> options)
        : base(options)
        { }

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
                    .HasConstraintName("FK__tblAnswer__fldJu__20C1E124");

                entity.HasOne(d => d.FldQuestionaire)
                    .WithMany(p => p.TblAnswer)
                    .HasForeignKey(d => d.FldQuestionaireId)
                    .HasConstraintName("FK__tblAnswer__fldQu__1FCDBCEB");
            });

            modelBuilder.Entity<TblJudge>(entity =>
            {
                entity.HasKey(e => e.FldJudgeId);

                entity.ToTable("tblJudge");

                entity.HasIndex(e => e.FldJudgeLetter)
                    .HasName("UQ__tblJudge__B0CFFB72203C5897")
                    .IsUnique();

                entity.Property(e => e.FldJudgeId).HasColumnName("fldJudgeID");

                entity.Property(e => e.FldJudgeLetter)
                    .IsRequired()
                    .HasColumnName("fldJudgeLetter")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FldLoginId).HasColumnName("fldLoginID");

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.HasOne(d => d.FldLogin)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldLoginId)
                    .HasConstraintName("FK__tblJudge__fldLog__1CF15040");

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblJudge)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblJudge__fldTou__1BFD2C07");
            });

            modelBuilder.Entity<TblLogin>(entity =>
            {
                entity.HasKey(e => e.FldLoginId);

                entity.ToTable("tblLogin");

                entity.HasIndex(e => e.FldUsername)
                    .HasName("UQ__tblLogin__A76F44478A608FFF")
                    .IsUnique();

                entity.Property(e => e.FldLoginId).HasColumnName("fldLoginID");

                entity.Property(e => e.FldPassword)
                    .HasColumnName("fldPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldRank)
                    .HasColumnName("fldRank")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FldUsername)
                    .HasColumnName("fldUsername")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.FldProjectId);

                entity.ToTable("tblProject");

                entity.Property(e => e.FldProjectId).HasColumnName("fldProjectID");

                entity.Property(e => e.FldData)
                    .HasColumnName("fldData")
                    .IsUnicode(false);

                entity.Property(e => e.FldProjectName)
                    .HasColumnName("fldProjectName")
                    .IsUnicode(false);

                entity.Property(e => e.FldTournamentId).HasColumnName("fldTournamentID");

                entity.HasOne(d => d.FldTournament)
                    .WithMany(p => p.TblProject)
                    .HasForeignKey(d => d.FldTournamentId)
                    .HasConstraintName("FK__tblProjec__fldTo__15502E78");
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
                    .HasConstraintName("FK__tblQuesti__fldTo__182C9B23");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.FldTeamId);

                entity.ToTable("tblTeam");

                entity.HasIndex(e => e.FldTeamName)
                    .HasName("UQ__tblTeam__444E4FEA343EF6F2")
                    .IsUnique();

                entity.Property(e => e.FldTeamId).HasColumnName("fldTeamID");

                entity.Property(e => e.FldLeaderName)
                    .HasColumnName("fldLeaderName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldLoginId).HasColumnName("fldLoginID");

                entity.Property(e => e.FldMembers).HasColumnName("fldMembers");

                entity.Property(e => e.FldProjectId).HasColumnName("fldProjectID");

                entity.Property(e => e.FldTeamName)
                    .HasColumnName("fldTeamName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FldTopic)
                    .HasColumnName("fldTopic")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.FldLogin)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldLoginId)
                    .HasConstraintName("FK__tblTeam__fldLogi__25869641");

                entity.HasOne(d => d.FldProject)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.FldProjectId)
                    .HasConstraintName("FK__tblTeam__fldProj__24927208");
            });

            modelBuilder.Entity<TblTournament>(entity =>
            {
                entity.HasKey(e => e.FldTournamentId);

                entity.ToTable("tblTournament");

                entity.Property(e => e.FldTournamentId)
                    .HasColumnName("fldTournamentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FldAddress)
                    .HasColumnName("fldAddress")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FldEndDate)
                    .HasColumnName("fldEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.FldStartDate)
                    .HasColumnName("fldStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.FldStartTime)
                    .HasColumnName("fldStartTime")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FldTournamentName)
                    .HasColumnName("fldTournamentName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FldYear).HasColumnName("fldYear");
            });
        }
    }
}
