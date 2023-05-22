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

namespace WpfAssortmentCheck.Windows
{
    /// <summary>
    /// Логика взаимодействия для AbonementWindow.xaml
    /// </summary>
    public partial class AbonementWindow : Window
    {
        public Abonement currentItem { get; private set; }
        Trainer trainer;
      

        public AbonementWindow(Abonement p, Trainer g)
        {
            InitializeComponent();

            TbTrainer.Text = g.GetFio;
            currentItem = p;

       //     currentItem.TrainerId = g.Id;
            trainer = g;

            List <CategoryTrainer> categoryTrainers = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Where(i => i.TrainerId == g.Id).ToList();
            List<Category> categories = new List<Category>();
            foreach (CategoryTrainer x in categoryTrainers)
            {
                categories.Add(x.Category);
            }
            ComboCategory.ItemsSource = categories;
            DataContext = currentItem;

        }


        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (ComboCategory.SelectedIndex == -1)
                s.AppendLine("Не выбрано навправление");
            if (UpDownPrice.Value is null)
                s.AppendLine("укажите стоимость авбонемента");

            return s;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            int catid = Convert.ToInt32(ComboCategory.SelectedValue);
            CategoryTrainer category = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.FirstOrDefault(i => (i.TrainerId == trainer.Id) && (i.CategoryId == catid) );
            currentItem.CategoryTrainerId = category.Id;
            //   currentItem.CategoryId = Convert.ToInt32(ComboCategory.SelectedValue);
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CategoryTrainer category = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Find(currentItem.CategoryTrainerId);
            if (category is null)
                return;
            ComboCategory.SelectedValue = category.CategoryId;
        }
    }
}