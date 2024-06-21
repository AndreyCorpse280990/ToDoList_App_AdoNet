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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList_App.Factory;
using ToDoList_App.Mock;
using ToDoList_App.Model;

namespace ToDoList_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // используемый сервис
        private readonly IToDoService _toDoService;

        // конструктор формы
        public MainWindow()
        {
            InitializeComponent();
            // 
            _toDoService = ConfigServiceFactory.CreateToDoService();
            // 
            viewToDos();
        }

        private void viewToDos()
        {
            try
            {
                List<ToDo> toDos = _toDoService.GetAll();
                toDoListBox.ItemsSource = toDos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            viewToDos();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _toDoService.Dispose();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (toDoListBox.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Nothing selected for deleting", 
                        "No selected", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Warning
                    );
                    return;
                }
                int deletedId = ((ToDo)toDoListBox.SelectedItem).Id;
                _toDoService.Delete(deletedId);
                viewToDos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hide();
                ToDoWindow toDoWindow = new ToDoWindow();
                toDoWindow.ShowDialog();
                if (toDoWindow.FormObject == null)
                {
                    MessageBox.Show(
                       "Data not stored",
                       "Not stored",
                       MessageBoxButton.OK,
                       MessageBoxImage.Warning
                    );
                    return;
                }
                _toDoService.Add(toDoWindow.FormObject);
                viewToDos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Show();
            }
        }
    }
}
