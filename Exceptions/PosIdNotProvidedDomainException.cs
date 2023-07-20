
using ReadyPos.Exceptions;

namespace ReadyPos.Services
{
    public sealed class PosIdNotProvidedDomainException : DomainException
    {
        public PosIdNotProvidedDomainException(string message) : base(message)
        {
        }
    }
}