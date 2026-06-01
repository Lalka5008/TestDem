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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2.Data;
using WpfApp2.Model;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProduct = new Product
                {
                    ProductsId = ArtBox.Text,
                    ProductTypeId = Convert.ToInt32(TypeBox.Text),
                    UnitId = Convert.ToInt32(UnitBox.Text),
                    Price = Convert.ToDecimal(PriceBox.Text),
                    ImportId = Convert.ToInt32(ImportBox.Text),
                    CreaterId = Convert.ToInt32(CreaterBox.Text),
                    CategoryId = Convert.ToInt32(CategoryBox.Text),
                    Sale = Convert.ToInt32(SaleBox.Text),
                    Quantity = Convert.ToInt32(QuantityBox.Text),
                    Info = InfoBox.Text,
                    Image = ImageBox.Text,

                };
                using (var db = new TestDemContext())
                {
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                }
                MessageBox.Show("saved");
                this.Close();

            }
            catch 
            {
                MessageBox.Show("Ошибка, проверьте введенные данные");
            }
            
        }
        
    }
}
