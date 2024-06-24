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
    /// Логика взаимодействия для yslyga.xaml
    /// </summary>
    public partial class yslyga : Page
    {
        int _itemcount = 0;

        public yslyga()
        {
            InitializeComponent();
            //загрузка данных в combobox + добавление доп строки
            //загрузка данных в listview сортируем по названию
            Listboxservices.ItemsSource = ветеринарная_клиникаEntities.GetContext().услуга.OrderBy(p => p.наименование_услуги).ToList();
            _itemcount = Listboxservices.Items.Count;
            //отображение кол-ва записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //обновление данных после каждой активации окна
            if (Visibility == Visibility.Visible)
            {
                ветеринарная_клиникаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Listboxservices.ItemsSource = ветеринарная_клиникаEntities.GetContext().услуга.OrderBy(p => p.наименование_услуги).ToList();
            }
        }
        //поиск услуг, которые содержат данную строку
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        //метод для фильтрации и сортировки данных
        private void UpdateData()
           
        {
            //получение текущие данные из бд
            var currentservices = ветеринарная_клиникаEntities.GetContext().услуга.OrderBy(p => p.наименование_услуги).ToList();
            //выбор скидки
            if (ComboSkidka.SelectedIndex > 0)
            {
                int a = 0;
                int b = 0;
                switch (ComboSkidka.SelectedIndex)
                {
                    case 1:
                        a = 0;
                        b = 5;
                        break;
                    case 2:
                        a = 5;
                        b = 15;
                        break;
                    case 3:
                        a = 15;
                        b = 30;
                        break;
                    case 4:
                        a = 30;
                        b = 70;
                        break;
                    case 5:
                        a = 70;
                        b = 100;
                        break;
                }
                currentservices = currentservices.Where(p => p.действующая_скидка >= a && p.действующая_скидка < b).ToList();
            }
            //выбор тех услуг, в названии которых есть поисковая строка
            currentservices = currentservices.Where(p => p.наименование_услуги.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
                //сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                //сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0) currentservices = currentservices.OrderBy(p => p.стоимость).ToList();
                //сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1) currentservices = currentservices.OrderByDescending(p => p.стоимость).ToList();
            }
            //в качестве источника данных присваиваем список данных
            Listboxservices.ItemsSource = currentservices;
            //отображение данных
            TextBlockCount.Text = $" Результат запроса: {currentservices.Count} записей из {_itemcount}";
        }

        //сортировка скидок
        private void ComboSkidka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UpdateData();
        }

        // сортировка услуг
        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UpdateData();
        }
    }
       
}
