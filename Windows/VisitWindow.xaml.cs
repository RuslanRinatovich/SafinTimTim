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
    /// Логика взаимодействия для VisitWindow.xaml
    /// </summary>
    public partial class VisitWindow : Window
    {
        public Visit currentItem { get; private set; }
        


        public VisitWindow(Visit p, Buy b)
        {
            InitializeComponent();

            
            currentItem = p;
            currentItem.DateTime = DateTime.Now;
            currentItem.BuytId = b.Id;
            TbInfo.Text = b.GetInfo;
            DataContext = currentItem;

        }


        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (DatePickerDate.Value == null)
                s.AppendLine("Не выбрана дата");

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
            
            currentItem.DateTime =Convert.ToDateTime (DatePickerDate.Value.ToString());
            
            this.DialogResult = true;
        }

      
    }
}