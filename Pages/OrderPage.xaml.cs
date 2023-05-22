using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<Order> orders;
        public OrderPage()
        {

            InitializeComponent();
            LoadData();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // открытие редактирования товара
            // передача выбранного товара в AddGoodPage
           Manager.MainFrame.Navigate(new AddNewOrderPage((sender as Button).DataContext as Order));
        }


        void LoadData()

        {


            if (Manager.CurrentUser.Role == true)
            {
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                orders = YogaFeatPilatesBDEntities.GetContext().Orders.OrderBy(p => p.Date).ToList();
                DataGridGood.ItemsSource = orders;
            }
            else
            {
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                orders = YogaFeatPilatesBDEntities.GetContext().Orders.Where(p => p.Username == Manager.CurrentUser.UserName).OrderBy(p => p.Date).ToList();
                DataGridGood.ItemsSource = orders;
                DataGridGood.Columns[6].Visibility = Visibility.Collapsed;

            }
            
        }
        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }


        private void BtnSellClick(object sender, RoutedEventArgs e)
        {
            // открытие страницы о продажах SellGoodsPage
            // передача в него выбранного товара
            //Manager.MainFrame.Navigate(new SellGoodsPage((sender as Button).DataContext as Order));
        }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
          //  Manager.MainFrame.Navigate(new StatusPage());
        }

        private void BtnLook_Click(object sender, RoutedEventArgs e)
        {
      //      Manager.MainFrame.Navigate(new AddNewOrderPage((sender as Button).DataContext as Order));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order deletedItem = (sender as Button).DataContext as Order;

                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить заявку? ", "Удаление", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                   
                    YogaFeatPilatesBDEntities.GetContext().Orders.Remove(deletedItem);
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка, есть связанные записи");
            }
            finally
            {
                LoadData();
            }
        }
    }
}

