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

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {
        List<EmployeeModel> employees = GlobalConfig.Connection.GetEmployee_All();
        EmployeeModel selectedEmployee = new EmployeeModel();
        public AddEmployee()
        {
            InitializeComponent();

            UpdateLists();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel em = new EmployeeModel();

            em.FirstName = empFNameVal.Text;
            em.LastName = empLNameVal.Text;
            em.Gender = empGenderVal.Text;
            em.PhoneNumber = empPNumberVal.Text;
            em.Position = empPositionVal.Text;
            em.Status = empStatusVal.Text;
            em.EmailAddress = empEAddressVal.Text;

            double empSalary = 0;

            if (double.TryParse(empSalaryVal.Text, out empSalary))
            {
                em.Salary = empSalary;
            }
            else
            {
                MessageBox.Show("Please enter a valid salary.");
            }

            GlobalConfig.Connection.CreateEmployee(em);

            employees.Add(em);

            UpdateLists();

            ClearFields();
        }

        private void ClearFields()
        {
            empFNameVal.Text = "";
            empLNameVal.Text = "";
            empGenderVal.Text = "";
            empPNumberVal.Text = "";
            empPositionVal.Text = "";
            empStatusVal.Text = "";
            empEAddressVal.Text = "";
            empSalaryVal.Text = "";
        }

        private void UpdateLists()
        {
            addEmployeeGrid.ItemsSource = "";
            addEmployeeGrid.ItemsSource = employees;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addEmployeeGrid.SelectedItem != null)
            {
                EmployeeModel em = (EmployeeModel)addEmployeeGrid.SelectedItem;

                em.FirstName = empFNameVal.Text;
                em.LastName = empLNameVal.Text;
                em.Gender = empGenderVal.Text;
                em.PhoneNumber = empPNumberVal.Text;
                em.Position = empPositionVal.Text;
                em.Status = empStatusVal.Text;
                em.EmailAddress = empEAddressVal.Text;

                double empSalary = 0;

                if (double.TryParse(empSalaryVal.Text, out empSalary))
                {
                    em.Salary = empSalary;
                }
                else
                {
                    MessageBox.Show("Please enter a valid salary.");
                }

                GlobalConfig.Connection.UpdateEmployee(em);

                UpdateLists();

                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select an item u want to update.");
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (addEmployeeGrid.SelectedItem != null)
            {
                EmployeeModel em = (EmployeeModel)addEmployeeGrid.SelectedItem;

                GlobalConfig.Connection.DeleteEmployee(em);

                employees.Remove(em);

                UpdateLists();

                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select an item u want to delete.");
            }
        }

        private void addEmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = (EmployeeModel)addEmployeeGrid.SelectedItem;

            if (selectedEmployee != null)
            {
                empFNameVal.Text = selectedEmployee.FirstName;
                empLNameVal.Text = selectedEmployee.LastName;
                empGenderVal.Text = selectedEmployee.Gender;
                empPNumberVal.Text = selectedEmployee.PhoneNumber;
                empPositionVal.Text = selectedEmployee.Position;
                empStatusVal.Text = selectedEmployee.Status;
                empEAddressVal.Text = selectedEmployee.EmailAddress;
                empSalaryVal.Text = selectedEmployee.Salary.ToString();
            }
        }
    }
}
