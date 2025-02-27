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
    /// Логика взаимодействия для AddProductsWindow.xaml
    /// </summary>
    public partial class AddProductsWindow : Window
    {
        public MedicsEntities db = new MedicsEntities();
        public AddProductsWindow()
        {
            InitializeComponent();
        }

        private void AddProductsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtProducts.Text))
                {
                    MessageBox.Show("Введите данные в поле с типом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Преобразуем строку в DateTime
                if (DateTime.TryParseExact(TxtExpirationDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expirationDate))
                {
                    db.Products.Add(new Products
                    {
                        Products1 = TxtProducts.Text,
                        NamePartners = TxtNamePartners.Text,
                        CountProducts = TxtCountProducts.Text,
                        ExpirationDate = expirationDate
                    });
                    db.SaveChanges();
                    MessageBox.Show("Партнер добавлен", "Удачно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Неверный формат даты. Используйте формат yyyy-MM-dd", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
