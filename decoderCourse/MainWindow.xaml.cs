using decoderCourse.methods;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
namespace decoderCourse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Choose_Text_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainText.Text = WordProcessing.GetFileInfo(FileProcessing.ChooseFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добрый день! Спасибо, что проверяете эту работу :) В данной программе Вы можете зашифровать и дешифровать код при помощи метода Виженера. " +
                "Вы можете импортировать текст из файлов с расширениями .txt и .docx, а так же ввести с клавиатуры необходимую информацию в соответствующие поля. " +
                "Полученный текст вы сможете сохранить в отдельный файл с расширением .txt или .docx\n\nВерсия программы: 1.0");
        }
        private MediaPlayer player = new MediaPlayer();
        private bool musicOn=false;

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            if (musicOn)
            {
                player.Close();
                musicOn = false;
            }
            else
            {
                player.Open(new Uri(@"music\Stephan F - Astronomia 2K19.mp3", UriKind.Relative));
                player.Volume = 0.1;
                player.Play();
               
                musicOn = true;
            }
        }

        private void Code_click(object sender, RoutedEventArgs e)
        {
            if (MainText.Text != "")
            {
                if (KeyText.Text != "")
                {
                    ResultText.Text = Coder.Еncrypt(MainText.Text, KeyText.Text);
                }
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            try{
                FileProcessing.SaveInFile(ResultText.Text);
            }
            catch(Exception noArg)
            {
                MessageBox.Show(noArg.Message);
            }
        }



        private void Decode_click(object sender, RoutedEventArgs e)
        {
            if (MainText.Text != "")
            {
                if (KeyText.Text != "")
                {
                    ResultText.Text = Decoder.Decrypt(MainText.Text, KeyText.Text);
                }
            }
        }

        private void Choose_Key_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KeyText.Text = WordProcessing.GetFileInfo(FileProcessing.ChooseFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
