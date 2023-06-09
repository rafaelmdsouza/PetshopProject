namespace Petshop.Infrastructure.Queries.Resources;

public class QueriesResource
{
    public static string OwnerQuery => @"
            SELECT
            o.Id, o.Name, o.Age, o.Email, o.Phone,o.IsActive, o.RegistrationDate, o.LastModified,
            p.Id AS Id, p.OwnerId AS OwnerId, p.Name AS PetName, p.Age AS PetAge, p.Type AS PetType, p.IsVaccinated AS PetIsVaccinated
            FROM Owner o
            JOIN Pet p ON o.Id = p.OwnerId
            WHERE o.Id = @Id OR @Id is NULL
        ";
}