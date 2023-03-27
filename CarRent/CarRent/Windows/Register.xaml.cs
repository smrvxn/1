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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

            if (family.Text == "")
            {
                error1.Content = "Поле не заполнено";
            }
            if (name.Text == "")
            {
                error2.Content = "Поле не заполнено";
            }
            if (last_name.Text == "")
            {
                error3.Content = "Поле не заполнено";
            }
            if (phone.Text == "")
            {
                error4.Content = "Поле не заполнено";
            }
            if (log.Text == "")
            {
                error5.Content = "Поле не заполнено";
            }
            if (password.Text == "")
            {
                error6.Content = "Поле не заполнено";
            }
            if (password2.Text == "")
            {
                error7.Content = "Поле не заполнено";
            }
            if (password2.Text != password.Text)
            {
                error7.Content = "Пароли не совпадают!";
            }

            if (family.Text != "")
            {
                error1.Content = "";
            }
            if (name.Text != "")
            {
                error2.Content = "";
            }
            if (last_name.Text != "")
            {
                error3.Content = "";
            }
            if (phone.Text != "")
            {
                error4.Content = "";
            }
            if (log.Text != "")
            {
                error5.Content = "";
            }
            if (password.Text != "")
            {
                error6.Content = "";
            }
            if (password2.Text == password.Text)
            {
                error7.Content = "";
            }

            if (family.Text != "" && name.Text != "" && last_name.Text != "" && phone.Text != ""
                && log.Text != "" && password.Text != "" && password2.Text != "" && password.Text == password2.Text)
            {
                error1.Content = "";
                error2.Content = "";
                error3.Content = "";
                error4.Content = "";
                error5.Content = "";
                error6.Content = "";
                error7.Content = "";

                MessageBox.Show("Данные сохранены");

                var context = new CarRentalContext();

                Manager manager = new Manager
                {
                    LastName = family.Text,
                    FirstName = name.Text,
                    Patronymic = last_name.Text,
                    Phone = phone.Text,
                    Login = log.Text,
                    Password = password.Text,

                };

                context.Managers.Add(manager);
                context.SaveChanges();

                MainWindow login = new MainWindow();
                login.Show();
                this.Close();
            }
        }
    }
}
