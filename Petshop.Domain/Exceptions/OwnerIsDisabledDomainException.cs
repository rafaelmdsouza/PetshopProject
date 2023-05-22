namespace Petshop.Domain.Exceptions;

public class OwnerIsDisabledDomainException : DomainException
{
    public OwnerIsDisabledDomainException(string message) : base(message)
    {
    }
}