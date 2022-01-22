using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derivco_Encrypter.Classes
{
    public static class Encoder
    {
        public static string encode(string input)
        {
            int l = input.Length;
            int cb = (l / 3 + (Convert.ToBoolean(l % 3) ? 1 : 0)) * 4;      
            
            char[] output = new char[cb];
            for (int i = 0; i < cb; i++)
            {
                output[i] = '=';
            }

            int c = 0;
            int reflex = 0;
            const int s = 0x3f;

            for (int j = 0; j < l; j++)
            {
                reflex <<= 8;
                reflex &= 0x00ffff00;
                reflex += input[j];

                int x = ((j % 3) + 1) * 2;
                int mask = s << x;
                while (mask >= s)
                {
                    int pivot = (reflex & mask) >> x;
                    output[c++] = Transcoder.transcode[pivot];
                    int invert = ~mask;
                    reflex &= invert;
                    mask >>= 6;
                    x -= 6;
                }
            }

            switch (l % 3)
            {
                case 1:
                    reflex <<= 4;
                    output[c++] = Transcoder.transcode[reflex];
                    break;

                case 2:
                    reflex <<= 2;
                    output[c++] = Transcoder.transcode[reflex];
                    break;

            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }
    }
}
