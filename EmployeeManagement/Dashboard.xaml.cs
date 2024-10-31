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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        List<EmployeeModel> employees = GlobalConfig.Connection.GetEmployee_All();
        public Dashboard()
        {
            InitializeComponent();

            DisplayInfo();
        }

        private void DisplayInfo()
        {
            totalEmpVal.Content = "";
            activeEmpVal.Content = "";
            inactiveEmpVal.Content = "";
            totalEmpVal.Content = employees.Count;
            activeEmpVal.Content = GlobalConfig.Connection.GetEmployee_ActiveCount();
            inactiveEmpVal.Content = GlobalConfig.Connection.GetEmployee_InactiveCount();
        }
        public void CallRefresh()
        {
            DisplayInfo();
        }
    }
}
