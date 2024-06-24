using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
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

namespace индивид
{
    /// <summary>
    /// Логика взаимодействия для Pageclient.xaml
    /// </summary>
    public partial class Pageclient : Page

    {
        //текущая услуга
        private пациент _currentpa = new пациент();
        public Pageclient(пациент selectedp)
        {
            InitializeComponent();
            if (selectedp != null)
            {
                _currentpa = selectedp;
                TextBoxId.Visibility = Visibility.Hidden;
                int x = selectedp.код_пациента;
                List<пациент> yslugii = new List<пациент>();
            }
            //загрузка клиентов
            Txtclient.ItemsSource = ветеринарная_клиникаEntities.GetContext().клиент.ToList();
            //загрузка пола пациента
            Txtpol.ItemsSource = ветеринарная_клиникаEntities.GetContext().пол_пациента.ToList();
            // загрузка породы
            Txtporoda.ItemsSource = ветеринарная_клиникаEntities.GetContext().порода_пациента.ToList();
            //загрузка вида
            Txtvid.ItemsSource = ветеринарная_клиникаEntities.GetContext().вид_пациента.ToList() ;

            DataContext = _currentpa;

        }
        private StringBuilder CheckFileds()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrEmpty(_currentpa.кличка))
                s.AppendLine("Поле пустое");

            if (string.IsNullOrEmpty(_currentpa.дата_рождения))
                s.AppendLine("Поле пустое");

            if (string.IsNullOrEmpty(_currentpa.вес))
                s.AppendLine("Поле пустое");


            return s;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFileds();
            //если есть ошибка, то выводим сообщение об ошибке в MessageBox
            // и прерываем выполнение
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            if (_currentpa.код_пациента == 0)
            {
                //добавляем услугу в бд
                ветеринарная_клиникаEntities.GetContext().пациент.Add(_currentpa);
            }
            try
            {
                //сохраняем изменения в бд
                ветеринарная_клиникаEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись изменена");
                NavigationService.Navigate(new addclient());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}
        
    }
}
