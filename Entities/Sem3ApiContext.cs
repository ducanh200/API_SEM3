using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SEM3_API.Entities;

public partial class Sem3ApiContext : DbContext
{
    public Sem3ApiContext()
    {
    }

    public Sem3ApiContext(DbContextOptions<Sem3ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Donate> Donates { get; set; }

    public virtual DbSet<DonateDetail> DonateDetails { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=SEM3_API;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__countrie__3213E83FA9A59A6A");

            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Donate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__donate__3213E83FFE3A31F1");

            entity.ToTable("donate");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.City)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DonateDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("donate_details");

            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.DonateId).HasColumnName("donate_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");

            entity.HasOne(d => d.Donate).WithMany()
                .HasForeignKey(d => d.DonateId)
                .HasConstraintName("FK__donate_de__donat__29572725");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__donate_de__proje__2A4B4B5E");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83FBC0AC12A");

            entity.ToTable("feedback");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Project).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__feedback__projec__2C3393D0");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__feedback__user_i__2B3F6F97");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__news__3213E83F99EE09F3");

            entity.ToTable("news");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__news__country_id__2D27B809");

            entity.HasOne(d => d.Topic).WithMany(p => p.News)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__news__topic_id__2E1BDC42");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__projects__3213E83FEA4B3C9A");

            entity.ToTable("projects");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Begin)
                .HasColumnType("date")
                .HasColumnName("begin");
            entity.Property(e => e.City)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Finish)
                .HasColumnType("date")
                .HasColumnName("finish");
            entity.Property(e => e.Fund)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("fund");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Schedule)
                .HasColumnType("text")
                .HasColumnName("schedule");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Thumbnail1)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("thumbnail_1");
            entity.Property(e => e.Thumbnail2)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("thumbnail_2");
            entity.Property(e => e.TopicId).HasColumnName("topic_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__projects__countr__276EDEB3");

            entity.HasOne(d => d.Topic).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TopicId)
                .HasConstraintName("FK__projects__topic___286302EC");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__topics__3213E83FF2623D33");

            entity.ToTable("topics");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FC051D5A1");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(225)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(225)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(225)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(225)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
