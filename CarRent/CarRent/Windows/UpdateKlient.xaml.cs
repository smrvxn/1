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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRent.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateKlient.xaml
    /// </summary>
    public partial class UpdateKlient : Window
    {
        public Klient Klient { get; }
        public UpdateKlient(Klient klient)
        {
            Klient = klient;
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e) //не сохраняется
        {
            try
            {
                Session.Instance.Context.SaveChanges();
                MessageBox.Show("Данные сохранены.");
                this.Close();
            }
            catch
            {
                MessageBox.Show("При сохранении данных возникла ошибка!");
                if (Klient.KlientId == 0)
                {
                    Session.Instance.Context.Remove(Klient);
                }
            }
        }
    }
}
