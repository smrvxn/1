using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CarRent.Windows.AvtoPage
{
    /// <summary>
    /// Логика взаимодействия для AvtoPage.xaml
    /// </summary>
    public partial class AvtoPage : Page
    {
        public ObservableCollection<Avto> Avtos { get; private set; }
        public AvtoPage()
        {
            Avtos = new ObservableCollection<Avto>(Session.Instance.Context.Avtos);
            InitializeComponent();          
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            var avto = (sender as Button)?.DataContext as Avto;
            if (avto == null) return;
            AvtoInfo info = new AvtoInfo(avto);
            info.Show();
        }

        private IQueryable<Avto> applySearch(IQueryable<Avto> query) =>       
            query.Where(q => q.Mark.Contains(poisk.Text) || q.Manufacturer.Contains(poisk.Text)
            || q.YearOfProduction.Contains(poisk.Text));

        private IQueryable<Avto> applyClassesFilter(IQueryable<Avto> query)
        {
            if (classBox.SelectedItem == null)
            {
                return query;
            }

            var filterComboBoxItem = (KeyValuePair<string, Func<IQueryable<Avto>, IQueryable<Avto>>>)classBox.SelectedItem;
            var filterFunc = filterComboBoxItem.Value;
            return filterFunc(query);
        }

        private IQueryable<Avto> applyBrandsFilter(IQueryable<Avto> query)
        {
            if (brendBox.SelectedItem == null)
            {
                return query;
            }

            var filterComboBoxItem = (KeyValuePair<string, Func<IQueryable<Avto>, IQueryable<Avto>>>)brendBox.SelectedItem;
            var filterFunc = filterComboBoxItem.Value;
            return filterFunc(query);
        }

        public Dictionary<string, Func<IQueryable<Avto>, IQueryable<Avto>>> ClassFilters { get; set; } =
        new Dictionary<string, Func<IQueryable<Avto>, IQueryable<Avto>>>
        {
            { "Все", q => q },
            { "A", q => q.Where(Avto => Avto.ClassName == "A") },
            { "B", q => q.Where(Avto => Avto.ClassName == "B") },
            { "C", q => q.Where(Avto => Avto.ClassName == "C") },
            { "D", q => q.Where(Avto => Avto.ClassName == "D") },
            { "E", q => q.Where(Avto => Avto.ClassName == "E") },
            { "F", q => q.Where(Avto => Avto.ClassName == "F") },
            { "S", q => q.Where(Avto => Avto.ClassName == "S") },
            { "M", q => q.Where(Avto => Avto.ClassName == "M") },
            { "J", q => q.Where(Avto => Avto.ClassName == "J") }
        };

        public Dictionary<string, Func<IQueryable<Avto>, IQueryable<Avto>>> BrandFilters { get; set; } =
        new Dictionary<string, Func<IQueryable<Avto>, IQueryable<Avto>>>
        {
            { "Все", q => q },
            { "Honda", q => q.Where(Avto => Avto.BrandName == "Honda") },
            { "Infiniti", q => q.Where(Avto => Avto.BrandName == "Infiniti") },
            { "Lexus", q => q.Where(Avto => Avto.BrandName == "Lexus") },
            { "Mazda", q => q.Where(Avto => Avto.BrandName == "Mazda") },
            { "Nissan", q => q.Where(Avto => Avto.BrandName == "Nissan") },
            { "Subaru", q => q.Where(Avto => Avto.BrandName == "Subaru") },
            { "Toyota", q => q.Where(Avto => Avto.BrandName == "Toyota") },
            { "Dodge", q => q.Where(Avto => Avto.BrandName == "Dodge") },
            { "Audi", q => q.Where(Avto => Avto.BrandName == "Audi") },
            { "BMW", q => q.Where(Avto => Avto.BrandName == "BMW") },
            { "Mercedes", q => q.Where(Avto => Avto.BrandName == "Mercedes") },
            { "Porsche", q => q.Where(Avto => Avto.BrandName == "Porsche") },
            { "Volkswagen", q => q.Where(Avto => Avto.BrandName == "Volkswagen") },
            { "Hyundai", q => q.Where(Avto => Avto.BrandName == "Hyundai") },
            { "Kia", q => q.Where(Avto => Avto.BrandName == "Kia") },
            { "Jaguar", q => q.Where(Avto => Avto.BrandName == "Jaguar") },
            { "Ferrari", q => q.Where(Avto => Avto.BrandName == "Ferrari") },
            { "Lamborghini", q => q.Where(Avto => Avto.BrandName == "Lamborghini") },
            { "Rolls-Royce", q => q.Where(Avto => Avto.BrandName == "Rolls-Royce") },
            { "Skoda", q => q.Where(Avto => Avto.BrandName == "Skoda") }
        };

        private void applyFilters()
        {
            IQueryable<Avto> query = Session.Instance.Context.Avtos.AsQueryable();
            query = applySearch(query);
            query = applyClassesFilter(query);
            query = applyBrandsFilter(query);

            Avtos.Clear();
            foreach (Avto avto in query)
            {
                Avtos.Add(avto);
            }
        }

        private void poisk_SelectionChanged(object sender, RoutedEventArgs e)
        {
            applyFilters();
        }

        private void classBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }

        private void brendBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }
    }
}
