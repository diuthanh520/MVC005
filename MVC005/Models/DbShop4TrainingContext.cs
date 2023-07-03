using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC005.Models;

public partial class DbShop4TrainingContext : DbContext
{
    public DbShop4TrainingContext()
    {
    }

    public DbShop4TrainingContext(DbContextOptions<DbShop4TrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblChitiethoadon> TblChitiethoadons { get; set; }

    public virtual DbSet<TblHanghoa> TblHanghoas { get; set; }

    public virtual DbSet<TblHoadon> TblHoadons { get; set; }

    public virtual DbSet<TblKhachhang> TblKhachhangs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= DESKTOP-96D4EUK\\ADMIN;Initial Catalog=db_Shop4Training;Persist Security Info=True;User ID=sa;Password=12345678;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChitiethoadon>(entity =>
        {
            entity.HasKey(e => new { e.FkIHoadonId, e.FkIHanghoaId });

            entity.ToTable("tblChitiethoadon");

            entity.Property(e => e.FkIHoadonId).HasColumnName("FK_iHoadonID");
            entity.Property(e => e.FkIHanghoaId).HasColumnName("FK_iHanghoaID");
            entity.Property(e => e.FGiaban).HasColumnName("fGiaban");
            entity.Property(e => e.ISoluong).HasColumnName("iSoluong");

            entity.HasOne(d => d.FkIHanghoa).WithMany(p => p.TblChitiethoadons)
                .HasForeignKey(d => d.FkIHanghoaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChitiethoadon_tblHanghoa");

            entity.HasOne(d => d.FkIHoadon).WithMany(p => p.TblChitiethoadons)
                .HasForeignKey(d => d.FkIHoadonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblChitiethoadon_tblHoadon");
        });

        modelBuilder.Entity<TblHanghoa>(entity =>
        {
            entity.HasKey(e => e.PkIHanghoaId).HasName("PK_MatHang");

            entity.ToTable("tblHanghoa");

            entity.Property(e => e.PkIHanghoaId).HasColumnName("PK_iHanghoaID");
            entity.Property(e => e.FGianiemyet).HasColumnName("fGianiemyet");
            entity.Property(e => e.SAnhminhhoa)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("sAnhminhhoa");
            entity.Property(e => e.SDacdiem)
                .HasColumnType("ntext")
                .HasColumnName("sDacdiem");
            entity.Property(e => e.STenhang)
                .HasMaxLength(300)
                .HasColumnName("sTenhang");
            entity.Property(e => e.SXuatxu)
                .HasMaxLength(300)
                .HasColumnName("sXuatxu");
        });

        modelBuilder.Entity<TblHoadon>(entity =>
        {
            entity.HasKey(e => e.PkIHoadonId).HasName("PK_HoaDon");

            entity.ToTable("tblHoadon");

            entity.Property(e => e.PkIHoadonId).HasColumnName("PK_iHoadonID");
            entity.Property(e => e.BDathanhtoan).HasColumnName("bDathanhtoan");
            entity.Property(e => e.FTileGiamgia).HasColumnName("fTileGiamgia");
            entity.Property(e => e.FkIKhachhangId).HasColumnName("FK_iKhachhangID");
            entity.Property(e => e.SDiachigiaohang)
                .HasMaxLength(500)
                .HasColumnName("sDiachigiaohang");
            entity.Property(e => e.SDienthoaiNguoinhan)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sDienthoaiNguoinhan");
            entity.Property(e => e.SNguoilapHoadon)
                .HasMaxLength(50)
                .HasColumnName("sNguoilapHoadon");
            entity.Property(e => e.STennguoinhan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sTennguoinhan");
            entity.Property(e => e.TNgayGiaoHang)
                .HasColumnType("datetime")
                .HasColumnName("tNgayGiaoHang");
            entity.Property(e => e.TNgaylap)
                .HasColumnType("datetime")
                .HasColumnName("tNgaylap");

            entity.HasOne(d => d.FkIKhachhang).WithMany(p => p.TblHoadons)
                .HasForeignKey(d => d.FkIKhachhangId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblHoadon_tblKhachhang1");
        });

        modelBuilder.Entity<TblKhachhang>(entity =>
        {
            entity.HasKey(e => e.PkIKhachhangId);

            entity.ToTable("tblKhachhang");

            entity.Property(e => e.PkIKhachhangId).HasColumnName("PK_iKhachhangID");
            entity.Property(e => e.BGioitinh).HasColumnName("bGioitinh");
            entity.Property(e => e.SDiachi)
                .HasMaxLength(200)
                .HasColumnName("sDiachi");
            entity.Property(e => e.SDienthoai)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("sDienthoai");
            entity.Property(e => e.SHoten)
                .HasMaxLength(50)
                .HasColumnName("sHoten");
            entity.Property(e => e.STenCoquan)
                .HasMaxLength(100)
                .HasColumnName("sTenCoquan");
            entity.Property(e => e.TNgaysinh)
                .HasColumnType("datetime")
                .HasColumnName("tNgaysinh");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
