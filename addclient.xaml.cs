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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace индивид
{
    /// <summary>
    /// Логика взаимодействия для addclient.xaml
    /// </summary>
    public partial class addclient : Page
    {
        public addclient()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                DataGridclient.ItemsSource = null;
                // загрузка обновленных данных 
                ветеринарная_клиникаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<пациент> пациентs = ветеринарная_клиникаEntities.GetContext().пациент.OrderBy(p => p.кличка).ToList();
                DataGridclient.ItemsSource = пациентs;
            }
        }

        private void BtnAddc_Click(object sender, RoutedEventArgs e)
        {
            // открытие Pageclient для добавления новой записи   
            NavigationService.Navigate(new Pageclient(null));
        }

        private void BtnDeletec_Click(object sender, RoutedEventArgs e)
        {
            //удаление выбранной услуги из таблицы
            //получаем все выделенные услуги
            var selectedGoods = DataGridclient.SelectedItems.Cast<пациент>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
           // если пользлватель нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {


                try
                {
                    // берем из списка удаляемых услуг один элемент
                    пациент x = selectedGoods[0];
                    // удаляем услугу
                    ветеринарная_клиникаEntities.GetContext().пациент.Remove(x);
                    // сохраняем изменения
                    ветеринарная_клиникаEntities.GetContext().SaveChanges();
                    MessageBox.Show("записи удалены");
                    List<пациент> пациентs = ветеринарная_клиникаEntities.GetContext().пациент.OrderBy(p => p.код_пациента).ToList();
                    DataGridclient.ItemsSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnEditС_Click(object sender, RoutedEventArgs e)
        {
            //открытие редактирования услуги
            NavigationService.Navigate(new Pageclient((sender as Button).DataContext as пациент));
        }
        //отображение номеров строк в DataGrid
        private void DataGridclient_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
