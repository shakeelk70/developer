using CodingTest.Database.Mapping;
using CodingTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using SQLitePCL;

namespace CodingTest.Database;

public class CodingTestContext : DbContext, IRepository
{

    private readonly string dbPath;

    public CodingTestContext()
    {
        dbPath = "coding_test.db";
    }

    public CodingTestContext(IConfiguration configuration)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        dbPath = configuration.GetConnectionString("WebApiDatabase") ?? System.IO.Path.Join(path, "coding_test.db");
    }

    public IQueryable<TEntity> Query<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ClaimantMapping());
        modelBuilder.ApplyConfiguration(new CompanyMapping());
    }

    public TEntity? GetEntity<TEntity>(int id) where TEntity : class, IEntity
    {
        return GetEntity<TEntity>(e => e.Id == id);
    }

    public TEntity? GetEntity<TEntity>(Func<TEntity, bool> func) where TEntity : class
    {
        throw new NotImplementedException();
    }
}
