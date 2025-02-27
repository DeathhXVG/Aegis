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

namespace Comfort
{
    /// <summary>
    /// Логика взаимодействия для AddPartnersWindow.xaml
    /// </summary>
    public partial class AddPartnersWindow : Window
    {
        public MedicsEntities db = new MedicsEntities();
        public AddPartnersWindow()
        {
            InitializeComponent();
        }

        public void AddPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtType.Text))
            {
                MessageBox.Show("Введите данные в поле с типом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtType.Text.Length > 3)
            {
                MessageBox.Show("Тип должен содержать не больше 3 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Введите данные в поле с названием", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtName.Text.Length > 255)
            {
                MessageBox.Show("Название должно содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtDirector.Text))
            {
                MessageBox.Show("Введите данные в поле с директором", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtDirector.Text.Length > 255)
            {
                MessageBox.Show("ФИО директора должно содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                MessageBox.Show("Введите данные в поле с email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtEmail.Text.Length > 255)
            {
                MessageBox.Show("Email должен содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtPhone.Text))
            {
                MessageBox.Show("Введите данные в поле с номером телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!TxtPhone.Text.All(char.IsDigit))
            {
                MessageBox.Show("Номер должен содержать только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtPhone.Text.Length > 10)
            {
                MessageBox.Show("Номер телефона должен содержать не больше 10 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtPhone.Text.Length < 10)
            {
                MessageBox.Show("Номер телефона должен содержать не менее 10 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtAdress.Text))
            {
                MessageBox.Show("Введите данные в поле с адресом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtAdress.Text.Length > 255)
            {
                MessageBox.Show("Адрес должен содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!TxtINN.Text.All(char.IsDigit))
            {
                MessageBox.Show("ИНН должен содержать только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtINN.Text.Length > 10)
            {
                MessageBox.Show("ИНН должен содержать не больше 10 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtINN.Text.Length < 10)
            {
                MessageBox.Show("ИНН должен содержать не менее 10 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtRating.Text))
            {
                MessageBox.Show("Введите данные в поле с Рейтингом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!TxtRating.Text.All(char.IsDigit))
            {
                MessageBox.Show("Рейтинг должен содержать только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtRating.Text.Length > 2)
            {
                MessageBox.Show("Рейтинг должен содержать не больше 2 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (db.Partners.Any(u => u.INN == TxtINN.Text))
            {
                MessageBox.Show("Партнер с таким ИНН уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            db.Partners.Add(new Partners { Type = TxtType.Text, Name = TxtName.Text, Director = TxtDirector.Text, Email = TxtEmail.Text, Phone = TxtPhone.Text, Adress = TxtAdress.Text, INN = TxtINN.Text, Rating = TxtRating.Text, Discount = "0" });
            db.SaveChanges();
            MessageBox.Show("Партнер добавлен", "Удачно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void BackButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}