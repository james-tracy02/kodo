using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Kodo
{
    public class Crypto
    {
        private const int keySize = 128;
        private const int iterations = 100;

        public static string Encrypt(string passCode, string plainText)
        {
            var saltStringBytes = GenerateBytes(16);
            var ivStringBytes = GenerateBytes(16);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (var password = new Rfc2898DeriveBytes(passCode, saltStringBytes, iterations))
            {
                var keyBytes = password.GetBytes(keySize / 8);
                using (var symmetricKey = Aes.Create())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Dispose();
                                cryptoStream.Dispose();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string passCode, string cipherText) 
        {
            var cipherTextBytesFull = Convert.FromBase64String(cipherText);

            var saltStringBytes = cipherTextBytesFull.Take(keySize / 8).ToArray();
            var ivStringBytes = cipherTextBytesFull.Skip(keySize / 8).Take(keySize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesFull.Skip((keySize / 8) * 2).Take(cipherTextBytesFull.Length - ((keySize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passCode, saltStringBytes, iterations))
            {
                var keyBytes = password.GetBytes(keySize / 8);
                using (var symmetricKey = Aes.Create())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Dispose();
                                cryptoStream.Dispose();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        public static byte[] GenerateBytes(int n)
        {
            var randomBytes = new byte[n];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
