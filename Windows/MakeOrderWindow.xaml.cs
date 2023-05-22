using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfAssortmentCheck.Models;

namespace WpfAssortmentCheck.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        public MakeOrderWindow()
        {
            InitializeComponent();

            TbUser.Text = Manager.CurrentUser.GetFio;
            ComboCategory.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Categories.OrderBy(p => p.Name).ToList();
        }

      

        private void ComboAbonement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboAbonement.SelectedIndex == -1)
                return;

            Order order = new Order();
            order.Username = Manager.CurrentUser.UserName;
            order.AbonementId = Convert.ToInt32(ComboAbonement.SelectedValue);
            order.Date = DateTime.Now;
            YogaFeatPilatesBDEntities.GetContext().Orders.Add(order);
            YogaFeatPilatesBDEntities.GetContext().SaveChanges();
            MessageBox.Show("Заявка отправлена");
            this.DialogResult = true;



        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboCategory.SelectedIndex == -1)
                return;
            int id = Convert.ToInt32(ComboCategory.SelectedValue);
            var list = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Where(p => p.CategoryId == id).ToList();
            List<Trainer> trainers = new List<Trainer>();
            foreach(CategoryTrainer x in list)
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
    }
}
