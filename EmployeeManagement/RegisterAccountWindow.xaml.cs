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
    /// Interaction logic for RegisterAccountWindow.xaml
    /// </summary>
    public partial class RegisterAccountWindow : Window
    {
        List<UserModel> users = GlobalConfig.Connection.GetUser_All();
        public RegisterAccountWindow()
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

        private void signinBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        //registerPassword

        private void showPasswordCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            registerPasswordVisible.Visibility = Visibility.Visible;
            registerPasswordHidden.Visibility = Visibility.Hidden;
            registerPasswordVisible.Text = registerPasswordHidden.Password;
        }

        private void showPasswordCheckbox_Unchecked(object sender, RoutedEventArgs e)
        {
            registerPasswordVisible.Visibility = Visibility.Hidden;
            registerPasswordHidden.Visibility = Visibility.Visible;
            registerPasswordHidden.Password = registerPasswordVisible.Text;
        }

        private void signupBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                UserModel u = new UserModel();

                u.Username = registerUsernameVal.Text.Trim().ToLower();

                if (showPasswordCheckbox.IsChecked == true)
                {
                    u.Password = registerPasswordVisible.Text.Trim();
                }
                else if (showPasswordCheckbox.IsChecked == false)
                {
                    u.Password = registerPasswordHidden.Password.Trim();
                }

                int count = GlobalConfig.Connection.GetUser_CountOfSameUsername(u);


                if (count > 0)
                {
                    MessageBox.Show("Username taken");
                }
                else
                {
                    GlobalConfig.Connection.CreateUser(u);

                    MessageBox.Show("Registration successful!", "Information Message", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }
            }
        }

        private bool ValidateData()
        {
            if (registerUsernameVal.Text == "" || registerPasswordVisible.Text == "" || registerPasswordHidden.Password == "")
            {
                MessageBox.Show("Please fill all the blank fields.", "Error Message", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
