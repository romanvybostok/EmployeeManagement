using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void xButtonLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void xButtonLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            RegisterAccountWindow regWindow = new RegisterAccountWindow();
            regWindow.Show();
            this.Hide();
        }

        private void showPasswordCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            loginPasswordVisible.Visibility = Visibility.Visible;
            loginPasswordHidden.Visibility = Visibility.Hidden;
            loginPasswordVisible.Text = loginPasswordHidden.Password;
        }

        private void showPasswordCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            loginPasswordVisible.Visibility = Visibility.Hidden;
            loginPasswordHidden.Visibility = Visibility.Visible;
            loginPasswordHidden.Password = loginPasswordVisible.Text;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                UserModel u = new UserModel();

                u.Username = loginUsernameVal.Text.Trim().ToLower();

                if (showPasswordCheckbox.IsChecked == true)
                {
                    u.Password = loginPasswordVisible.Text.Trim();
                }
                else if (showPasswordCheckbox.IsChecked == false)
                {
                    u.Password = loginPasswordHidden.Password.Trim();
                }

                int count = GlobalConfig.Connection.GetUser_CountByLogin(u);


                if (count > 0)
                {
                    MessageBox.Show("Login successful!", "Information Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainViewWindow mvw = new MainViewWindow();
                    mvw.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private bool ValidateData()
        {
            return true;
        }
    }
}