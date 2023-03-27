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
    /// Логика взаимодействия для KlientInfo.xaml
    /// </summary>
    public partial class KlientInfo : Window
    {
        public Klient Klient { get; }
        public KlientInfo(Klient klient)
        {
            Klient = klient;
            InitializeComponent();
            this.Left = 400;
            this.Top = 100;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
