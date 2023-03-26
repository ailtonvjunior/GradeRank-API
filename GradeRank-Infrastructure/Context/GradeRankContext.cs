using GradeRank_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace GradeRank_Infrastructure.Context
{
  public class GradeRankContext : DbContext
  {

    private IDbConnection _connection;
    public IDbConnection Connection
    {
      get
      {
        if (_connection.State == ConnectionState.Open) return _connection;

        _connection.Open();

        while (_connection.State == ConnectionState.Connecting) { }

        return _connection;
      }
      private set => _connection = value;
    }

    public virtual DbSet<HealthStatusDbo> HealthStatus { get; set; }

    public GradeRankContext()
    {

    }

    public GradeRankContext(DbContextOptions<GradeRankContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(GradeRankContext).Assembly);
    }
  }
}