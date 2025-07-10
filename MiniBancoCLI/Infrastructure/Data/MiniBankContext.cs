using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniBancoCLI.Core.Models;

namespace MiniBancoCLI.Infrastructure.Data;

public partial class MiniBankContext : DbContext
{
    public MiniBankContext()
    {
    }

    public MiniBankContext(DbContextOptions<MiniBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Conta> Conta { get; set; }

    public virtual DbSet<Transacao> Transacaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Higor\\HIGOR;Database=MiniBank;User Id=sa;Password=123Teste;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banco>(entity =>
        {
            entity.HasKey(e => e.IdBanco).HasName("PK__Banco__37C5FC6180F62C79");

            entity.ToTable("Banco");

            entity.Property(e => e.IdBanco).HasColumnName("Id_Banco");
            entity.Property(e => e.Nome).HasMaxLength(255);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__3DD0A8CB5C23C3AD");

            entity.ToTable("Cliente");

            entity.HasIndex(e => e.Cpf, "UQ__Cliente__C1FF9309086653B9").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.Cpf).HasMaxLength(11);
            entity.Property(e => e.Nome).HasMaxLength(255);
            entity.Property(e => e.SenhaHash).HasMaxLength(255);
        });

        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(e => e.IdConta).HasName("PK__Conta__F35D5E9B4509BC08");

            entity.HasIndex(e => e.NumeroConta, "UQ__Conta__DF1C573EB609A27B").IsUnique();

            entity.Property(e => e.IdConta).HasColumnName("Id_Conta");
            entity.Property(e => e.Agencia).HasMaxLength(6);
            entity.Property(e => e.IdBanco).HasColumnName("Id_banco");
            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.NumeroConta)
                .HasMaxLength(11)
                .HasColumnName("Numero_Conta");
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdBancoNavigation).WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdBanco)
                .HasConstraintName("FK__Conta__Id_banco__4F7CD00D");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Conta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Conta__Id_client__5070F446");
        });

        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(e => e.IdTransacao).HasName("PK__Transaca__37CC6940DC3A55BE");

            entity.ToTable("Transacao");

            entity.Property(e => e.IdTransacao).HasColumnName("Id_transacao");
            entity.Property(e => e.Data).HasColumnType("datetime");
            entity.Property(e => e.IdConta).HasColumnName("Id_conta");
            entity.Property(e => e.Quantia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TipoTransacao)
                .HasMaxLength(255)
                .HasColumnName("Tipo_transacao");

            entity.HasOne(d => d.IdContaNavigation).WithMany(p => p.Transacaos)
                .HasForeignKey(d => d.IdConta)
                .HasConstraintName("FK__Transacao__Id_co__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
