using System;
using System.Collections.Generic;
using System.Text;

namespace SharingFood.Services
{
    public interface ICryptographyService
    {
        string Encode(string input);
    }

    public class CryptographyService : ICryptographyService
    {
        public string Encode(string input)
        {
            using (System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create())
            {
                if (string.IsNullOrWhiteSpace(input))
                    return string.Empty;

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}
