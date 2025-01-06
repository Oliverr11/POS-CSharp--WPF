using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Permissions;
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
    /// Interaction logic for frmEmployee.xaml
    /// </summary>
    public partial class frmEmployee : Window
    {
        private List<Employee> employees = null;
        private FileManager fileManager = new FileManager();
        public frmEmployee()
        {
            InitializeComponent();

            employees = fileManager.Read<List<Employee>>("Employees");
            if(employees == null )
            {
                employees = new List<Employee>();
            }
            Clear();
        }
        private void Clear()
        {
            txtId.Text = GetLastestId().ToString();
            txtName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassowrd.Password = string.Empty;
            txtPhone.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        private int GetLastestId()
        {
            if(employees == null || employees.Count == 0)
            {
                return 1;
            }
            else
            {
                return employees.OrderByDescending(e => e.Id).FirstOrDefault().Id+1;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassowrd.Password;
            string phone = txtPhone.Text;
            double salary = double.Parse(txtSalary.Text);
            string address = txtAddress.Text;
            Employee employee = new Employee(id,name,username,password,salary,phone,address);
            employees.Add(employee);
            fileManager.Wirte("Employees", employees);
            MessageBox.Show("Added Successfully!");
            Clear();
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassowrd.Password;
            string phone = txtPhone.Text;
            double salary = double.Parse(txtSalary.Text);
            string address = txtAddress.Text;
            Employee employee = employees.Where(ee => ee.Id == id).FirstOrDefault();
            if(employee != null)
            {
                employee.Id = id;
                employee.Name = name;
                employee.Username = username;
                employee.Password = password;
                employee.Phone = phone;
                employee.Salary = salary;
                employee.Address = address;
                fileManager.Wirte("Employees", employees);
                MessageBox.Show("Updated Successfully!");
                Clear();
            }
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Employee employee = employees.Where(employees => employees.Id == id).FirstOrDefault();
            if(employee != null)
            {
                employees.Remove(employee);
                fileManager.Wirte("Employees", employees);
                Clear();
                MessageBox.Show("Delelted Successfully!");
            }
        }
        
        public void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            frmEmployeeList frmEmployeeList = new frmEmployeeList(this);
            frmEmployeeList.ShowDialog();
        }
        public void BindData(int id)
        {
            Employee employee = employees.Where(e=>e.Id == id).FirstOrDefault();
            if(employee != null)
            {
                txtId.Text = employee.Id.ToString();
                txtName.Text = employee.Name.ToString();
                txtUsername.Text = employee.Username.ToString();
                txtPassowrd.Password = employee.Password.ToString();
                txtPhone.Text = employee.Phone.ToString();
                txtSalary.Text = employee.Salary.ToString();
                txtAddress.Text = employee.Address.ToString();
            }
        }
    }
}
