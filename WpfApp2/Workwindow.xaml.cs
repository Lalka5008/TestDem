using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp2.Data;
using WpfApp2.Model;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Workwindow.xaml
    /// </summary>
    public partial class Workwindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public Workwindow(string Role = "", string FullName ="")
        {
            Products = new ObservableCollection<Product>();
            InitializeComponent();
            DataContext = this;
            RefreshProduct();
            TextBlockFullName.Text = FullName;

        }

        public void RefreshProduct()
        {
            Products.Clear();
            using (var context = new TestDemContext())
            {
                var product = context.Products.Include(p => p.Category).Include(p => p.Creater).Include(p => p.DetailsOrders).Include(p => p.Import).Include(p => p.ProductType).Include(p => p.Unit).ToList();
                foreach (var p in product) 
                {
                   Products.Add(p);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CreateProduct().Show();
        }
    }
}
