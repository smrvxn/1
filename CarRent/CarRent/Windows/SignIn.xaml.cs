using CarRent.Models;
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

namespace CarRent.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text != "" && password.Text != "")
            {
                var context = new CarRentalContext();
                if (context.Managers.Any(u => u.Login == login.Text && u.Password == password.Text))
                {
                    Main nf = new Main();
                    nf.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль введен не верно!");
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
