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
    /// Логика взаимодействия для SellPage.xaml
    /// </summary>
    public partial class SellPage : Page
    {
        public SellPage(Abonement abonement, Trainer trainer)
        {
            InitializeComponent();
            LoadData(abonement, trainer);

        }
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }


        // загрузка данных в DataGrid и ComboBox
        void LoadData(Abonement abonement, Trainer trainer)
        {
            DtData.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Buys.Where(p => p.AbonementId == abonement.Id).OrderBy(p => p.DateTime).ToList();
            ComboGoods.ItemsSource = YogaFeatPilatesBDEntities.GetContext().Abonements.Where(p => p.CategoryTrainer.TrainerId == trainer.Id).OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList(); ;
            ComboGoods.SelectedIndex = 0;
            ComboGoods.SelectedValue = abonement.Id;
        }
        // фильтрация продаж по товару
        private void ComboGoodsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboGoods.SelectedIndex >= 0)
            {
                int goodId = Convert.ToInt32(ComboGoods.SelectedValue);
                var x = YogaFeatPilatesBDEntities.GetContext().Buys.Where(p => p.AbonementId== goodId).OrderBy(p => p.DateTime).ToList();
                DtData.ItemsSource = x;
            }
        }

     

        }
    }
