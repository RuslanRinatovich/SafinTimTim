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
    /// Логика взаимодействия для StatusPage.xaml
    /// </summary>
    public partial class StatusPage : Page
    {
        List<Status> brands;
        public StatusPage()
        {
            InitializeComponent();
        }


        void LoadData()
        {
            try
            {
                DtData.ItemsSource = null;
                //загрузка обновленных данных
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                brands = YogaFeatPilatesBDEntities.GetContext().Status.OrderBy(p => p.Name).ToList();
                DtData.ItemsSource = brands;
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }

        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                StatusWindow window = new StatusWindow(new Status());
                if (window.ShowDialog() == true)
                {
                    YogaFeatPilatesBDEntities.GetContext().Status.Add(window.currentItem);
                    YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                    LoadData();
                    MessageBox.Show("Запись добавлена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
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
                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                Status selected = DtData.SelectedItem as Status;


                StatusWindow window = new StatusWindow(
                    new Status
                    {
                        Id = selected.Id,
                        Name = selected.Name,
                        Color = selected.Color,
                    }
                    );

                if (window.ShowDialog() == true)
                {
                    selected = YogaFeatPilatesBDEntities.GetContext().Status.Find(window.currentItem.Id);
                    // получаем измененный объект
                    if (selected != null)
                    {

                        selected.Id = window.currentItem.Id;
                        selected.Name = window.currentItem.Name;
                        selected.Color = window.currentItem.Color;
                        YogaFeatPilatesBDEntities.GetContext().Entry(selected).State = EntityState.Modified;
                        YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                        LoadData();
                        MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
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
                // если ни одного объекта не выделено, выходим
                if (DtData.SelectedItem == null) return;
                // получаем выделенный объект
                MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить запись? ", "Удаление", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    Status deletedItem = DtData.SelectedItem as Status;


                    YogaFeatPilatesBDEntities.GetContext().Buys.Load();
                    var list = YogaFeatPilatesBDEntities.GetContext().Buys.Local;
                    int k = 0;
                    foreach (Buy item in list)
                    {
                        if (item.StatusId == deletedItem.Id)
                            k++;
                    }
                    // MessageBox.Show(k.ToString());
                    if (k > 0)
                    {
                        MessageBox.Show("Ошибка удаления, есть связанные записи", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    YogaFeatPilatesBDEntities.GetContext().Status.Remove(deletedItem);
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
