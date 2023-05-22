using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Page
    {
        List<Buy> buys;
        User _currentUser;
        ICollectionView collectionView;
        public BuyPage()
        {
            InitializeComponent();
            _currentUser = Manager.CurrentUser;
            LoadData();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            // открытие редактирования товара
            // передача выбранного товара в AddGoodPage
            // Manager.MainFrame.Navigate(new AddNewOrderPage((sender as Button).DataContext as Order));
        }


        void LoadData()

        {
            if (_currentUser.Role == true)
            {


                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                buys = YogaFeatPilatesBDEntities.GetContext().Buys.OrderBy(p => p.DateTime).ToList();
                collectionView = CollectionViewSource.GetDefaultView(buys);
                DataGridGood.ItemsSource = collectionView;
            }
            else
            {
                DataGridGood.ItemsSource = null;
                //загрузка обновленных данных
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                buys = YogaFeatPilatesBDEntities.GetContext().Buys.Where(p => p.UserName == _currentUser.UserName).OrderBy(p => p.DateTime).ToList();
                collectionView = CollectionViewSource.GetDefaultView(buys);
                DataGridGood.ItemsSource = collectionView;
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                BtnStatus.Visibility = Visibility.Collapsed;
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



        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            // открытие  AddGoodPage для добавления новой записи
                  Manager.MainFrame.Navigate(new AddBuyPage(null));
        }

        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            var selectedGoods = DataGridGood.SelectedItems.Cast<Buy>().ToList();
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedGoods.Count()} записей???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    // берем из списка удаляемых товаров один элемент
                    Buy x = selectedGoods[0];
                    // проверка, есть ли у товара в таблице о продажах связанные записи


                    // удаляем товара
                    YogaFeatPilatesBDEntities.GetContext().Buys.Remove(x);
                    //сохраняем изменения
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
            Manager.MainFrame.Navigate(new StatusPage());
        }

        private void BtnLook_Click(object sender, RoutedEventArgs e)
        {
                  Manager.MainFrame.Navigate(new VisitPage((sender as Button).DataContext as Buy));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddBuyPage((sender as Button).DataContext as Buy));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            int selind = cmbSearchType.SelectedIndex;
            if (tbSearchID.Text == "")
            {
                collectionView.Filter = null;
                return;
            }
            switch (selind)
            {
                case 0:
                    FilterByID(tbSearchID.Text);
                    break;
                case 1:
                    FilterByClient(tbSearchID.Text);
                    break;
                

                default: collectionView.Filter = null; break;
            }





        }
        void FilterByID(string s)
        {
            int id = -1;
            bool b = int.TryParse(s, out id);
            if (!b)
                collectionView.Filter = null;

            collectionView.Filter = item =>
            {
                Buy x = item as Buy;
                return x.Id == id;

            };
            collectionView.Refresh();
        }

        void FilterByClient(string s)
        {
            collectionView.Filter = item =>
            {
                Buy x = item as Buy;
                //return x.OrderID == id;
                return x.User.GetFio.ToLower().Contains(s.ToLower());
            };
            collectionView.Refresh();
        }


       

        private void cmbSearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            collectionView.Filter = null;
            collectionView.Refresh();
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            PrintExcel();

        }

        private void PrintExcel()
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Buys" + ".xltx";
            Excel.Application xlApp = new Excel.Application();
            Excel.Worksheet xlSheet = new Excel.Worksheet();
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing);
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                Excel.Range xlSheetRange;
                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Список абонементов";
                int row = 2;
                int i = 0;


                if (DataGridGood.Items.Count > 0)
                {
                    for (i = 0; i < DataGridGood.Items.Count; i++)
                    {

                        Buy order = DataGridGood.Items[i] as Buy;

                        xlSheet.Cells[row, 1] = (i + 1).ToString();
                        // DateTime y = Convert.ToDateTime(dtOrders.Rows[i].Cells[1].Value);
                        xlSheet.Cells[row, 2] = order.Id.ToString();
                        xlSheet.Cells[row, 3] = order.Status.Name;
                        xlSheet.Cells[row, 4] = order.User.GetFio;
                        xlSheet.Cells[row, 5] = order.Abonement.CategoryTrainer.Category.Name;
                        xlSheet.Cells[row, 6] = order.Abonement.CategoryTrainer.Trainer.GetFio;
                        xlSheet.Cells[row, 7] = order.LessonsLeftCount.ToString();
                        xlSheet.Cells[row, 8] = order.DateTime.ToString();
                        xlSheet.Cells[row, 9] = order.Abonement.Price.ToString();

                        row++;
                        Excel.Range r = xlSheet.get_Range("A" + row.ToString(), "I" + row.ToString());
                        r.Insert(Excel.XlInsertShiftDirection.xlShiftDown);
                    }
                }
                row--;
                xlSheetRange = xlSheet.get_Range("A2:I" + (row + 1).ToString(), Type.Missing);
                xlSheetRange.Borders.LineStyle = true;
                xlSheet.Cells[row + 1, 9] = "=SUM(I2:I" + row.ToString() + ")";

                xlSheet.Cells[row + 1, 8] = "ИТОГО:";
                row++;

                //выбираем всю область данных*/
                xlSheetRange = xlSheet.UsedRange;
                //выравниваем строки и колонки по их содержимому
                //xlSheetRange.Columns.AutoFit();
                //xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;
            }
        }

    }
}

