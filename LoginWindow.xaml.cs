using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metadata
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            textBlockVersion.Text = "Версия 1.0.0.0 ";
            textBlockCapsLock.Text = Console.CapsLock ? "Клавиша CapsLock нажата  " : "Клавиша CapsLock не нажата  ";
            string language = "";
            InputLanguageManager.Current.InputLanguageChanged += new InputLanguageEventHandler((sender, e) =>
                   {
                       language = e.NewLanguage.DisplayName;
                   });
            textBlockLanguage.Text = language;

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            textBlockCapsLock.Text = Console.CapsLock ? "Клавиша CapsLock нажата  " : "Клавиша CapsLock не нажата  ";

        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            string[] data = Reader.ReadUserData(textBoxLogin.Text, passwordBoxPassword.Password);
            if (data != null)
            {
                Window w = new MenuWindow(data);
                w.Show();
                Close();
            }
            else
            {
                textBlockerror.Text = "Логин или пароль введины неверно!";
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = "";
            passwordBoxPassword.Password = "";
        }
    }
}
