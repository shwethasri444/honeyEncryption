using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel; 
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Class1
    {
        private static RSAParameters publicKey;
        private static RSAParameters privateKey;
       //static string CONTAINER_NAME = "MyContainer";
        public enum KeySizes
        {
            SIZE_512 = 512,
            SIZE_1024 = 1024,
            SIZE_2048 = 2048

        }
        static public void generateKeys()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false; //to not store the keys in a key container
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);
                //Console.WriteLine(privateKey);

            }



        }
        static public byte[] Decryption(byte[] Data)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {
                RSA.PersistKeyInCsp = false;
                RSA.ImportParameters(privateKey);
                decryptedData = RSA.Decrypt(Data, true);
            }

            return decryptedData;

        }
        static public byte[] Encryption(byte[] Data)
        {

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048))
            {
                RSA.PersistKeyInCsp = false;
                RSA.ImportParameters(publicKey);
                encryptedData = RSA.Encrypt(Data, true);
            }
            return encryptedData;


        }
    }
}
