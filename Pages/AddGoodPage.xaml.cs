using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace WpfAssortmentCheck.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGoodPage.xaml
    /// </summary>
    public partial class AddGoodPage : Page
    {        //текущий товар
        private Trainer _currentItem = new Trainer();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";
        // передача в AddGoodPage товара 
        List<CategoryTrainer> currentItems = new List<CategoryTrainer>();
        class ComboBoxTypeItem
        {
            public int Id { get; set; }

            public int CategoryTrainerId { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

        List<ComboBoxTypeItem> servicesItems = new List<ComboBoxTypeItem>();
        private string GetComboBoxItemContent(List<ComboBoxTypeItem> items)
        {
            List<string> s = new List<string>();

            foreach (ComboBoxTypeItem item in items)
            {
                if (item.Selected == true)
                {
                    s.Add(item.Name);

                }
            }
            return String.Join(", ", s);
        }
        // загрузка 

        private void LoadServices()
        {
            servicesItems.Clear();
            List<CategoryTrainer> xlist = YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Where(i => i.TrainerId == _currentItem.Id).ToList();
            List<Category> items = YogaFeatPilatesBDEntities.GetContext().Categories.ToList();

            List<int> datas = new List<int>();
            foreach (CategoryTrainer c in xlist)
            {
                datas.Add(c.CategoryId);
                currentItems.Add(c);
            }
          //  MessageBox.Show(currentItems.Count.ToString());


            foreach (Category item in items)
            {
                if (datas.Contains(item.Id))
                {
                    servicesItems.Add(new ComboBoxTypeItem
                    {
                        Id = item.Id,
                        
                        Name = item.Name,
                        Selected = true
                    });
                   
                }
                else
                    servicesItems.Add(new ComboBoxTypeItem
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Selected = false
                    });
            }
            ComboCategories.ItemsSource = null;
            ComboCategories.ItemsSource = servicesItems;

        }
        //сохраytybt
        void SaveServices()
        {
            List<CategoryTrainer> saveItems = new List<CategoryTrainer>();

            foreach (ComboBoxTypeItem item in servicesItems)
            {
                if (item.Selected == true)
                {
                    saveItems.Add(new CategoryTrainer
                    {
                        TrainerId = _currentItem.Id,
                        CategoryId = item.Id,
                    }); ;
                }
            }
           // MessageBox.Show(currentItems.Count.ToString());
           // MessageBox.Show(saveItems.Count.ToString());
            List<CategoryTrainer> delItems = new List<CategoryTrainer>();
            List<CategoryTrainer> addItems = new List<CategoryTrainer>();

            foreach (CategoryTrainer x in currentItems)
            {
                bool b = false;
                foreach (CategoryTrainer y in saveItems)
                {
                    if ((y.CategoryId == x.CategoryId) && (y.TrainerId == x.TrainerId))
                    {
                        b = true;
                        break;
                    }
                   
                }
                if (!b)
                    delItems.Add(x);
            }

            foreach (CategoryTrainer x in saveItems)
            {
                bool b = false;
                foreach (CategoryTrainer y in currentItems)
                {
                    if ((y.CategoryId == x.CategoryId) && (y.TrainerId == x.TrainerId))
                    {
                        b = true;
                        break;
                    }
                   
                }
                if (!b)
                    addItems.Add(x);
            }

            string s = "";
            foreach (CategoryTrainer x in delItems)
            {
                if ((x.Abonements.Count == 0) && (x.TimeTables.Count == 0))
                    YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.Remove(x);
                else
                    s += "\n" + x.Category.Name;


            }
            if (s != "")
                   MessageBox.Show($"Не удалось удалить у данного тренера следующие " +
                       $"направления: {s}, поскольку у данного тренера есть абонементы" +
                       $" и занятия по данным направлениям", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            YogaFeatPilatesBDEntities.GetContext().CategoryTrainers.AddRange(addItems);

            YogaFeatPilatesBDEntities.GetContext().SaveChanges();
        }
        public AddGoodPage(Trainer selectedItem)
        {
            InitializeComponent();
            // если передано null, то мы добавляем новый товар
            if (selectedItem != null)
            {
                _currentItem = selectedItem;
                TextBoxGoodId.Visibility = Visibility.Hidden;
                int x = selectedItem.Id;

                //_filePath = _currentDirectory + _currentItem.Photo;
            }
            else
            {
                _currentItem.Birthday = DateTime.Today;
            }
            DataContext = _currentItem;
            LoadServices();
            _photoName = _currentItem.Photo;
        }
        // проверка полей
        private StringBuilder CheckFields()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentItem.LastName))
                s.AppendLine("Поле фамилия пустое");
            if (string.IsNullOrWhiteSpace(_currentItem.FirstName))
                s.AppendLine("Поле имя пустое");
            if (string.IsNullOrWhiteSpace(_currentItem.MiddleName))
                s.AppendLine("Поле отчество пустое");

            if (_currentItem.Birthday == null)
                s.AppendLine("Выберите дату рождения");

            if (_currentItem.WorkExperience == 0)
                s.AppendLine("Укадите стаж");
            if (string.IsNullOrWhiteSpace(_currentItem.Info))
                s.AppendLine("Заполните информацию о тренере");
            if (string.IsNullOrWhiteSpace(_photoName))
                s.AppendLine("фото не выбрано пустое");
            return s;
        }
        // сохранение 
        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFields();
            // если ошибки есть, то выводим ошибки в MessageBox
            // и прерываем выполнение 
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            // проверка полей прошла успешно
            if (_currentItem.Id == 0)
            {
                // добавление нового товара
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                string photo = ChangePhotoName();
                // путь куда нужно скопировать файл
                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                _currentItem.Photo = photo;
                // добавляем товар в БД
                YogaFeatPilatesBDEntities.GetContext().Trainers.Add(_currentItem);

            }


            try
            {
                if (_filePath != null)
                {

                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentItem.Photo = photo;
                }
                // Сохраняем изменения в БД
                YogaFeatPilatesBDEntities.GetContext().SaveChanges();
                SaveServices();
                MessageBox.Show("Запись Изменена");

                // Возвращаемся на предыдущую форму
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        

        // загрузка фото 
        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    //if (fileInfo.Length > (1024 * 1024 * 2))
                    //{
                    //    // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                    //    throw new Exception("Размер файла должен быть меньше 2Мб");
                    //}
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }
        }
        //подбор имени файла
        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

    }
}
