using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbProject
{
    public partial class TextAppContext : DbContext
    {
        public TextAppContext()
        {
        }

        public TextAppContext(DbContextOptions<TextAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpressionsVsPosition> ExpressionsVsPositions { get; set; } = null!;
        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<LinguisticExpression> LinguisticExpressions { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<Word> Words { get; set; } = null!;
        public virtual DbSet<WordsVsGroup> WordsVsGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\sqlExpress;DataBase=TextApp;Trusted_connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpressionsVsPosition>(entity =>
            {
                entity.HasKey(e => e.ExpressionVsPositionId);

                entity.Property(e => e.ExpressionVsPositionId).HasColumnName("ExpressionVsPositionID");

                entity.Property(e => e.ExpressionId).HasColumnName("ExpressionID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.HasOne(d => d.Expression)
                    .WithMany(p => p.ExpressionsVsPositions)
                    .HasForeignKey(d => d.ExpressionId)
                    .HasConstraintName("FK_ExpressionsVsPositions_LinguisticExpressions");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.ExpressionsVsPositions)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_ExpressionsVsPositions_Positions");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName).HasMaxLength(150);
            });

            modelBuilder.Entity<LinguisticExpression>(entity =>
            {
                entity.HasKey(e => e.ExpressionId);

                entity.Property(e => e.ExpressionId).HasColumnName("ExpressionID");

                entity.Property(e => e.ExpressionValue).HasMaxLength(300);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.WordValue).HasMaxLength(100);

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Positions_Songs1");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.Album).HasMaxLength(250);

                entity.Property(e => e.Artist).HasMaxLength(100);

                entity.Property(e => e.FilePath).HasMaxLength(1000);

                entity.Property(e => e.Genre).HasMaxLength(150);

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.WordValue).HasMaxLength(100);

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Words)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Words_Songs");
            });

            modelBuilder.Entity<WordsVsGroup>(entity =>
            {
                entity.HasKey(e => e.WordVsGroupId);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.WordId).HasColumnName("WordID");

                entity.Property(e => e.WordValue).HasMaxLength(150);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.WordsVsGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WordsVsGroups_Groups1");

                entity.HasOne(d => d.Word)
                    .WithMany(p => p.WordsVsGroups)
                    .HasForeignKey(d => d.WordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WordsVsGroups_Words");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
