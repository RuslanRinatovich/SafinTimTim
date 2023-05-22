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
    /// Логика взаимодействия для VisitPage.xaml
    /// </summary>
    public partial class VisitPage : Page
    {
        Buy _currentBuy;
        public VisitPage(Buy buy)
        {
            InitializeComponent();

            _currentBuy = buy;
            LoadData(buy);

        }
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        // загрузка данных в DataGrid и ComboBox
        void LoadData(Buy buy)
        {
            if (Manager.CurrentUser.Role == false)
            {
                btnAdd.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                CardTrainer.DataContext = null;
                ComboGoods.ItemsSource = null;
                ComboGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Buys.Where(p => p.UserName == Manager.CurrentUser.UserName).OrderBy(p => p.AbonementId).ToList();
                ComboGoods.SelectedIndex = -1;
                ComboGoods.SelectedValue = buy.Id;
                DtData.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Visits.Where(p => p.BuytId == buy.Id).OrderBy(p => p.DateTime).ToList();
                CardTrainer.DataContext = buy;
            }

            else
            {
                CardTrainer.DataContext = null;
                ComboGoods.ItemsSource = null;
                ComboGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Buys.OrderBy(p => p.AbonementId).ToList();
                ComboGoods.SelectedIndex = -1;
                ComboGoods.SelectedValue = buy.Id;
                DtData.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Visits.Where(p => p.BuytId == buy.Id).OrderBy(p => p.DateTime).ToList();
                CardTrainer.DataContext = buy;
            }
        }
        // фильтрация продаж по товару
        private void ComboGoodsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboGoods.SelectedIndex >= 0)
            {
                int goodId = Convert.ToInt32(ComboGoods.SelectedValue);
                _currentBuy = ComboGoods.SelectedItem as Buy;
                var x = YogaFeatPilatesBDEntities.GetContext().Visits.Where(p => p.BuytId == goodId).OrderBy(p => p.DateTime).ToList();
                DtData.ItemsSource = x;
                CardTrainer.DataContext = ComboGoods.SelectedItem;
               // MessageBox.Show("+");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Buy g = ComboGoods.SelectedItem as Buy;
            if (g.LessonsLeftCount == 0)
                return;
                VisitWindow window = new VisitWindow(new Visit(), g);
                if (window.ShowDialog() == true)
                {
                    YogaFeatPilatesBDEntities.GetContext().Visits.Add(window.currentItem);
                g.LessonsLeftCount -= 1;
                if (g.LessonsLeftCount == 0)
                    g.StatusId = 2;
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();

                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData(g);
               
            }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Buy g = ComboGoods.SelectedItem as Buy;
                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                Visit selected = DtData.SelectedItem as Visit;

                //    double k = selected.Count;

                VisitWindow window = new VisitWindow(
                    new Visit
                    {
                        Id = selected.Id,
                        BuytId = selected.BuytId,
                        DateTime = selected.DateTime
                    }, g
                    );

                if (window.ShowDialog() == true)
                {
                    selected = YogaFeatPilatesBDEntities.GetContext().Visits.Find(window.currentItem.Id);
                    // получаем измененный объект
                    if (selected != null)
                    {

                        selected.Id = window.currentItem.Id;
                        selected.BuytId = g.Id;
                        selected.DateTime = window.currentItem.DateTime;

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
                Buy g = ComboGoods.SelectedItem as Buy;

                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись? ", "Удаление", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    Visit deletedItem = DtData.SelectedItem as Visit;
                    g.LessonsLeftCount += 1;
                    if (g.LessonsLeftCount > 0)
                        g.StatusId = 1;
                    YogaFeatPilatesBDEntities.GetContext().Visits.Remove(deletedItem);
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

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                LoadData(_currentBuy);
            }
        }
    }
}

