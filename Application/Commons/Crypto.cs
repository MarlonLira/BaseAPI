using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Application.Commons
{
    public class Encoded
    {
        public string Key { get; private set; }
        public string Salt { get; private set; }
        public string Encrypted { get; private set; }

        public Encoded(byte[] key, byte[] salt)
        {
            Key = Convert.ToBase64String(key);
            Salt = Convert.ToBase64String(salt);
            Encrypted = $"{Key}\\{Salt}";
        }

        public Encoded(string encrypted)
        {
            Encrypted = encrypted;
            Key = Encrypted.Split('\\')[0];
            Salt = Encrypted.Split('\\')[1];
        }
    }
    public static class Crypto
    {
        private const string IV = "$2pImpR$2pAj12L8PA%";
        private const string Key = "$2p00*R$2pA222j12xz";

        public static Encoded EncryptPassword(string password)
        {
            try
            {
                using (var deriveBytes = new Rfc2898DeriveBytes(password, 20))
                {
                    byte[] salt = deriveBytes.Salt;
                    byte[] key = deriveBytes.GetBytes(20);

                    return new Encoded(key, salt);
                }
            }
            catch (Exception except)
            {
                throw new Exception(except.Message);
            }
        }

        public static bool ComparePassword(string password, Encoded encrypted)
        {
            var _salt = Convert.FromBase64String(encrypted.Salt);
            var _key = Convert.FromBase64String(encrypted.Key);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, _salt))
            {
                byte[] newKey = deriveBytes.GetBytes(20);

                if (!newKey.SequenceEqual(_key))
                    return false;
                else
                    return true;
            }
        }

        public static byte[] Encrypt(string input)
        {
            string keyMd5 = CreateHashMd5(Key);
            return encryptdata(Encoding.UTF8.GetBytes(input), keyMd5, IV);
        }

        public static byte[] Decrypt(byte[] encrypted)
        {
            string keyMd5 = CreateHashMd5(Key);
            return decryptdata(encrypted, keyMd5, IV);
        }

        public static string CreateHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        //AES
        static public byte[] encryptdata(byte[] bytearraytoencrypt, string key, string iv)
        {
            AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();

            dataencrypt.BlockSize = 128;

            dataencrypt.KeySize = 128;

            dataencrypt.Key = Encoding.UTF8.GetBytes(key);

            dataencrypt.IV = Encoding.UTF8.GetBytes(iv);

            dataencrypt.Padding = PaddingMode.PKCS7;

            dataencrypt.Mode = CipherMode.CBC;

            ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);
            byte[] encrypteddata = crypto1.TransformFinalBlock(bytearraytoencrypt, 0, bytearraytoencrypt.Length);
            crypto1.Dispose();

            return encrypteddata;
        }

        static public byte[] decryptdata(byte[] bytearraytodecrypt, string key, string iv)
        {
            AesCryptoServiceProvider keydecrypt = new AesCryptoServiceProvider();
            keydecrypt.BlockSize = 128;
            keydecrypt.KeySize = 128;
            keydecrypt.Key = Encoding.UTF8.GetBytes(key);
            keydecrypt.IV = Encoding.UTF8.GetBytes(iv);
            keydecrypt.Padding = PaddingMode.PKCS7;
            keydecrypt.Mode = CipherMode.CBC;
            ICryptoTransform crypto1 = keydecrypt.CreateDecryptor(keydecrypt.Key, keydecrypt.IV);

            byte[] returnbytearray = crypto1.TransformFinalBlock(bytearraytodecrypt, 0, bytearraytodecrypt.Length);
            crypto1.Dispose();
            return returnbytearray;
        }
    }
}
