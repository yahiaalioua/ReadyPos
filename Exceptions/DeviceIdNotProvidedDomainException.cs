namespace ReadyPos.Exceptions
{
    public sealed class DeviceIdNotProvidedDomainException : DomainException
    {
        public DeviceIdNotProvidedDomainException(string message) : base(message)
        {
        }
    }
}