using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using decoderCourse.methods;

namespace decoderCourse.Tests
{
    [TestClass]
    public class MyCoderTests
    {
        [TestMethod]
        public void Еncrypt_яЕстьГрут_and_Ракета_ПЕьчоГбуэ_returned()
        {
            //arrange
            string text = "я есть Грут!";
            string key = "Ракета";
            string expected = "п еьчо Гбуэ!";
            //act
            string actual = Coder.Еncrypt(text, key);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Decrypt_ърьтднмдупёрзфе_and_звезда_ПЕьчоГбуэ_returned()
        {
            //arrange
            string text = "ърьтднмдупёрзфе";
            string key = "звезда";
            string expected = "точканевозврата";
            //act
            string actual = Decoder.Decrypt(text, key);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFileInfo_textForTestTXT_NowYouSeeSharp_returned()
        {
            //arrange
            string path = @"text_for_test.txt";
            string expected = "NowYouSeeSharp";
            //act
            string actual = WordProcessing.GetFileInfo(path);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetFileInfo_wordTextForTestDocx_helloThere_returned()
        {
            //arrange
            string path = Environment.CurrentDirectory + @"\word_text_for_test.docx";
            string expected = "-hello there!";
            //act
            string actual = WordProcessing.GetFileInfo(path);
            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetDigitalKey_ааАая_and_переворот_111132111132_returned()
        {
            //arrange
            string text = "переворот";
            string key = "ааАая";
            int[] expected = new int[9] { 0,0,0,0,32,0,0,0,0};
            //act
            int[] actual = WordProcessing.GetDigitalKey(key,text);
            //assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
