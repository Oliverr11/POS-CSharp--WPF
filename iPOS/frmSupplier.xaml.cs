using iPOS.Model;
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
using System.Xml.Linq;

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmSupplier.xaml
    /// </summary>
    public partial class frmSupplier : Window
    {
        private readonly List<Supplier> suppliers = null;
        private readonly FileManager fileManager = new FileManager();
        public frmSupplier()
        {
            InitializeComponent();
            suppliers = fileManager.Read<List<Supplier>>("Suppliers");
            if (suppliers == null)
            {
                suppliers = new List<Supplier>();
            }
            Clear();
        }
        private void Clear()
        {
            txtId.Text = GetLastId().ToString();
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        private int GetLastId()
        {
            if(suppliers == null || suppliers.Count == 0)
            {
                return 1;
            }
            else
            {
                return suppliers.OrderByDescending(s => s.Id).FirstOrDefault().Id +1; 
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string phone = txtPhone.Text;   
            string address = txtAddress.Text;
            Supplier supplier = new Supplier(id,name,phone,address);
            suppliers.Add(supplier);
            fileManager.Wirte("Suppliers",suppliers);
            MessageBox.Show("Added Successfully!");
            Clear();
        }

        public void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            frmSupplierList frmSupplierList = new frmSupplierList(this);
            
            frmSupplierList.ShowDialog();
        }
        public void BindData(int id)
        {
            Supplier supplier = suppliers.Where(s => s.Id == id).FirstOrDefault();
            if(supplier != null)
            {
                txtId.Text = supplier.Id.ToString();
                txtName.Text = supplier.Name.ToString();
                txtPhone.Text = supplier.Phone.ToString();
                txtAddress.Text = supplier.Address.ToString();
            }
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            Supplier supplier = suppliers.Where(s => s.Id == id).FirstOrDefault();
            if(supplier != null)
            {
                supplier.Id = id;
                supplier.Name = name;
                supplier.Phone = phone;
                supplier.Address = address;
                fileManager.Wirte("Suppliers", suppliers);
                MessageBox.Show("Update Successfully!");
                Clear();
            }
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id=int.Parse(txtId.Text);
            Supplier supplier = suppliers.Where(suppliers => suppliers.Id == id).FirstOrDefault();
            if(supplier != null)
            {
                suppliers.Remove(supplier);
                fileManager.Wirte("Suppliers", suppliers);
                Clear();
                MessageBox.Show("Deleted Successfully!");
            }
        }
    }
}
