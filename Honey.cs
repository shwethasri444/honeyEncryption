using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Honey
    {
        int plaintextindex, seedend, seedstart;
        String seedvalue;
        static String[] intplaintext = new String[] { "a", "b", "c","d","e","f","g","h"};
        static int[] Inverse_table = new int[] { 0,1,2,3,4,5,6,7 };


        static public int Cdfpos(String plaintext)
        {
            return 0;
        }

        static public String Encrypt(String secretkey, String plaintext)
        {
            Honey lol = new Honey();
            lol.seedstart = Cdfpos("a") * 8 ;
            lol.seedend = lol.seedstart + 8;
            Random r = new Random();
            int rInt = r.Next(lol.seedstart, lol.seedend);
            Console.WriteLine(rInt);
            var binary = Convert.ToString(rInt, 2);
            binary = binary.PadLeft(6, '0');

            Char[] cipher = new Char[6];
            if (secretkey == "111000")
                lol.seedvalue = binary;
            else
            {
                Random rand = new Random();
                int randInt = rand.Next(lol.seedend, 64);
                var binary1 = Convert.ToString(randInt, 2);
                binary1 = binary1.PadLeft(6, '0');
                lol.seedvalue = binary1;
            }
            Console.WriteLine(lol.seedvalue);
            Char[] charArray = secretkey.ToCharArray();
            Char[] charArr = lol.seedvalue.ToCharArray();
            for (int i = 0; i < 6; i++)
            {
                cipher[i] = (Char)(charArray[i] ^ charArr[i]);
                Console.WriteLine(cipher[i]);

            }
            for (int i = 0; i < 6; i++)
            {
                charArr[i] = (Char)(secretkey[i] ^ cipher[i]);
                //Console.WriteLine(secretkey[i]); 
                //Console.WriteLine(i); 
            }
            int cdfvalue = Convert.ToInt32(lol.seedvalue,2) / 8;
            for (int i = 0; i < 8; i++)
            {
                if (Inverse_table[i] == cdfvalue)
                    lol.plaintextindex = i;
            }
            Console.WriteLine("End of the class");
            Console.WriteLine(intplaintext[lol.plaintextindex]);
            return intplaintext[lol.plaintextindex];

        }

    }
}
