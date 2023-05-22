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
using WpfAssortmentCheck.Windows;

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        public TimeTablePage(Trainer trainer)
        {
            InitializeComponent();
            LoadData(trainer);

        }
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        // загрузка данных в DataGrid и ComboBox
        void LoadData(Trainer trainer)
        {
            DtData.ItemsSource = YogaFeatPilatesBDEntities.GetContext().TimeTables.Where(p => p.CategoryTrainer.TrainerId == trainer.Id).OrderBy(p => p.CategoryTrainer.Category.Name).ThenBy(p => p.DayWeek).ThenBy(p => p.DayTime).ToList();
            ComboGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Trainers.OrderBy(p => p.LastName).ToList(); ;
            ComboGoods.SelectedIndex = 0;
            ComboGoods.SelectedValue = trainer.Id;
            GridGood.DataContext = trainer;
        }
        // фильтрация продаж по товару
        private void ComboGoodsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboGoods.SelectedIndex >= 0)
            {
                int goodId = Convert.ToInt32(ComboGoods.SelectedValue);
                var x = YogaFeatPilatesBDEntities.GetContext().TimeTables.Where(p => p.CategoryTrainer.TrainerId == goodId).OrderBy(p => p.CategoryTrainer.Category.Name).ThenBy(p => p.DayWeek).ThenBy(p => p.DayTime).ToList();
                DtData.ItemsSource = x;
                GridGood.DataContext = ComboGoods.SelectedItem;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{

                Trainer g = ComboGoods.SelectedItem as Trainer;
                TimeTableWindow window = new TimeTableWindow(new TimeTable(), g);
                if (window.ShowDialog() == true)
                {
                    YogaFeatPilatesBDEntities.GetContext().TimeTables.Add(window.currentItem);
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();

                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData(g);
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка");
            //}
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trainer g = ComboGoods.SelectedItem as Trainer;
                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                TimeTable selected = DtData.SelectedItem as TimeTable;

                //    double k = selected.Count;

                TimeTableWindow window = new TimeTableWindow(
                    new TimeTable
                    {
                        Id = selected.Id,
                        CategoryTrainerId = selected.CategoryTrainerId,
                        DayTime = selected.DayTime,
                        DayWeek = selected.DayWeek
                    }, g
                    );

                if (window.ShowDialog() == true)
                {
                    selected = YogaFeatPilatesBDEntities.GetContext().TimeTables.Find(window.currentItem.Id);
                    // получаем измененный объект
                    if (selected != null)
                    {

                        selected.Id = window.currentItem.Id;
                        selected.CategoryTrainerId = selected.CategoryTrainerId;
                        selected.DayTime = window.currentItem.DayTime;
                        selected.DayWeek = window.currentItem.DayWeek;


                        YogaFeatPilatesBDEntities.GetContext().Entry(selected).State = EntityState.Modified;
                        YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                       // LoadData(g);

                        MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData(g);
                        //ComboGoods.SelectedIndex = -1;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trainer g = ComboGoods.SelectedItem as Trainer;

                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись? ", "Удаление", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    TimeTable deletedItem = DtData.SelectedItem as TimeTable;


                    YogaFeatPilatesBDEntities.GetContext().TimeTables.Remove(deletedItem);
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();


                    LoadData(g);
                    MessageBox.Show("Запись удалена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

