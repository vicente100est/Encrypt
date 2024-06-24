using Microsoft.AspNetCore.DataProtection;
using System.Text;

namespace Encrypt.WebService.Domain
{
    public class EncryptService
    {
        private readonly IDataProtector _dataProtector;
        public EncryptService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("Card");
        }

        public byte[] EncryptData(string plainText)
        {
            var bytes = Encoding.UTF8.GetBytes(plainText);
            return _dataProtector.Protect(bytes);
        }

        public string DecryptData(byte[] encryptData)
        {
            var bytes = _dataProtector.Unprotect(encryptData);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
