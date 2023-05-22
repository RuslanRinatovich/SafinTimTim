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

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBuyPage.xaml
    /// </summary>
    public partial class AddBuyPage : Page
    {
        private Buy _currentItem;

        Abonement _currentAbonement = new Abonement();

        private string Username = "";
        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }

        }


        public AddBuyPage(Buy selectedItem)
        {
            InitializeComponent();
            if (selectedItem != null)
            {
                _currentItem = selectedItem;
                Username = selectedItem.UserName;
                tbClient.Text = selectedItem.User.GetFio;
                btnSave.Visibility = Visibility.Collapsed;
                btnExcel.Visibility = Visibility.Visible;
                ComboCategory.IsEnabled = false;
                ComboStatus.IsEnabled = false;
                ComboAbonement.IsEnabled = false;
                ComboTrainer.IsEnabled = false;
                btnLoadClient.Visibility = Visibility.Collapsed;
                DatePickerDate.IsEnabled = false;
               // DatePickerDate
                TbLessonsLeft.Text = $"Осталось {_currentItem.LessonsLeftCount} занятий";

            }

            ComboCategory.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Categories.OrderBy(p => p.Name).ToList();
            ComboStatus.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Status.OrderBy(p => p.Name).ToList();
            lbClient.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Users.ToList();
            DataContext = _currentItem;

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
            if (_currentItem == null)
                return;
            ComboCategory.SelectedValue = _currentItem.Abonement.CategoryTrainer.CategoryId;
            ComboTrainer.SelectedValue = _currentItem.Abonement.CategoryTrainer.TrainerId;
            ComboAbonement.SelectedValue = _currentItem.AbonementId;
           // DatePickerDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if ((ComboAbonement.SelectedIndex == -1)|| (ComboStatus.SelectedIndex == -1))
                return;

           
                _currentItem = new Buy();
                _currentItem.AbonementId = Convert.ToInt32(ComboAbonement.SelectedValue);
                _currentItem.DateTime = Convert.ToDateTime(DatePickerDate.Value);
                _currentItem.UserName = Username;
            int id = Convert.ToInt32(ComboStatus.SelectedValue);
            if (id == 1)
            {
                _currentItem.LessonsLeftCount = _currentAbonement.LessonCount;
            }
            else { _currentItem.LessonsLeftCount = 0; }

            
            _currentItem.StatusId = Convert.ToInt32(ComboStatus.SelectedValue);
                YogaFeatPilatesBDEntities.GetContext().Buys.Add(_currentItem);
            
            YogaFeatPilatesBDEntities.GetContext().SaveChanges();
            MessageBox.Show("Данные сохранены");
            btnSave.Visibility = Visibility.Collapsed;
            btnExcel.Visibility = Visibility.Visible;
            ComboCategory.IsEnabled = false;
            ComboStatus.IsEnabled = false;
            ComboAbonement.IsEnabled = false;
            ComboTrainer.IsEnabled = false;
            btnLoadClient.Visibility = Visibility.Collapsed;
            DatePickerDate.IsEnabled = false;
            TbLessonsLeft.Text = $"Осталось {_currentItem.LessonsLeftCount} занятий";
            //if (_currentItem == null)
            //{
            //    _currentItem = new Buy();
            //    _currentItem.AbonementId = Convert.ToInt32(ComboAbonement.SelectedValue);
            //    _currentItem.DateTime = Convert.ToDateTime(DatePickerDate.Value);
            //    _currentItem.UserName = Username;
            //    _currentItem.LessonsLeftCount = _currentAbonement.LessonCount;
            //    _currentItem.StatusId = Convert.ToInt32(ComboStatus.SelectedValue);
            //    YogaFeatPilatesBDEntities.GetContext().Buys.Add(_currentItem);
            //}
            //else
            //{
            //    _currentItem.AbonementId = Convert.ToInt32(ComboAbonement.SelectedValue);
            //    _currentItem.DateTime = Convert.ToDateTime(DatePickerDate.Value);
            //    _currentItem.LessonsLeftCount = _currentAbonement.LessonCount;
            //    _currentItem.UserName = Username;
            //    _currentItem.StatusId = Convert.ToInt32(ComboStatus.SelectedValue);
            //}
            //YogaFeatPilatesBDEntities.GetContext().SaveChanges();
            //MessageBox.Show("Данные сохранены");
            //btnExcel.Visibility = Visibility.Visible;
            // Возвращаемся на предыдущую форму
            // Manager.MainFrame.GoBack();

        }

        private void btnLoadClient_Click(object sender, RoutedEventArgs e)
        {
            hostLoadClient.IsOpen = true;
        }

        private void btnClientOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbClient.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < lbClient.SelectedItems.Count; i++)
                    {
                        User xair = lbClient.SelectedItems[i] as User;
                        if (xair != null)
                        {
                            Username = xair.UserName;
                           
                            tbClient.Text = xair.GetFio;
                        }
                    }
                }


                //MaterialDesignThemes.Wpf.DialogHost.Show("Запись вфыафыва");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            hostLoadClient.IsOpen = false;
        }

        private void btnClientCancel_Click(object sender, RoutedEventArgs e)
        {
            hostLoadClient.IsOpen = false;
        }

        private void ComboAbonement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboAbonement.SelectedIndex == -1)
                return;
            int id = Convert.ToInt32(ComboAbonement.SelectedValue);
            _currentAbonement = YogaFeatPilatesBDEntities.GetContext().Abonements.FirstOrDefault(a => a.Id == id);
            
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
                xlSheet.Cells[11, 2] = _currentAbonement.GetInfo;
                xlSheet.Cells[11, 8] = _currentAbonement.Price;

               
                
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
