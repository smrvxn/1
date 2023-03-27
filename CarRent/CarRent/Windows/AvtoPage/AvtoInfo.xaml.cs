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
    /// Логика взаимодействия для AvtoInfo.xaml
    /// </summary>
    public partial class AvtoInfo : Window
    {
        public Avto Avto { get; }
        public AvtoInfo(Avto avto)
        {
            Avto = avto;
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
