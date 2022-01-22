using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derivco_Encrypter.Classes
{
    public static class Decoder
    {
        public static string decode(string input)
        {
            int l = input.Length;
            int cb = (l / 4 + ((Convert.ToBoolean(l % 4)) ? 1 : 0)) * 3;

            char[] output = new char[cb];
            int c = 0;
            int bits = 0;
            int reflex = 0;

            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (!fTerminate)
                    reflex += indexOf(input[j]);

                if (fTerminate)
                {
                    output = output.Take(c).ToArray();
                    break;
                }
                    
                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output[c++] = (char)((reflex & mask) >> (bits % 8));
                    int invert = ~mask;
                    reflex &= invert;
                    bits -= 8;
                }
            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }

        private static int indexOf(char ch)
        {
            int index;
            for (index = 0; index < Transcoder.transcode.Length; index++)
                if (ch == Transcoder.transcode[index])
                    break;
            return index;
        }
    }
}
