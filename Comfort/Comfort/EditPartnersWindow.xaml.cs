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
    public partial class EditPartnersWindow : Window
    {
        public int ID;
        private MainWindow Main;
        public EditPartnersWindow(MainWindow mainWindow, int PartnerID)
        {
            InitializeComponent();
            ID = PartnerID;
            Main = mainWindow;
            Partners updatePartners = (from m in Main.db.Partners where m.ID == ID select m).Single();

            TxtType.Text = updatePartners.Type;
            TxtName.Text = updatePartners.Name;
            TxtDirector.Text = updatePartners.Director;
            TxtPhone.Text = updatePartners.Phone;
            TxtRating.Text = updatePartners.Rating;
        }

        private void BackButtonMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditPartnerButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text))
            {
                MessageBox.Show("Название не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtName.Text.Length > 255)
            {
                MessageBox.Show("Название должно содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtDirector.Text))
            {
                MessageBox.Show("ФИО директора не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtDirector.Text.Length > 255)
            {
                MessageBox.Show("ФИО директора должно содержать не больше 255 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtType.Text))
            {
                MessageBox.Show("Тип не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtType.Text.Length > 3)
            {
                MessageBox.Show("Тип должен содержать не больше 3 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtPhone.Text))
            {
                MessageBox.Show("Номер телефона не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (string.IsNullOrWhiteSpace(TxtRating.Text))
            {
                MessageBox.Show("Рейтинг не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (TxtRating.Text.Length > 2)
            {
                MessageBox.Show("Рейтинг должен содержать не больше 2 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!TxtRating.Text.All(char.IsDigit))
            {
                MessageBox.Show("Рейтинг должен содержать только цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Partners updatePartners = (from m in Main.db.Partners where m.ID == ID select m).Single();

            updatePartners.Name = TxtName.Text;
            updatePartners.Type = TxtType.Text;
            updatePartners.Director = TxtDirector.Text;
            updatePartners.Phone = TxtPhone.Text;
            updatePartners.Rating = TxtRating.Text;

            Main.db.SaveChanges();
            Main.DataGridPartners.ItemsSource = Main.db.Partners.ToList();
            MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
            Main.Activate(); // Убедитесь, что главное окно активно
        }
    }
}