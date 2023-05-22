namespace Petshop.Domain.Exceptions;

public class OwnerIsEnabledDomainException : DomainException
{
    public OwnerIsEnabledDomainException(string message) : base(message)
    {
    }
}