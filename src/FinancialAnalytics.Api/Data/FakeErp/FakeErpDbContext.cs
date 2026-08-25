using Microsoft.EntityFrameworkCore;

namespace FinancialAnalytics.Api;

public sealed class FakeErpDbContext(DbContextOptions<FakeErpDbContext> options) : DbContext(options)
{
    public DbSet<ErpAccount> Accounts => Set<ErpAccount>();
    public DbSet<ErpEntity> Entities => Set<ErpEntity>();
    public DbSet<ErpTransaction> Transactions => Set<ErpTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ErpAccount>(entity =>
        {
            entity.ToTable("Account");
            entity.HasKey(x => x.AccountId);
            entity.Property(x => x.AccountCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.AccountName).HasMaxLength(200).IsRequired();
            entity.HasIndex(x => x.AccountCode).IsUnique();
        });
        modelBuilder.Entity<ErpEntity>(entity =>
        {
            entity.ToTable("Entity");
            entity.HasKey(x => x.EntityId);
            entity.Property(x => x.EntityCode).HasMaxLength(50).IsRequired();
            entity.Property(x => x.EntityName).HasMaxLength(200).IsRequired();
            entity.Property(x => x.CountryCode).HasMaxLength(2).IsFixedLength().IsRequired();
            entity.HasIndex(x => x.EntityCode).IsUnique();
        });
        modelBuilder.Entity<ErpTransaction>(entity =>
        {
            entity.ToTable("Transaction");
            entity.HasKey(x => x.TransactionId);
            entity.Property(x => x.TransactionId).HasMaxLength(50);
            entity.Property(x => x.Amount).HasPrecision(18, 2);
            entity.Property(x => x.CurrencyCode).HasMaxLength(3).IsFixedLength().IsRequired();
            entity.Property(x => x.Description).HasMaxLength(500);
            entity.Property(x => x.TransactionDate).HasColumnType("date");
            entity.HasIndex(x => new { x.TransactionDate, x.AccountId });
            entity.HasIndex(x => x.EntityId);
            entity.HasOne(x => x.Account).WithMany(x => x.Transactions).HasForeignKey(x => x.AccountId);
            entity.HasOne(x => x.Entity).WithMany(x => x.Transactions).HasForeignKey(x => x.EntityId);
        });
        modelBuilder.Entity<ErpAccount>().HasData(SeedData.ErpAccounts);
        modelBuilder.Entity<ErpEntity>().HasData(SeedData.ErpEntities);
        modelBuilder.Entity<ErpTransaction>().HasData(SeedData.ErpTransactions);
    }
}
