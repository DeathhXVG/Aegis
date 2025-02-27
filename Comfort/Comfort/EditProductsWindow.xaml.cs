using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Xml.Linq;

namespace Comfort
{
    /// <summary>
    /// Логика взаимодействия для EditProductsWindow.xaml
    /// </summary>
    public partial class EditProductsWindow : Window
    {
        public int ID;
        private MainWindow Main;
        public EditProductsWindow(MainWindow mainWindow, int ProductsID)
        {
            InitializeComponent();
            ID = ProductsID;
            Main = mainWindow;
            Products updateProducts = (from m in Main.db.Products where m.ID == ID select m).Single();

            TxtProducts.Text = updateProducts.Products1;
            TxtNamePartners.Text = updateProducts.NamePartners;
            TxtCountProducts.Text = updateProducts.CountProducts;
            TxtExpirationDate.Text = updateProducts.ExpirationDate.ToString("yyyy-MM-dd");
        
    }

        private void EditProductsButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtProducts.Text))
            {
                MessageBox.Show("Название не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Products updateProducts = (from m in Main.db.Products where m.ID == ID select m).Single();

            updateProducts.Products1 = TxtProducts.Text;
            updateProducts.NamePartners = TxtNamePartners.Text;
            updateProducts.CountProducts = TxtCountProducts.Text;
            if (DateTime.TryParseExact(TxtExpirationDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expirationDate))
            {
                updateProducts.ExpirationDate = expirationDate;
            }
            else
            {
                MessageBox.Show("Неверный формат даты. Используйте формат yyyy-MM-dd", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Main.db.SaveChanges();
            Main.DataGridProducts.ItemsSource = Main.db.Products.ToList();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            Main.Activate(); // Убедитесь, что главное окно активно
        }

        private void BackButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtProducts_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
   
