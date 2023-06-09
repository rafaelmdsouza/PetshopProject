using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Petshop.Infrastructure.Queries.Core;

public class DbDataProvider : IDbDataProvider
{
    private readonly string _connectionString;

    public DbDataProvider(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}