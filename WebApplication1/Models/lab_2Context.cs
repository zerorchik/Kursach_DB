using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication1.Models
{
    public partial class lab_2Context : DbContext
    {
        public lab_2Context()
        {
        }

        public lab_2Context(DbContextOptions<lab_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresser> Adressers { get; set; }
        public virtual DbSet<Helper> Helpers { get; set; }
        public virtual DbSet<Letter> Letters { get; set; }
        public virtual DbSet<Thema> Themas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lab_2;Username=postgres;Password=Sonya2004;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Adresser>(entity =>
            {
                entity.HasKey(e => e.Adid)
                    .HasName("adresser_pkey");

                entity.ToTable("adresser");

                entity.HasIndex(e => e.Sign, "sign_unique")
                    .IsUnique();

                entity.Property(e => e.Adid)
                    .ValueGeneratedNever()
                    .HasColumnName("adid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("sign");
            });

            modelBuilder.Entity<Helper>(entity =>
            {
                entity.HasKey(e => e.Hid)
                    .HasName("helper_pkey");

                entity.ToTable("helper");

                entity.Property(e => e.Hid)
                    .ValueGeneratedNever()
                    .HasColumnName("hid");

                entity.Property(e => e.BossId).HasColumnName("boss_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Sign)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("sign");

                entity.HasOne(d => d.Boss)
                    .WithMany(p => p.Helpers)
                    .HasForeignKey(d => d.BossId)
                    .HasConstraintName("boss_id");
            });

            modelBuilder.Entity<Letter>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("letter_1_pkey");

                entity.ToTable("letter");

                entity.Property(e => e.Lid)
                    .ValueGeneratedNever()
                    .HasColumnName("lid");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.DateAns)
                    .HasColumnType("date")
                    .HasColumnName("date_ans");

                entity.Property(e => e.HelperId).HasColumnName("helper_id");

                entity.Property(e => e.IsAns).HasColumnName("is_ans");

                entity.Property(e => e.ReceiverId).HasColumnName("receiver_id");

                entity.Property(e => e.SenderId).HasColumnName("sender_id");

                entity.Property(e => e.ThemaId).HasColumnName("thema_id");
            });

            modelBuilder.Entity<Thema>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("thema_pkey");

                entity.ToTable("thema");

                entity.Property(e => e.Tid)
                    .ValueGeneratedNever()
                    .HasColumnName("tid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
