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
    /// Логика взаимодействия для AddKlient.xaml
    /// </summary>
    public partial class AddKlient : Window
    {
        public AddKlient()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (family.Text != "" && name.Text != "" && last_n.Text != "" && phone.Text != "" &&
                pasport.Text != "" && birth.Text != "" && email.Text != "" && driv.Text != "" && address.Text != "")
            {
                err.Content = "";

                MessageBox.Show("Данные сохранены");

                var context = new CarRentalContext();

                Klient klient = new Klient
                {
                    LastName = family.Text,
                    FirstName = name.Text,
                    Patronymic = last_n.Text,
                    Phone = phone.Text,
                    Address = address.Text,
                    Email = email.Text,
                    Birthday = birth.Text,
                    DriversLicense = driv.Text,
                    Passport = pasport.Text
                };

                context.Klients.Add(klient);
                context.SaveChanges();
                this.Close();
            }
            else
            {
                err.Content = "Вы ввели не все данные!";
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
