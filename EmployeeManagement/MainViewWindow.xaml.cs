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

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainViewWindow.xaml
    /// </summary>
    public partial class MainViewWindow : Window
    {
        public MainViewWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (check == MessageBoxResult.Yes)
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Hide();
            }
        }

        private void dasboardBtn_Click(object sender, RoutedEventArgs e)
        {
            dashboardUC.Visibility = Visibility.Visible;
            addEmployeeUC.Visibility = Visibility.Hidden;
            
            dashboardUC.CallRefresh();
        }

        private void addEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            dashboardUC.Visibility = Visibility.Hidden;
            addEmployeeUC.Visibility = Visibility.Visible;
        }
    }
}
