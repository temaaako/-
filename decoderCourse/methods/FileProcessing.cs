using Microsoft.Office.Interop.Word;
using System.IO;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Word.Application;

namespace decoderCourse.methods
{
    class FileProcessing
    {
        //Метод, отвечающий за выбор файла в проводнике. Возвращает путь к этому файлу

        public static string ChooseFile()
        {
            string path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|docx (*.docx*)|*.docx*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
            }
            return path;
        }

        //Метод, отвечающий за запись текста в файл

        public static void SaveInFile(string result)
        {
           
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовый файл (*.txt)|*.txt|Документ Word (*.docx)|*.docx";
            saveFileDialog1.Title = "Сохранить текст";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                if (saveFileDialog1.FileName.Contains(".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, true))
                    {
                        sw.WriteLine(result);
                        sw.Close();
                    }
                }
                if (saveFileDialog1.FileName.Contains(".docx"))
                {
                   Application app = new Application();
                    app.Visible = true;
                    app.WindowState = WdWindowState.wdWindowStateNormal;

                    Document doc = app.Documents.Add();

                    Paragraph par = null;
                    par = doc.Paragraphs.Add();
                    par.Range.Text = result;

                    doc.SaveAs2(saveFileDialog1.FileName);
                    doc.Close();
                    app.Quit();

                }
            }

        }
    }
}
