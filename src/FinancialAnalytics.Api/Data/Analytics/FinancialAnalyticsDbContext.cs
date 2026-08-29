using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api;

public sealed class FinancialAnalyticsDbContext(DbContextOptions<FinancialAnalyticsDbContext> options) : DbContext(options)
{
    public DbSet<PipelineRun> PipelineRuns => Set<PipelineRun>();
    public DbSet<StgTransaction> StgTransactions => Set<StgTransaction>();
    public DbSet<DimAccount> DimAccounts => Set<DimAccount>();
    public DbSet<DimEntity> DimEntities => Set<DimEntity>();
    public DbSet<DimDate> DimDates => Set<DimDate>();
    public DbSet<DimCurrency> DimCurrencies => Set<DimCurrency>();
    public DbSet<FactGl> FactGl => Set<FactGl>();
    public DbSet<AccountMapping> AccountMappings => Set<AccountMapping>();
    public DbSet<PipelineErrorEntity> PipelineErrors => Set<PipelineErrorEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PipelineRun>(entity =>
        {
            entity.ToTable("PipelineRun");
            entity.HasKey(x => x.PipelineRunId);
            entity.Property(x => x.Status).HasMaxLength(30).IsRequired();
            entity.Property(x => x.Scenario).HasMaxLength(30).IsRequired();
            entity.Property(x => x.ValidationResultJson).HasColumnType("nvarchar(max)");
            entity.HasIndex(x => x.StartedAt);
        });
        modelBuilder.Entity<PipelineErrorEntity>(entity =>
        {
            entity.ToTable("PipelineError");
            entity.HasKey(x => x.PipelineErrorId);
            entity.Property(x => x.Stage).HasMaxLength(30).IsRequired();
            entity.Property(x => x.ErrorCode).HasMaxLength(100).IsRequired();
            entity.Property(x => x.SourceTransactionId).HasMaxLength(50);
            entity.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            entity.HasIndex(x => new { x.PipelineRunId, x.SourceTransactionId });
            entity.HasIndex(x => new { x.PipelineRunId, x.Stage });
            entity.HasOne(x => x.PipelineRun)
                .WithMany(x => x.Errors)
                .HasForeignKey(x => x.PipelineRunId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<StgTransaction>(entity =>
        {
            entity.ToTable("StgTransaction");
            entity.HasKey(x => x.StgTransactionId);
            entity.Property(x => x.SourceTransactionId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.SourceAccountCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.SourceAccountName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.SourceEntityCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.CurrencyCode).HasMaxLength(3).IsFixedLength().IsRequired();
            entity.Property(x => x.Description).HasMaxLength(500);
            entity.Property(x => x.Amount).HasPrecision(18, 2);
            entity.HasIndex(x => new { x.PipelineRunId, x.SourceTransactionId });
            entity.HasOne(x => x.PipelineRun).WithMany(x => x.StagedTransactions).HasForeignKey(x => x.PipelineRunId);
        });
        modelBuilder.Entity<DimAccount>(entity =>
        {
            entity.ToTable("DimAccount");
            entity.HasKey(x => x.AccountKey);
            entity.Property(x => x.AccountCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.AccountName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.AccountCategory).HasMaxLength(50).IsRequired();
            entity.HasIndex(x => x.AccountCode).IsUnique();
            entity.HasOne(x => x.ParentAccount).WithMany(x => x.ChildAccounts).HasForeignKey(x => x.ParentAccountKey).OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<AccountMapping>(entity =>
        {
            entity.ToTable("AccountMapping");
            entity.HasKey(x => x.AccountMappingKey);
            entity.Property(x => x.SourceSystem).HasMaxLength(50).IsRequired();
            entity.Property(x => x.SourceAccountCode).HasMaxLength(50).IsRequired();
            entity.HasIndex(x => new { x.SourceSystem, x.SourceAccountCode }).IsUnique();
            entity.HasOne(x => x.Account)
                .WithMany()
                .HasForeignKey(x => x.AccountKey)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<DimEntity>(entity =>
        {
            entity.ToTable("DimEntity");
            entity.HasKey(x => x.EntityKey);
            entity.Property(x => x.EntityCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.EntityName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.CountryCode).HasMaxLength(2).IsFixedLength().IsRequired();
            entity.HasIndex(x => x.EntityCode).IsUnique();
        });
        modelBuilder.Entity<DimDate>(entity =>
        {
            entity.ToTable("DimDate");
            entity.HasKey(x => x.DateKey);
            entity.Property(x => x.Date).HasColumnType("date").IsRequired();
            entity.Property(x => x.MonthName).HasMaxLength(20).IsRequired();
            entity.HasIndex(x => x.Date).IsUnique();
        });
        modelBuilder.Entity<DimCurrency>(entity =>
        {
            entity.ToTable("DimCurrency");
            entity.HasKey(x => x.CurrencyKey);
            entity.Property(x => x.CurrencyCode).HasMaxLength(3).IsFixedLength().IsRequired();
            entity.Property(x => x.CurrencyName).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.CurrencyCode).IsUnique();
        });
        modelBuilder.Entity<FactGl>(entity =>
        {
            entity.ToTable("FactGL");
            entity.HasKey(x => x.FactGLKey);
            entity.Property(x => x.SourceSystem).HasMaxLength(50).IsRequired();
            entity.Property(x => x.SourceTransactionId).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Amount).HasPrecision(18, 2);
            entity.HasIndex(x => new { x.SourceSystem, x.SourceTransactionId }).IsUnique();
            entity.HasIndex(x => new { x.DateKey, x.AccountKey, x.EntityKey, x.CurrencyKey });
            entity.HasOne(x => x.Date).WithMany(x => x.Facts).HasForeignKey(x => x.DateKey);
            entity.HasOne(x => x.Account).WithMany(x => x.Facts).HasForeignKey(x => x.AccountKey);
            entity.HasOne(x => x.Entity).WithMany(x => x.Facts).HasForeignKey(x => x.EntityKey);
            entity.HasOne(x => x.Currency).WithMany(x => x.Facts).HasForeignKey(x => x.CurrencyKey);
        });
        modelBuilder.Entity<DimAccount>().HasData(SeedData.DimAccounts);
        modelBuilder.Entity<DimEntity>().HasData(SeedData.DimEntities);
        modelBuilder.Entity<DimDate>().HasData(SeedData.DimDates);
        modelBuilder.Entity<DimCurrency>().HasData(SeedData.DimCurrencies);
        modelBuilder.Entity<AccountMapping>().HasData(SeedData.AccountMappings);
    }
}
