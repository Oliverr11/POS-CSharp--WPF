using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmSale.xaml
    /// </summary>
    public partial class frmSale : Window
    {
        public string productFileName = "Product";
        public string customerFileName = "Customers";
        public string employeeFileName = "Employees";
        public string saleFileName = "Sales";

        private FileManager fileManager = new FileManager();
        private List<Product> products = null;
        private List<Customer> customers = null;
        private List<Employee> employees = null;
        private List<Sale> sales = null;
        private List<SaleDetail> salesDetails = null;
        public frmSale()
        {
            InitializeComponent();
        
            products = fileManager.Read<List<Product>>(productFileName);
            customers = fileManager.Read<List<Customer>>(customerFileName);
            employees = fileManager.Read<List<Employee>>(employeeFileName);
            sales = fileManager.Read<List<Sale>>(saleFileName);
            if(products == null)
            {
                products = new List<Product>();
            }
            if(customers == null)
            {
                customers = new List<Customer>();
            }
            if (employees == null)
            {
                employees = new List<Employee>();
            }
            if (sales == null)
            {
                sales = new List<Sale>();
            }

            foreach(Product product in products)
            {
                cmbProductName.Items.Add(product.Name);
            }
            foreach(Customer customer in customers)
            {
                cmbCustomerName.Items.Add(customer.Name);
            }
            foreach(Employee employee in employees)
            {
                cmbEmployee.Items.Add(employee.Name);
            }
            RefreshBindHistory();
            MainClear();
        }
        private void RefreshBindHistory()
        {
            cmbHistoryId.Items.Clear();
            foreach (Sale sale in sales)
            {
                cmbHistoryId.Items.Add(sale.InvoiceId);
            }
        }
        private void SubClear()
        {
            
            cmbProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
        }
        private void MainClear()
        {
            SubClear();
            txtInvoiceId.Text = GetNewInvoiceId().ToString();
            cmbCustomerName.Text = string.Empty;
            cmbEmployee.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
            txtTotalPrice.Text = string.Empty;
            txtAmountPaid.Text = string.Empty;
            txtBalance.Text = string.Empty;
            cmbHistoryId.Text = string.Empty;

            dgvSale.ItemsSource = string.Empty;

            salesDetails = new List<SaleDetail>();
            RefreshBindHistory();
        }
        private int GetNewInvoiceId()
        {
            if(sales.Count == 0 || sales == null)
            {
                return 1;
            }
            else
            {
                return sales.OrderByDescending(s => s.InvoiceId).FirstOrDefault().InvoiceId+1;
            }

        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            SubClear();
        }

        private void btnNewSet_Click(object sender, RoutedEventArgs e)
        {
            MainClear();
        }

        private void cmbProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbProductName.SelectedValue == null)
            {
                return;
            }
            string productName = cmbProductName.SelectedValue.ToString();
            if(string.IsNullOrEmpty(productName))
            {
                return;
            }
            var product = products.Where(p => p.Name == productName).FirstOrDefault();
            if(product != null)
            {
                txtQuantity.Text = "1";
                txtSellingPrice.Text = product.SellingPrice.ToString();
                txtTotalPrice.Text = product.SellingPrice.ToString(); 
            }
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int quantity = int.Parse(txtQuantity.Text);
                if(quantity >= 0)
                {
                    double sellingPrice = double.Parse(txtSellingPrice.Text);
                    double totalPrice = quantity* sellingPrice;
                    txtTotalPrice.Text = totalPrice.ToString();
                }
                
            }catch(Exception ){}
        }
        private int GetSaleDetailNo()
        {

            SaleDetail saleDetail = salesDetails.OrderByDescending(s => s.Id).FirstOrDefault();
            if(saleDetail != null)
            {
                return saleDetail.Id + 1;
            }
            return 1;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = GetSaleDetailNo();
            string produtName = cmbProductName.Text;
            int quantity = int.Parse(txtQuantity.Text);

            var product = products.Where(p => p.Name == produtName).FirstOrDefault();
            if(product != null)
            {
                double sellingPrice = product.SellingPrice;
                double totalPrice = quantity* sellingPrice;
                string unit = product.Unit;
                SaleDetail detail = new SaleDetail(id,produtName,quantity,unit,sellingPrice,totalPrice);
                salesDetails.Add(detail);
                BindSaleDataToGrid();
                SubClear();
            }
        }
        private void BindSaleDataToGrid()
        {
            dgvSale.ItemsSource = null;
            dgvSale.ItemsSource = salesDetails;
            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            double totalAmount = 0;
            foreach(var detail in salesDetails)
            {
                totalAmount += detail.TotalPrice;
            }
            txtTotalAmount.Text = totalAmount.ToString();
            txtAmountPaid.Text = totalAmount.ToString();
            txtBalance.Text = "0";
            tbTotalAmount.Text = totalAmount.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCustomerName.Text))
            {
                MessageBox.Show("Please Select Customer");
                return;
            } 
            if (string.IsNullOrEmpty(cmbEmployee.Text))
            {
                MessageBox.Show("Please Select Employee");
                return;
            }
            if(salesDetails.Count <= 0)
            {
                MessageBox.Show("Please add some product.");
                return;
            }

            Sale sale = new Sale();
            sale.InvoiceId = GetNewInvoiceId();
            sale.CustomerName = cmbCustomerName.Text;
            sale.EmployeeName = cmbEmployee.Text;
            sale.SaleDetails = salesDetails;
            sale.TotalAmount = double.Parse(txtTotalAmount.Text);
            sale.TotalAmountPaid = double.Parse(txtAmountPaid.Text);
            sale.RemainAmount = double.Parse(txtBalance.Text);
            sales.Add(sale);
            fileManager.Wirte(saleFileName, sales);
            MainClear();
            MessageBox.Show("Save successfully!");
        }

        private void cmbHistoryId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbHistoryId.SelectedValue == null) {
                return;
            }
            int invoiceId = (int)cmbHistoryId.SelectedValue;
            Sale sale = sales.Where(s => s.InvoiceId == invoiceId).FirstOrDefault();
            if(sale != null)
            {
                cmbCustomerName.Text = sale.CustomerName;
                cmbEmployee.Text = sale.EmployeeName;
                salesDetails = sale.SaleDetails;
                
                BindSaleDataToGrid();
                txtAmountPaid.Text = sale.TotalAmountPaid.ToString();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(dgvSale.SelectedItems.Count == 0) { return; }
            int selectedIndex = dgvSale.SelectedIndex;
            salesDetails.RemoveAt(selectedIndex);
            for(int i = 0; i < dgvSale.Items.Count; i++)
            {
                salesDetails[i].Id = i+1;
            }
            BindSaleDataToGrid();
        }

       

        private void txtAmountPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double totalAmount = double.Parse(txtTotalAmount.Text);
                double totalAmountPaid = double.Parse(txtAmountPaid.Text);
                double balance = totalAmountPaid - totalAmount;
                txtBalance.Text = balance.ToString();
            }
            catch (Exception) { }
        }

        private void cmbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvSale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
