using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmCustomer.xaml
    /// </summary>
    public partial class frmCustomer : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Customer> customers = null;
        public frmCustomer()
        {
            InitializeComponent();
            customers = fileManager.Read<List<Customer>>("Customers");
            if (customers == null)
            {
                customers = new List<Customer>();
            }
            Clear();
        }
        private void Clear()
        {
            txtId.Text = GetLastedId().ToString();
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;

        }
        private int GetLastedId()
        {
            if (customers.Count == 0 || customers == null)
            {
                return 1;
            }
            else
            {
                return customers.OrderByDescending(x => x.Id).FirstOrDefault().Id+1;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            Customer customer = new Customer(id, name,phone,address);
            customers.Add(customer);
            fileManager.Wirte("Customers", customers);
            MessageBox.Show("Added Successfully!");
            Clear();
        }
        public void BindData(int id)
        {
            Customer customer = customers.Where(c => c.Id == id).FirstOrDefault();  
            if (customer != null)
            {
                txtId.Text = customer.Id.ToString();
                txtName.Text= customer.Name.ToString();
                txtPhone.Text= customer.Phone.ToString();
                txtAddress.Text= customer.Address.ToString();
            }
        }

        public void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList(this);
            frmCustomerList.ShowDialog();
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Customer customer= customers.Where(categories => categories.Id == id).FirstOrDefault();
            if (customer != null)
            {
                customers.Remove(customer);
                fileManager.Wirte("Customers", customers);
                Clear();
                MessageBox.Show("Deleted Successfully!");
            }
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                Customer customer = customers.Where(c => c.Id == id).FirstOrDefault();
                if (customer != null)
                {
                    
                        customer.Id = id;
                        customer.Name = name;
                        customer.Phone = phone;
                        customer.Address = address;
                        fileManager.Wirte("Customers", customers);
                        MessageBox.Show("Updated Successfully!");

                        Clear();
                }
            
        }
    }
}
