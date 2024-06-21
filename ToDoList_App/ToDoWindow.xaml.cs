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
using ToDoList_App.Model;

namespace ToDoList_App
{
    /// <summary>
    /// Логика взаимодействия для ToDoWindow.xaml
    /// </summary>
    public partial class ToDoWindow : Window
    {
        public ToDo FormObject { get; set; } 
        public ToDoWindow()
        {
            InitializeComponent();
            //
            FillForm();
        }

        // заполнение формы
        private void FillForm()
        {
            DateTime now = DateTime.Now;
            deadlineDatePicker.SelectedDate = new DateTime(now.Year, now.Month, now.Day);
            priorityComboBox.ItemsSource = ToDo.AvailablePriorities;
            priorityComboBox.SelectedIndex = 0;
            FormObject = null;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            FormObject = new ToDo()
            {
                Title = titleTextBox.Text,
                DeadLine = deadlineDatePicker.SelectedDate ?? DateTime.UtcNow,
                Priority = (ToDoPriority)priorityComboBox.SelectedItem
            };
            Close();
        }
    }
}
