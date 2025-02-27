using System.Linq;
using System.Windows;


namespace Comfort
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MedicsEntities db = new MedicsEntities();
        public MainWindow()
        {
            InitializeComponent();
            var table = from m in db.Partners
                        select m;
            DataGridPartners.ItemsSource = db.Partners.ToList();

            var medic = from m in db.Products
                        select m;
            DataGridProducts.ItemsSource = db.Products.ToList();

        }

        private void AddWindowButton_Click(object sender, RoutedEventArgs e)
        {
            AddPartnersWindow addPartnersWindow = new AddPartnersWindow();
            addPartnersWindow.Show();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно выбрали запрос?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (DataGridPartners.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запрос для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (DataGridPartners.SelectedItem is Partners select)
                {
                    db.Partners.Remove(select);
                    db.SaveChanges();
                    DataGridPartners.ItemsSource = db.Partners.ToList();
                    MessageBox.Show("Пользователь удален", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void EditWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно выбрали запрос?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (DataGridPartners.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запрос для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int PartnersID = (DataGridPartners.SelectedItem as Partners).ID;
                EditPartnersWindow Upage = new EditPartnersWindow(this, PartnersID);
                Upage.Show();
                Upage.Owner = this;
            }
        }
        private void AddWindowButton_Click1(object sender, RoutedEventArgs e)
        {
            AddProductsWindow addProductsWindow = new AddProductsWindow();
            addProductsWindow.Show();
            this.Close();
        }
        private void EditWindowButton_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно выбрали запрос?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (DataGridProducts.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запрос для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int ProductsID = (DataGridProducts.SelectedItem as Products).ID;
                EditProductsWindow Upage = new EditProductsWindow(this, ProductsID);
                Upage.Show();
                Upage.Owner = this;
            }
        }
        private void DeleteButton_Click1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно выбрали запрос?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (DataGridProducts.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите запрос для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (DataGridProducts.SelectedItem is Products select)
                {
                    db.Products.Remove(select);
                    db.SaveChanges();
                    DataGridProducts.ItemsSource = db.Products.ToList();
                    MessageBox.Show("Товар удален", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void ProductsWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridPartners.Visibility == Visibility.Visible)
            {
                DataGridPartners.Visibility = Visibility.Collapsed;
                DataGridProducts.Visibility = Visibility.Visible;
                AddWindowButton1.Visibility = Visibility.Visible;
                EditWindowButton1.Visibility = Visibility.Visible;
                DeleteButton1.Visibility = Visibility.Visible;
                AddWindowButton.Visibility = Visibility.Collapsed;
                EditWindowButton.Visibility = Visibility.Collapsed;
                DeleteButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                DataGridPartners.Visibility = Visibility.Visible;
                DataGridProducts.Visibility = Visibility.Collapsed;
                AddWindowButton1.Visibility = Visibility.Collapsed;
                EditWindowButton1.Visibility = Visibility.Collapsed;
                DeleteButton1.Visibility = Visibility.Collapsed;
                AddWindowButton.Visibility = Visibility.Visible;
                EditWindowButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void DataGridPartners_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
