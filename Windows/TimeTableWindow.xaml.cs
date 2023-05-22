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
    /// Логика взаимодействия для TimeTableWindow.xaml
    /// </summary>
    public partial class TimeTableWindow : Window
    {
        public TimeTable currentItem { get; private set; }
        Trainer trainer;


        public TimeTableWindow(TimeTable p, Trainer g)
        {
            InitializeComponent();

          
            currentItem = p;
          //  currentItem.TrainerId = g.Id;
            trainer = g;
          
            List<CategoryTrainer> categoryTrainers = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Where(i => i.TrainerId == g.Id).ToList();
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

            if (ComboDayWeek.SelectedIndex == -1)
                s.AppendLine("Не выбран день недели");
            if (TimePickerDayTime.Value is null)
                s.AppendLine("Укажите время занятия");

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
            //currentItem.CategoryId = Convert.ToInt32(ComboCategory.SelectedValue);
            currentItem.DayWeek = ComboDayWeek.Text;
            currentItem.DayTime = Convert.ToDateTime(TimePickerDayTime.Value).TimeOfDay;
            int catid = Convert.ToInt32(ComboCategory.SelectedValue);
            CategoryTrainer category = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.FirstOrDefault(i => (i.TrainerId == trainer.Id) && (i.CategoryId == catid));
            currentItem.CategoryTrainerId = category.Id;
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ComboDayWeek.Text = currentItem.DayWeek;
            TbTrainer.Text = trainer.GetFio;
            TimePickerDayTime.Value = Convert.ToDateTime(currentItem.DayTime.ToString());
            CategoryTrainer category = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Find(currentItem.CategoryTrainerId);
            if (category is null)
                return;
            ComboCategory.SelectedValue = category.CategoryId;
        }
    }
}