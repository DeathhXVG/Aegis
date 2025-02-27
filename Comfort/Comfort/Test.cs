using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using System;
using System.Threading;


namespace Comfort.Tests
{
    [TestFixture]
    public class MainWindowTests
    {
        private Application application;
        private Window mainWindow;
        private Window addPartnersWindow;
        private Random random;


        [SetUp]
        public void Setup()
        {
            // Путь к исполняемому файлу вашего приложения
            string applicationPath = @"\\edu.local\public\studenthomes\21200077\Desktop\Comfort2\Comfort\Comfort\bin\Debug\Comfort.exe";

            // Запуск приложения
            application = Application.Launch(applicationPath);

            // Получение главного окна приложения
            mainWindow = application.GetWindow("Комфорт");
        }
        [Test]
        public void TestCloseApplicationByCross()
        {
            // Найти кнопку закрытия окна (крестик)
            var closeButton = mainWindow.Get<Button>(SearchCriteria.ByAutomationId("Close"));

            // Нажать на кнопку закрытия
            Thread.Sleep(2000);
            closeButton.Click();
        }
        [Test]
        public void TestProductsWindowButtonClick()
        {
            // Найти кнопку "Продукция/Партнеры"
            var productsWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Продукция/Партнеры"));

            // Нажать на кнопку "Продукция/Партнеры"
            productsWindowButton.Click();
            Thread.Sleep(1000);
            productsWindowButton.Click();
            Thread.Sleep(1000);
        }
        private string GenerateRandomINN()
        {
            // Генерация случайного ИНН из 10 цифр
            return random.Next(1000000000, 2000000000).ToString();
        }
        private string GenerateRandomPhone()
        {
            // Генерация случайного ИНН из 10 цифр
            return random.Next(1000000000, 2000000000).ToString();
        }
        [Test]
        public void TestAddButtonTestClick()
        {
            var addWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Добавить"));

            addWindowButton.Click();

            Thread.Sleep(3000);
            addPartnersWindow = application.GetWindow("Окно добавления партнеров");
            random = new Random();
            string randomINN = GenerateRandomINN();
            string randomPhone = GenerateRandomPhone();
            // Ввод данных в текстовые поля
            var txtType = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtType"));
            var txtName = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtName"));
            var txtDirector = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtDirector"));
            var txtEmail = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtEmail"));
            var txtPhone = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtPhone"));
            var txtAdress = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtAdress"));
            var txtINN = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtINN"));
            var txtRating = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtRating"));

            txtType.Text = "Typ";
            Thread.Sleep(1000);
            txtName.Text = "Name";
            Thread.Sleep(1000);
            txtDirector.Text = "Director";
            Thread.Sleep(1000);
            txtEmail.Text = "email@example.com";
            Thread.Sleep(1000);
            txtPhone.Text = randomPhone;
            Thread.Sleep(1000);
            txtAdress.Text = "Adress";
            Thread.Sleep(1000);
            txtINN.Text = randomINN;
            Thread.Sleep(1000);
            txtRating.Text = "5";
            Thread.Sleep(1000);

            // Нажатие кнопки "Создать"
            var addPartnerButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Создать"));
            Thread.Sleep(1000);
            addPartnerButton.Click();
            Thread.Sleep(1000);
            // Проверка, что сообщение "Партнер добавлен" появилось
            var messageBox = addPartnersWindow.MessageBox("Удачно");
            messageBox.WaitWhileBusy();
            var okButton = messageBox.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
            var BackMenuButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Назад"));
            BackMenuButton.Click();
            Thread.Sleep(1000);
        }
        [Test]
        public void TestError1TypeTest()
        {
            var addWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Добавить"));

            addWindowButton.Click();

            Thread.Sleep(3000);
            addPartnersWindow = application.GetWindow("Окно добавления партнеров");
            random = new Random();
            string randomINN = GenerateRandomINN();
            string randomPhone = GenerateRandomPhone();
            // Ввод данных в текстовые поля
            var txtType = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtType"));
            var txtName = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtName"));
            var txtDirector = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtDirector"));
            var txtEmail = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtEmail"));
            var txtPhone = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtPhone"));
            var txtAdress = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtAdress"));
            var txtINN = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtINN"));
            var txtRating = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtRating"));

            txtType.Text = "";
            Thread.Sleep(1000);
            txtName.Text = "Name";
            Thread.Sleep(1000);
            txtDirector.Text = "Director";
            Thread.Sleep(1000);
            txtEmail.Text = "email@example.com";
            Thread.Sleep(1000);
            txtPhone.Text = randomPhone;
            Thread.Sleep(1000);
            txtAdress.Text = "Adress";
            Thread.Sleep(1000);
            txtINN.Text = randomINN;
            Thread.Sleep(1000);
            txtRating.Text = "5";
            Thread.Sleep(1000);

            // Нажатие кнопки "Создать"
            var addPartnerButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Создать"));
            Thread.Sleep(1000);
            addPartnerButton.Click();
            Thread.Sleep(1000);
            // Проверка, что сообщение "Ошибка" появилось
            var messageBox = addPartnersWindow.MessageBox("Ошибка");
            messageBox.WaitWhileBusy();
            var okButton = messageBox.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
            var BackMenuButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Назад"));
            BackMenuButton.Click();
            Thread.Sleep(1000);
        }
        private string GenerateRandomPhone2()
        {
            // Генерация случайного ИНН из 10 цифр
            return random.Next(100000000, 200000000).ToString();
        }
        [Test]
        public void TestError2TypeTest()
        {
            var addWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Добавить"));

            addWindowButton.Click();

            Thread.Sleep(3000);
            addPartnersWindow = application.GetWindow("Окно добавления партнеров");
            random = new Random();
            string randomINN = GenerateRandomINN();
            string randomPhone2 = GenerateRandomPhone2();
            // Ввод данных в текстовые поля
            var txtType = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtType"));
            var txtName = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtName"));
            var txtDirector = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtDirector"));
            var txtEmail = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtEmail"));
            var txtPhone = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtPhone"));
            var txtAdress = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtAdress"));
            var txtINN = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtINN"));
            var txtRating = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtRating"));

            txtType.Text = "Typ";
            Thread.Sleep(1000);
            txtName.Text = "Name";
            Thread.Sleep(1000);
            txtDirector.Text = "Director";
            Thread.Sleep(1000);
            txtEmail.Text = "email@example.com";
            Thread.Sleep(1000);
            txtPhone.Text = randomPhone2;
            Thread.Sleep(1000);
            txtAdress.Text = "Adress";
            Thread.Sleep(1000);
            txtINN.Text = randomINN;
            Thread.Sleep(1000);
            txtRating.Text = "5";
            Thread.Sleep(1000);

            // Нажатие кнопки "Создать"
            var addPartnerButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Создать"));
            Thread.Sleep(1000);
            addPartnerButton.Click();
            Thread.Sleep(1000);
            // Проверка, что сообщение "Ошибка" появилось
            var messageBox = addPartnersWindow.MessageBox("Ошибка");
            messageBox.WaitWhileBusy();
            var okButton = messageBox.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
            var BackMenuButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Назад"));            
            BackMenuButton.Click();
            Thread.Sleep(1000);
        }
        [Test]
        public void TestError3TypeTest()
        {
            // Найти кнопку "Удалить"
            var DeleteWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Удалить"));

            DeleteWindowButton.Click();
            Thread.Sleep(1000);
            var messageBox = mainWindow.MessageBox("Внимание");
            messageBox.WaitWhileBusy();
            var yesButton = messageBox.Get<Button>(SearchCriteria.ByText("Да"));
            yesButton.Click();
            Thread.Sleep(1000);
            var messageBox2 = mainWindow.MessageBox("Ошибка");
            messageBox.WaitWhileBusy();
            var okButton = messageBox2.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
        }
        [Test]
        public void TestError4TypeTest()
        {
            // Найти кнопку "Изменить"
            var DeleteWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Изменить"));

            DeleteWindowButton.Click();
            Thread.Sleep(1000);
            var messageBox = mainWindow.MessageBox("Внимание");
            messageBox.WaitWhileBusy();
            var yesButton = messageBox.Get<Button>(SearchCriteria.ByText("Да"));
            yesButton.Click();
            Thread.Sleep(1000);
            var messageBox2 = mainWindow.MessageBox("Ошибка");
            messageBox.WaitWhileBusy();
            var okButton = messageBox2.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
        }
        private string GenerateRandomINN2()
        {
            // Генерация случайного ИНН из 10 цифр
            return random.Next(100000000, 200000000).ToString();
        }
        [Test]
        public void TestError5TypeTest()
        {
            var addWindowButton = mainWindow.Get<Button>(SearchCriteria.ByText("Добавить"));

            addWindowButton.Click();

            Thread.Sleep(3000);
            addPartnersWindow = application.GetWindow("Окно добавления партнеров");
            random = new Random();
            string randomINN2 = GenerateRandomINN2();
            string randomPhone = GenerateRandomPhone();
            // Ввод данных в текстовые поля
            var txtType = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtType"));
            var txtName = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtName"));
            var txtDirector = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtDirector"));
            var txtEmail = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtEmail"));
            var txtPhone = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtPhone"));
            var txtAdress = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtAdress"));
            var txtINN = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtINN"));
            var txtRating = addPartnersWindow.Get<TextBox>(SearchCriteria.ByAutomationId("TxtRating"));

            txtType.Text = "Typ";
            Thread.Sleep(1000);
            txtName.Text = "Name";
            Thread.Sleep(1000);
            txtDirector.Text = "Director";
            Thread.Sleep(1000);
            txtEmail.Text = "email@example.com";
            Thread.Sleep(1000);
            txtPhone.Text = randomPhone;
            Thread.Sleep(1000);
            txtAdress.Text = "Adress";
            Thread.Sleep(1000);
            txtINN.Text = randomINN2;
            Thread.Sleep(1000);
            txtRating.Text = "5";
            Thread.Sleep(1000);

            // Нажатие кнопки "Создать"
            var addPartnerButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Создать"));
            Thread.Sleep(1000);
            addPartnerButton.Click();
            Thread.Sleep(1000);
            // Проверка, что сообщение "Ошибка" появилось
            var messageBox = addPartnersWindow.MessageBox("Ошибка");
            messageBox.WaitWhileBusy();
            var okButton = messageBox.Get<Button>(SearchCriteria.ByText("ОК"));
            okButton.Click();
            Thread.Sleep(1000);
            var BackMenuButton = addPartnersWindow.Get<Button>(SearchCriteria.ByText("Назад"));
            BackMenuButton.Click();
            Thread.Sleep(1000);
        }
        [TearDown]
        public void TearDown()
        {
            // Закрытие приложения после выполнения теста
            if (application != null)
            {
                application.Close();
            }
        }
    }
}