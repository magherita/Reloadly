using System;
using System.Security.Cryptography;
using System.Text;

namespace ApiWrapper.FlutterwaveClient
{
    public static class Extensions
    {
        public static string Encrypt(this string toEncrypt, string key)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(key);
            byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;

            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;

            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();

            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);

            //Release resources held by TripleDes Encryptor
            tdes.Clear();

            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
