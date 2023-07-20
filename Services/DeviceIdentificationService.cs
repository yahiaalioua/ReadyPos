using ReadyPos.Exceptions;
using ReadyPos.Services;
using System;
using Xamarin.Essentials;
using DependencyAttribute = Xamarin.Forms.DependencyAttribute;
[assembly: Dependency(typeof(DeviceIdentifierService))]
namespace ReadyPos.Services
{
    public class DeviceIdentifierService : IDeviceIdentifierService
    {
        public string GenerateUniqueIdentifier()
        {
            string identifier = Guid.NewGuid().ToString();
            return identifier;
        }

        public string GetDummyPosId()
        {
            return "posId1";
        }

        public void SetDeviceUniqueIdentifier()
        {
            var deviceId = Preferences.Get("deviceId", string.Empty);
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                deviceId = GenerateUniqueIdentifier();
                Preferences.Set("deviceId", deviceId);
            }
        }
        public string GetDeviceUniqueIdentifier()
        {
            var deviceId = Preferences.Get("deviceId", string.Empty);
            if (string.IsNullOrWhiteSpace(deviceId))
            {
                deviceId = GenerateUniqueIdentifier();
                Preferences.Set("deviceId", deviceId);
                return deviceId;
            }
            else
                return deviceId;
        }
        public void SetBindedIdentifier()
        {
            var bindedDeviceId = Preferences.Get("bindedDeviceId", string.Empty);
            if (string.IsNullOrWhiteSpace(bindedDeviceId))
            {
                bindedDeviceId = BindedDeviceIdentifierToPosId();
                Preferences.Set("bindedDeviceId", bindedDeviceId);
            }
        }
        public string GetBindedIdentifier()
        {
            var bindedDeviceId = Preferences.Get("bindedDeviceId", string.Empty);
            return bindedDeviceId;
        }

        public string BindedDeviceIdentifierToPosId()
        {
            string bindedIdentifier = $"{GetDeviceUniqueIdentifier()}{GetDummyPosId()}";
            return bindedIdentifier;
        }

        public string VerifyIdentifier()
        {
            var posId = GetDummyPosId();
            var deviceId = GetDeviceUniqueIdentifier();
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new PosIdNotProvidedDomainException($"{nameof(VerifyIdentifier)} exception, POS ID can´t be null");

            if (string.IsNullOrWhiteSpace(posId))
                throw new DeviceIdNotProvidedDomainException($"{nameof(VerifyIdentifier)} exception, Device ID can´t be null");

            string BindedDeviceIdentifier = GetBindedIdentifier();
                if ($"{deviceId}{posId}" == BindedDeviceIdentifier)                
                    return "PosId 1";                
                else
                    return "PosId 0";
            }

        public void ClearIdentifierFromApplication()
        {
            Preferences.Set("deviceId", null);
            Preferences.Set("bindedDeviceId", null);
        }

    }
}