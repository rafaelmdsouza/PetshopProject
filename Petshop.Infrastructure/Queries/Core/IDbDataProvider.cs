using System.Data;

namespace Petshop.Infrastructure.Queries.Core;

public interface IDbDataProvider
{
    IDbConnection GetConnection();
}