namespace Petshop.Domain.Exceptions;

public class NullException : DomainException
{
    public NullException(string message) : base(message)
    {
    }
}