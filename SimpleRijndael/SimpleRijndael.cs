using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Alp3476
{
    public static class SimpleRijndael
    {
        public static string Encrypt(string inputText, string password)
        {
            string encryptedData = string.Empty;
            using (RijndaelManaged rij = new RijndaelManaged())
            {
                byte[] inputBytes = Encoding.Unicode.GetBytes(inputText);
                byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());

                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);
                ICryptoTransform encryptor = rij.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));

                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                    cs.Write(inputBytes, 0, inputBytes.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray();
                    encryptedData = Convert.ToBase64String(cipherBytes);
                }
            }

            return encryptedData;
        }

        public static string Decrypt(string inputText, string password)
        {
            string decryptedData = string.Empty;

            using (RijndaelManaged rij = new RijndaelManaged())
            {
                byte[] encryptedData = Convert.FromBase64String(inputText);

                byte[] salt = Encoding.ASCII.GetBytes(password.Length.ToString());
                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(password, salt);
                ICryptoTransform decryptor = rij.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));

                using (MemoryStream ms = new MemoryStream(encryptedData))
                {
                    CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                    byte[] plainText = new byte[encryptedData.Length];
                    int decryptedCount = cs.Read(plainText, 0, plainText.Length);
                    decryptedData = Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                }
            }

            return decryptedData;

        }
    }
}
