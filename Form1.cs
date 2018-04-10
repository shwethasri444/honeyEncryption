using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp1
{
        public partial class Form1 : Form
        {

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            byte[] plaintext;
            byte[] encryptedtext;
            byte[] decryptedtext;



            public Form1()
            {
                InitializeComponent();
            }

            private void button1_Click(object sender, EventArgs e)
            {
            //int numVal = Int32.Parse("abc");
            //Console.WriteLine(numVal);
            Console.WriteLine("im starting");

            Class1.generateKeys();
            String line = "#FD2300";
            plaintext = ByteConverter.GetBytes(line);
            encryptedtext = Class1.Encryption(plaintext);
            Console.WriteLine(ByteConverter.GetString(encryptedtext));
            //FileInfo MyFile = new FileInfo(@"C:\Users\lenovo\source\repos\ImageProcessingInit\ImageProcessingInit\bin\Debug\gray.txt");
            //StreamWriter sw = new StreamWriter(@"C: \Users\lenovo\writefile2.txt");
            //StreamReader sr = MyFile.OpenText();
            //line = sr.ReadLine(); 
            //string fileInput = sr.ReadToEnd();
            //for(int i = 0; i<3; i++)
            //{
            //    Console.WriteLine(line);
            //    plaintext = ByteConverter.GetBytes(line);
            //    encryptedtext = Convert.Encryption(plaintext);
            //    Console.WriteLine(ByteConverter.GetString(encryptedtext));
            //    sw.WriteLine(ByteConverter.GetString(encryptedtext)); 
            //}


            //sw.Close();
            //sr.Close();
            }

        public static byte[] ConvertInt32ToByteArray(Int32 I32)

        {

            return BitConverter.GetBytes(I32);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //StreamReader sr = new StreamReader(@"C:\Users\lenovo\writefile2.txt");
            //String line;
            //line = sr.ReadToEnd();
            // while(line!=null)
            // {
            //     plaintext = ByteConverter.GetBytes(line);
            //     Console.WriteLine(line); 
            //     decryptedtext = Convert.Decryption(plaintext);
            //     Console.WriteLine(ByteConverter.GetString(decryptedtext));
            //    line = sr.ReadLine();
            //}


            //Console.WriteLine("done I guess");

            decryptedtext = Class1.Decryption(encryptedtext);
            Console.WriteLine(ByteConverter.GetString(decryptedtext));

        }

         
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (this.textBox1.Text != "")
        //    {
        //        listBox1.Items.Add(this.textBox1.Text);
        //    }
        //}
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\Users\shwet\Desktop\secret.txt", textBox1.Text);
            StreamReader key = new StreamReader(@"C:\Users\shwet\Desktop\secret.txt");
            String secret;
            secret = key.ReadToEnd();
            Honey.Encrypt(secret, "lolol");
            Console.WriteLine(secret);
        }

    }

}
