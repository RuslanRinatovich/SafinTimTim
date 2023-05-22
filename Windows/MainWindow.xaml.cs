using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using WpfAssortmentCheck.Models;
using WpfAssortmentCheck.Pages;
using WpfAssortmentCheck.Windows;

namespace WpfAssortmentCheck
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CatalogOfGoods());
            Manager.CurrentUser = null;
            Manager.MainFrame = MainFrame;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
           
            App.Current.Shutdown();
        }
        //событие попытки закрытия окна,
        // если пользователь выберет Cancel, то форму не закроем
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
                "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        // Кнопка назад
        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        // Кнопка навигации
        private void BtnEditGoodsClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GoodsPage());
        }
        // Событие отрисовки страницы
        // Скрываем или показываем кнопку Назад 
        // Скрываем или показываем кнопки Для перехода к остальным страницам
        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnEnter.Visibility = Visibility.Collapsed;
                BtnOrder.Visibility = Visibility.Collapsed;
                BtnBuyes.Visibility = Visibility.Collapsed;
                if (Manager.CurrentUser is null)
                    return;
                if (Manager.CurrentUser.Role == true)
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                else
                {
                    BtnMyAccount.Visibility = Visibility.Collapsed;
                    BtnMyOrders.Visibility = Visibility.Collapsed;
                }

            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnEnter.Visibility = Visibility.Visible;
                
                if (Manager.CurrentUser is null)
                    return;
                BtnOrder.Visibility = Visibility.Visible;
                BtnBuyes.Visibility = Visibility.Visible;
                if (Manager.CurrentUser.Role == true)
                    BtnEditGoods.Visibility = Visibility.Visible;
                else
                {
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnMyOrders.Visibility = Visibility.Visible;
                }

            }
        }

        private void BtnEditDev_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnEditGroups_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryPage());
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.CurrentUser != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Выйти из системы??? ", "Выход", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Login;
                    Manager.CurrentUser = null;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnOrder.Visibility = Visibility.Collapsed;
                    BtnBuyes.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Collapsed;
                    BtnMyOrders.Visibility = Visibility.Collapsed;
                    return;
                }
            }

            LoginWindow window = new LoginWindow();
            if (window.ShowDialog() == true)
            {
                
                if (Manager.CurrentUser.Role == true)
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Visible;
                    BtnOrder.Visibility = Visibility.Visible;
                    BtnBuyes.Visibility = Visibility.Visible;
                }
                else 
                {
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnMyOrders.Visibility = Visibility.Visible;
                    BtnOrder.Visibility = Visibility.Visible;
                    BtnBuyes.Visibility = Visibility.Visible;
                }
                
            }
            
        }



        private void BtnMyOrder_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new StatusPage());

            
        }

        private void BtnMyAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                
                ClientWindow window = new ClientWindow();

                if (window.ShowDialog() == true)
                {
                    
                        MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
           
                MainFrame.Navigate(new OrderPage());
           
           
        }

        private void BtnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                MakeOrderWindow window = new MakeOrderWindow();

                if (window.ShowDialog() == true)
                {

                    MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void BtnBuyes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BuyPage());
        }
    }
}
