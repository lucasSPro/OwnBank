using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ownbank.application.Services.Cryptography
{
    public class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            var apiKey = "apiOB";
            var newPassword = $"{password}{apiKey}";
            var bytes =  Encoding.UTF8.GetBytes(newPassword);
            var hashBytes = SHA512.HashData(bytes);

            return StringBytes(hashBytes); 
        }

        private static string StringBytes(byte[] bytes) 
        {
            var stringBytes =  new StringBuilder();
            foreach (byte b in bytes) 
            {
                var hex = b.ToString("x2");
                stringBytes.Append(hex);
            }

            return stringBytes.ToString();
        }
    }
}
