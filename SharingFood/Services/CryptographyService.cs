using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
namespace SharingFood.Services
{
    public interface ICryptographyService
    {
        string ToSHA1(string input);
        string ToBase64String(MediaFile path);
        ImageSource FromBase64String(string base64Image);
    }

    public class CryptographyService : ICryptographyService
    {
        public string ToSHA1(string input)
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

        public string ToBase64String(MediaFile file)
        {
            byte[] bytes = null;

            using (var ms = new MemoryStream())
            {
                file.GetStream().CopyTo(ms);
                bytes = ms.ToArray();
            }

            return Convert.ToBase64String(bytes);
        }

        public ImageSource FromBase64String(string base64Image)
        {
            byte[] base64Stream = Convert.FromBase64String(base64Image);

            return ImageSource.FromStream(() => new MemoryStream(base64Stream));
        }
    }
}
