using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmEmployeeList.xaml
    /// </summary>
    
    public partial class frmEmployeeList : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Employee> employees = new List<Employee>();
        private frmEmployee frmEmployee = new frmEmployee();
        public frmEmployeeList()
        {
            InitializeComponent();
            InitializeEmp();

        }
        public frmEmployeeList(frmEmployee frmEmployee)
        {
            InitializeComponent();
            this.frmEmployee = frmEmployee;
            InitializeEmp();
        }
        private void InitializeEmp()
        {
            employees = fileManager.Read<List<Employee>>("Employees");

            if (employees == null)
            {
                employees = new List<Employee>();
            }
            foreach (Employee employee in employees)
            {
                dgvEmployeeList.Items.Add(employee);
            }
        }

        private void dgvEmployeeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(frmEmployee == null)
            {
                return;
            }
            if(dgvEmployeeList.Items.Count >0 )
            {
                int selectIndex = dgvEmployeeList.SelectedIndex;
                Employee employee = employees[selectIndex];
                frmEmployee.BindData(employee.Id);
                dgvEmployeeList.CommitEdit(DataGridEditingUnit.Row,true);
                this.Close();
            }
        }
    }
}
