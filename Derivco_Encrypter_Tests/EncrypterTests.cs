using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Derivco_Encrypter.Classes;
using System.Linq;

namespace Derivco_Encrypter_Tests
{
    [TestClass]
    public class EncrypterTests
    {
        [TestMethod]
        public void test_string1()
        {
            string test_string = "This is a test string";
            Transcoder.SetTranscoderType1();

            Assert.IsTrue(String.Equals(test_string, Decoder.decode(Encoder.encode(test_string))));
        }

        [TestMethod]
        public void test_string2()
        {
            string test_string = "ThgfdlcGDsdgcflsdGFLHJ==sdfc!!%$·()??ljkh;;,:..--__¨Ç`+´ç¨´çsdhfjkhhsdlKFC@@@2E789732894E732987h";
            Transcoder.SetTranscoderType1();

            Assert.IsTrue(String.Equals(test_string, Decoder.decode(Encoder.encode(test_string))));
        }

        [TestMethod]
        public void testRandomString()
        {
            Transcoder.SetTranscoderType1();
            Random random = new Random();

            string str = "!$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

            for (int i = 0; i < 500; i++)
            {
                string test_string = new string(Enumerable.Repeat(str.ToCharArray(), random.Next(5000))
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                Assert.IsTrue(String.Equals(test_string, Decoder.decode(Encoder.encode(test_string))));
            }
        }
    }
}
