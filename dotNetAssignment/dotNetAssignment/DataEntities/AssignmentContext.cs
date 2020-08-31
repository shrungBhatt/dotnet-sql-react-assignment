using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotNetAssignment.DataEntities
{
    public partial class AssignmentContext : DbContext
    {
        public AssignmentContext()
        {
        }

        public AssignmentContext(DbContextOptions<AssignmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractsView> ContractsView { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<CoveragePlan> CoveragePlan { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<RateChart> RateChart { get; set; }
        public virtual DbSet<Rules> Rules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.ToTable("contracts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CoveragePlan).HasColumnName("coverage_plan");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasColumnName("customer_address")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.RateChart).HasColumnName("rate_chart");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("sale_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__count__1ED998B2");

                entity.HasOne(d => d.CoveragePlanNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.CoveragePlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__cover__1FCDBCEB");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contracts__gende__1DE57479");

                entity.HasOne(d => d.RateChartNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RateChart)
                    .HasConstraintName("FK__contracts__rate___20C1E124");
            });

            modelBuilder.Entity<ContractsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("contracts_view");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoveragePlan)
                    .IsRequired()
                    .HasColumnName("coverage_plan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasColumnName("customer_address")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NetPrice)
                    .HasColumnName("net_price")
                    .HasColumnType("money");

                entity.Property(e => e.SaleDate)
                    .HasColumnName("sale_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country1)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode).HasColumnName("country_code");
            });

            modelBuilder.Entity<CoveragePlan>(entity =>
            {
                entity.ToTable("coverage_plan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CoveragePlan1)
                    .IsRequired()
                    .HasColumnName("coverage_plan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EligCountry).HasColumnName("elig_country");

                entity.Property(e => e.EligFromDate)
                    .HasColumnName("elig_from_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EligToDate)
                    .HasColumnName("elig_to_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.EligCountryNavigation)
                    .WithMany(p => p.CoveragePlan)
                    .HasForeignKey(d => d.EligCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__coverage___elig___145C0A3F");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("gender");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gender1)
                    .IsRequired()
                    .HasColumnName("gender")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RateChart>(entity =>
            {
                entity.ToTable("rate_chart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.AppliedRule).HasColumnName("applied_rule");

                entity.Property(e => e.CoveragePlan).HasColumnName("coverage_plan");

                entity.Property(e => e.CustomerGender).HasColumnName("customer_gender");

                entity.Property(e => e.NetPrice)
                    .HasColumnName("net_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.AppliedRuleNavigation)
                    .WithMany(p => p.RateChart)
                    .HasForeignKey(d => d.AppliedRule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rate_char__appli__1B0907CE");

                entity.HasOne(d => d.CoveragePlanNavigation)
                    .WithMany(p => p.RateChart)
                    .HasForeignKey(d => d.CoveragePlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rate_char__cover__1920BF5C");

                entity.HasOne(d => d.CustomerGenderNavigation)
                    .WithMany(p => p.RateChart)
                    .HasForeignKey(d => d.CustomerGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__rate_char__custo__1A14E395");
            });

            modelBuilder.Entity<Rules>(entity =>
            {
                entity.ToTable("rules");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RuleText)
                    .IsRequired()
                    .HasColumnName("rule_text")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
