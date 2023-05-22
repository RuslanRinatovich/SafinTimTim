using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfAssortmentCheck.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddNewOrderPage.xaml
    /// </summary>
    public partial class AddNewOrderPage : Page
    {
        //текущий товар
        private Buy _currentItem = new Buy();
        private Order _currentOrder = new Order();

        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }

        }


        public AddNewOrderPage(Order order)
            {
            InitializeComponent();
            _currentOrder = order;
            _currentItem.AbonementId = order.AbonementId;
            _currentItem.UserName = order.Username;
            tbClient.Text = _currentOrder.User.GetFio;
            ComboCategory.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Categories.OrderBy(p => p.Name).ToList();
            ComboStatus.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Status.OrderBy(p => p.Name).ToList();
            
            DataContext = _currentItem;
            ComboStatus.SelectedIndex = 0;

        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboCategory.SelectedIndex == -1)
                return;
            int id = Convert.ToInt32(ComboCategory.SelectedValue);
            var list = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Where(p => p.CategoryId == id).ToList();
            List<Trainer> trainers = new List<Trainer>();
            foreach (CategoryTrainer x in list)
            {
                trainers.Add(x.Trainer);
            }


            ComboTrainer.ItemsSource = trainers;
        }

        private void ComboTrainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboTrainer.SelectedIndex == -1)
                return;
            int categoryId = Convert.ToInt32(ComboCategory.SelectedValue);
            int trainerId = Convert.ToInt32(ComboTrainer.SelectedValue);
            CategoryTrainer categoryTrainer = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.FirstOrDefault(p => (p.CategoryId == categoryId) && (p.TrainerId == trainerId));
            if (categoryTrainer is null)
                return;

            List<Abonement> abonemens = YogaFeatPilatesBDEntities.GetContext().Abonements.Where(p => p.CategoryTrainerId == categoryTrainer.Id).ToList();
            ComboAbonement.ItemsSource = abonemens;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ComboCategory.SelectedValue = _currentOrder.Abonement.CategoryTrainer.CategoryId;
            ComboTrainer.SelectedValue = _currentOrder.Abonement.CategoryTrainer.TrainerId;
            ComboAbonement.SelectedValue = _currentOrder.AbonementId;
            DatePickerDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComboAbonement.SelectedIndex == -1)
                return;
            if (ComboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите статус абонемента");
                return;
            }
           
            _currentItem.AbonementId = Convert.ToInt32(ComboAbonement.SelectedValue);
            _currentItem.DateTime = Convert.ToDateTime(DatePickerDate.Value);
            _currentItem.UserName = _currentOrder.Username;
            _currentItem.StatusId = 1;
            _currentItem.LessonsLeftCount = _currentOrder.Abonement.LessonCount;
            YogaFeatPilatesBDEntities.GetContext().Buys.Add(_currentItem);
            YogaFeatPilatesBDEntities.GetContext().Orders.Remove(_currentOrder);

            YogaFeatPilatesBDEntities.GetContext().SaveChanges();
            MessageBox.Show("Абонемент оформлен");
            btnSave.Visibility = Visibility.Collapsed;
            btnExcel.Visibility = Visibility.Visible;
            // Возвращаемся на предыдущую форму
            // Manager.MainFrame.GoBack();

        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
                PrintExcel();

            }

            private void PrintExcel()
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Check" + ".xltx";
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
                    xlSheet.Name = "Список заявок";
                    int row = 9;
                    int i = 0;

                    xlSheet.Cells[4, 3] = tbOrderId.Text;
                    xlSheet.Cells[5, 3] = $"{_currentItem.User.LastName} {_currentItem.User.FirstName} {_currentItem.User.MiddleName}";
                    xlSheet.Cells[7, 4] = _currentItem.User.PassportSeries;
                    xlSheet.Cells[7, 7] = _currentItem.User.PassportNum;
                    xlSheet.Cells[7, 3] = _currentItem.User.Phone;
                    xlSheet.Cells[8, 4] = _currentItem.DateTime.ToString();
                    xlSheet.Cells[11, 2] = _currentItem.Abonement.GetInfo;
                    xlSheet.Cells[11, 8] = _currentItem.Abonement.Price;



                    xlSheet.Cells[14, 3] = DateTime.Today.ToShortDateString();
                    //выбираем всю область данных*/
                    xlSheetRange = xlSheet.UsedRange;
                    //выравниваем строки и колонки по их содержимому
                    xlSheetRange.Columns.AutoFit();
                    xlSheetRange.Rows.AutoFit();
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
