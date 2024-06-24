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
    /// Логика взаимодействия для avtoriza.xaml
    /// </summary>
    public partial class avtoriza : Page
    {
        public avtoriza()
        {
            InitializeComponent();
        }
        // кнопка ok 
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            //загрузка всех пользователей из БД в список 
                List<пользователь> пользовательs = ветеринарная_клиникаEntities.GetContext().пользователь.ToList();
                //попытка найти пользователя с указанным паролем и логином
                пользователь u = пользовательs.FirstOrDefault(p => p.пароль == TbPass.Password && p.логин == TbLogin.Text);
                if (u != null)
                {
                    if (u.код_роли == 1)
                    {
                        NavigationService.Navigate(new addclient());
                    }
                    if (u.код_роли == 2)
                    {
                        NavigationService.Navigate(new yslyga());
                    }
                }
                else
                {
                    MessageBox.Show("не верный логин и пароль");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
