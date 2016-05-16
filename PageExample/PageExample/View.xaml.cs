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

namespace PageExample
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
        DbSet set;

        public View(DbSet queryable)
        {
            InitializeComponent();
            this.set = queryable;

            this.set.Load();

            grid.ItemsSource = this.set.Local;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Windows.OptionWindow.SetPage(Windows.UsePage(grid.SelectedItem));
            Windows.OptionWindow.Show();
        }
    }
}
