using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Data;
using WpfApp2.ProgrammServices;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Role = "Гость";
            new Workwindow(Role).Show();  
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AuthService authService = new AuthService();
            User user = authService.TryAuth(LogBox.Text, PasBox.Password);
            if(user != null) 
            { 
                new Workwindow(user.Role.RoleName, user.FullName).Show();
                //MessageBox.Show($"{user.Role.RoleName}, {user.FullName}");
                this.Close();
            }
        }
    }
}