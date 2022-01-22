using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derivco_Encrypter.Classes
{
    public static class Transcoder
    {
        public static char[] transcode = new char[65];

        public static void SetTranscoderType1()
        {
            for (int i = 0; i < 65; i++)
            {
                transcode[i] = (char)((int)'A' + i);
                if (i > 25) transcode[i] = (char)((int)transcode[i] + 6);
                if (i > 51) transcode[i] = (char)((int)transcode[i] - 0x4b);
            }
            transcode[62] = '+';
            transcode[63] = '/';
            transcode[64] = '=';
        }
    }
}
