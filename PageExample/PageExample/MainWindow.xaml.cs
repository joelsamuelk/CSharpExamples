using PageExample.Pages;
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

namespace PageExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewStudents_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new View(BIEntities.Instance.Students);
        }

        private void ViewCourses_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = new View(BIEntities.Instance.Courses);
        }

        private void AddStudents_Click(object sender, RoutedEventArgs e)
        {
            Windows.OptionWindow.SetPage(new StudentPage(BIEntities.Instance.Students.FirstOrDefault()));
            Windows.OptionWindow.Show();
        }
    }
}
