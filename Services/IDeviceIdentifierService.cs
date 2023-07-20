namespace ReadyPos.Services
{
    public interface IDeviceIdentifierService
    {
        string BindedDeviceIdentifierToPosId();
        string GenerateUniqueIdentifier();
        string GetBindedIdentifier();
        string GetDeviceUniqueIdentifier();
        string GetDummyPosId();
        void SetBindedIdentifier();
        void SetDeviceUniqueIdentifier();
        string VerifyIdentifier();
        void ClearIdentifierFromApplication();
    }
}