using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogOfGoods.xaml
    /// </summary>
    public partial class CatalogOfGoods : Page
    {
        int _itemcount = 0;
        public CatalogOfGoods()
        {
            InitializeComponent();
            // загрузка данных в combobox + добавление дополнительной строки
            var trainers = YogaFeatPilatesBDEntities.GetContext().Trainers.OrderBy(p => p.LastName).ToList();
            trainers.Insert(0, new Trainer
            {
                FirstName = "Все"
            }
            );
            ComboTrainer.ItemsSource = trainers;
            ComboTrainer.SelectedIndex = 0;

            var categories = YogaFeatPilatesBDEntities.GetContext().Categories.OrderBy(p => p.Name).ToList();
            categories.Insert(0, new Category
            {
                Name = "Все типы"
            }
            );
            ComboCategory.ItemsSource = categories;
            ComboCategory.SelectedIndex = 0;
            // загрузка данных в listview сортируем по названию


            //LViewGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Abonements.OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList();

            LViewGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.OrderBy(p => p.Trainer.LastName).ToList();


            _itemcount = LViewGoods.Items.Count;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
        }

        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //обновление данных после каждой активации окна
            if (Visibility == Visibility.Visible)
            {
                ComboTrainer.ItemsSource = null;
                var trainers = YogaFeatPilatesBDEntities.GetContext().Trainers.OrderBy(p => p.LastName).ToList();
                trainers.Insert(0, new Trainer
                {
                    FirstName = "Все"
                }
                );
                ComboTrainer.ItemsSource = trainers;
                ComboTrainer.SelectedIndex = 0;
                ComboCategory.ItemsSource = null;
                var categories = YogaFeatPilatesBDEntities.GetContext().Categories.OrderBy(p => p.Name).ToList();
                categories.Insert(0, new Category
                {
                    Name = "Все типы"
                }
                );
                ComboCategory.ItemsSource = categories;
                ComboCategory.SelectedIndex = 0;
                YogaFeatPilatesBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                // LViewGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Abonements.OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList();

                LViewGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.OrderBy(p => p.Trainer.LastName).ToList();

            }
        }
        // Поиск товаров, которые содержат данную поисковую строку
        private void TBoxSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }
        // Поиск товаров конкретного производителя
        private void ComboTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }
        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            // получаем текущие данные из бд
            //var currentGoods = YogaFeatPilatesBDEntities.GetContext().Abonements.OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList();

            var currentGoods = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.OrderBy(p => p.Trainer.LastName).ToList();
            // выбор только тех товаров, которые принадлежат данному производителю
            if (ComboTrainer.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.TrainerId == (ComboTrainer.SelectedItem as Trainer).Id).ToList();
           
            if (ComboCategory.SelectedIndex > 0)
                currentGoods = currentGoods.Where(p => p.CategoryId == (ComboCategory.SelectedItem as Category).Id).ToList();


            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.Category.Name).ToList();
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p => p.Category.Name).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 2)
                    currentGoods = currentGoods.OrderBy(p => p.Trainer.LastName).ToList();
                if (ComboSort.SelectedIndex == 3)
                    currentGoods = currentGoods.OrderByDescending(p => p.Trainer.LastName).ToList();
            }
            // В качестве источника данных присваиваем список данных
            LViewGoods.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";
        }
        // сортировка товаров 
        private void ComboSortSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnShowMore_Click(object sender, RoutedEventArgs e)
        {
       //     Service selected = (sender as Button).DataContext as Service;

          //  MessageBox.Show(selected.PriceLists.Count.ToString());
        }

        private void ComboTrainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            CategoryTrainer edu = (sender as Button).DataContext as CategoryTrainer;
            Trainer trainer = YogaFeatPilatesBDEntities.GetContext().Trainers.FirstOrDefault(p => p.Id == edu.TrainerId);
            List<TimeTable> timeTables = YogaFeatPilatesBDEntities.GetContext().TimeTables.Where(p => p.CategoryTrainerId == edu.Id).ToList();
            ListBoxTimeTable.ItemsSource = timeTables;
            TbCategoryName.Text = edu.Category.Name;
            DialogHostMoreInformation.DataContext = trainer;
            DialogHostMoreInformation.IsOpen = true;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogHostMoreInformation.IsOpen = false;
        }
    }
}
