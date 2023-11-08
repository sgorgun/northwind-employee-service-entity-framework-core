using Microsoft.EntityFrameworkCore;

namespace NorthwindEmployeeEfCoreService.Tests;

public class SqliteDbContextFactory : IDbContextFactory<EmployeeContext>
{
    /// <summary>
    /// The connection string for the in-memory SQLite database.
    /// </summary>
    public const string ConnectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";

    public EmployeeContext CreateDbContext() =>
        new(new DbContextOptionsBuilder<EmployeeContext>().UseSqlite(ConnectionString).Options);
}
