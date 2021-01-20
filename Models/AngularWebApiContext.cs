using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace angular_web_api_usage.Models
{
  public partial class AngularWebApiContext : DbContext
  {
    public AngularWebApiContext()
    {
    }

    public AngularWebApiContext(DbContextOptions<AngularWebApiContext> options)
      : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //   if (!optionsBuilder.IsConfigured)
    //   {
    //     // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //     optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Database=angular_web_api;User Id=sa;Password=DockerMsSql127!;");
    //   }
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Cliente>(entity =>
      {
        entity.Property(e => e.Cidade)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);

        entity.Property(e => e.Email)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);

        entity.Property(e => e.Endereco)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);

        entity.Property(e => e.Nome)
          .IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
