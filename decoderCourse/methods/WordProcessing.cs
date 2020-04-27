using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Word.Application;

namespace decoderCourse.methods
{
    abstract public class WordProcessing
    {
        public static char[] alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        public static char[] alphabetUpper = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToUpper().ToCharArray();
        public static int n = alphabet.Length;

        
        //Метод для получения содержимого файла, путь к которому передается в параметр

        public static string GetFileInfo(string path)
        {
            string content = "";
            if (path.Contains(".txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        content = reader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return content;
            }
            if (path.Contains(".docx"))
            {
                Application application = new Application();
                Document document = application.Documents.Open(path);

                int count = document.Words.Count;
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= count-1; i++)
                {
                    // Write the word.
                    sb.Append(document.Words[i].Text);
                }
                application.Quit();
                content = sb.ToString();
            }
            return content;
            
        }

        //Метод для преобразования строкового ключа к массиву чисел. 
        //Каждое число - это величина, на которую нужно сместить букву в строке
        //Передаваемые параметры: строковые значения ключа и текста

        public static int[] GetDigitalKey(string password, string text)
        {
            while (password.Length < text.Length)
            {
                password += password;
            }
            int[] keyInt = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (password[i] == alphabet[j] || password[i] == alphabetUpper[j])
                    {
                        keyInt[i] = j;
                    }
                }
            }
            return keyInt;
        }
    }
}
