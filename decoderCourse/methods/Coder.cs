
namespace decoderCourse.methods
{
    abstract public class Coder: WordProcessing
    {
        //Метод, отвечающий за шифрование текста

        public static string Еncrypt(string text, string key)
        {
            int keyCount= 0;
            char[] charText = text.ToCharArray();
            int[] digitalKey = GetDigitalKey(key,text);
            for (int i = 0; i < charText.Length; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if (charText[i] == alphabet[j])
                    {
                        charText[i] = alphabet[(j + digitalKey[keyCount]) % n];
                        keyCount++;
                        break;
                    }
                    if (charText[i] == alphabetUpper[j])
                    {
                        charText[i] = alphabetUpper[(j + digitalKey[keyCount]) % n];
                        keyCount++;
                        break;
                    }
                }
            }
            string code = new string(charText);
            return code;
        }
    }
}
