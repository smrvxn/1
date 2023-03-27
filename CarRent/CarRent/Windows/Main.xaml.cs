using CarRent.Models;
using CarRent.Windows.AvtoPage;
using Prism.Services.Dialogs;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public CarRentalContext db;
        public Main()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            db = new CarRentalContext();

            this.Closing += MainWindow_Closing;
        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new KlientPage());
        }

        private void avto_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new AvtoPage.AvtoPage());
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = new MessageBoxResult();
            res = MessageBox.Show("Вы действительно хотите выйти?",
                "Выход",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if(res == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}
