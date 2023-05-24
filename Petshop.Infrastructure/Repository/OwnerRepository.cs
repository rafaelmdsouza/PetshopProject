using Petshop.Domain.Agreggate.OwnerAggregate;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Petshop.Infrastructure.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;
    public OwnerRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<IReadOnlyList<Owner>> GetAllAsync()
    {
        using var con = new SqlConnection(connectionString);

        var query = @"
            SELECT
            o.Id, o.Name, o.Age, o.Email, o.Phone,
            p.Id AS Id, p.OwnerId AS OwnerId, p.Name AS Name, p.Age AS Age, p.Type AS Type, p.IsVaccinated AS IsVaccinated,
            o.IsActive, o.RegistrationDate, o.LastModified
            FROM Owner o
            LEFT JOIN Pet p ON o.Id = p.OwnerId
            ;
        ";

        var owners = new Dictionary<Guid, Owner>();

        await con.QueryAsync<Owner, Pet, Owner>(query,
            (owner, pet) =>
            {
                if (!owners.TryGetValue(owner.Id, out var currentOwner))
                {
                    currentOwner = owner;
                    owners.Add(currentOwner.Id, currentOwner);
                }
                if (pet != null)
                    currentOwner.RegisterPet(pet);
                return currentOwner;
            },
            
            splitOn: "Id"
        );

        return owners.Values.ToList();
    }
    public async Task<Owner> GetByIdAsync(Guid id)
    {
        using var con = new SqlConnection(connectionString);
        var query = @"
            SELECT
            o.Id, o.Name, o.Age, o.Email, o.Phone,
            p.Id AS PetId, p.OwnerId AS OwnerId, p.Name AS PetName, p.Age AS PetAge, p.Type AS PetType, p.IsVaccinated AS PetIsVaccinated,
            o.IsActive, o.RegistrationDate, o.LastModified
            FROM Owner o
            LEFT JOIN Pet p ON o.Id = p.OwnerId
            WHERE o.Id = @Id
        ";

                var owners = new Dictionary<Guid, Owner>();

        await con.QueryAsync<Owner, Pet, Owner>(query,
            (owner, pet) =>
            {
                if (!owners.TryGetValue(owner.Id, out var currentOwner))
                {
                    currentOwner = owner;
                    owners.Add(currentOwner.Id, currentOwner);
                }
                if (pet != null)
                    currentOwner.RegisterPet(pet);
                return currentOwner;
            },
            new { Id = id },
            splitOn: "Id"
        );

        return owners.Values.FirstOrDefault();
    }
    public void Add(Owner entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(Guid id, Owner entity)
    {
        throw new NotImplementedException();
    }
    public void Update(Guid id, Owner entity)
    {
        throw new NotImplementedException();
    }
}