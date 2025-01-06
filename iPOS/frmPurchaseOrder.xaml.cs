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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmPurchaseOrder.xaml
    /// </summary>
    public partial class frmPurchaseOrder : Window
    {
        public string productFileName = "Product";
        public string employeeFileName = "Employees";
        public string purchaseFileName = "Purchase";

        private FileManager fileManager = new FileManager();
        private List<Product> products = null;
        private List<Employee> employees = null;
        private List<PurchaseDetail> purchasesDetail= null; 
        private List<Purchase> purchases =null;
        public frmPurchaseOrder()
        {
            InitializeComponent();
            products = fileManager.Read<List<Product>>(productFileName);
            employees = fileManager.Read<List<Employee>>(employeeFileName);
            purchases = fileManager.Read<List<Purchase>>(purchaseFileName);
            if (products == null)
            {
                products = new List<Product>();
            }
            if (employees == null)
            {
                employees = new List<Employee>();
            }
            if (purchasesDetail == null)
            {
                purchasesDetail = new List<PurchaseDetail>(); 
            }
            if (purchases == null)
            {
                purchases = new List<Purchase>(); 
            }
            foreach (Product p in products)
            {
                cmbProductName.Items.Add(p.Name);
            }
            foreach(Employee p in employees)
            {
                cmbEmployeeName.Items.Add(p.Name);
            }
            RefreshBindHistory();
            MainClear();
        }

        private void cmbHistoryId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbHistoryId.SelectedValue == null)
            {
                return; 
            }
            int purchaseId = (int)cmbHistoryId.SelectedValue;
            Purchase purchase = purchases.Where(p => p.PurchaseID == purchaseId).FirstOrDefault();
            if(purchase != null)
            {
                cmbEmployeeName.Text = purchase.EmployeeName;
                purchasesDetail = purchase.PurchaseDetails;

                BindPurchaseDataToGrid();
                
            }
        }

        private void cmbEmployeeName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnProductNew_Click(object sender, RoutedEventArgs e)
        {
            SubClear();
        }
        private void SubClear()
        {
            cmbProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
        }
        private void MainClear()
        {
            SubClear();
            txtId.Text = GetNewPurchaseId().ToString();
            cmbEmployeeName.Text = string.Empty;
            cmbHistoryId.Text = string.Empty;
            dgvPurchase.ItemsSource = string.Empty;
            purchasesDetail = new List<PurchaseDetail>();
            RefreshBindHistory();
        }

        private void RefreshBindHistory()
        {
             cmbHistoryId.Items.Clear();
            foreach(Purchase p in purchases)
            {
                cmbHistoryId.Items.Add(p.PurchaseID);
            }
        }
        private void btnProductAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = GetPurchaseDetailNo();
            string productName = cmbProductName.Text;
            int quantity = int.Parse( txtQuantity.Text);
            double costPrice = double.Parse( txtCostPrice.Text);
            double sellingPrice = double.Parse ( txtSellingPrice.Text);
            var product = products.Where(p => p.Name == productName).FirstOrDefault();
            if (product != null)
            {
                string unit = product.Unit;
                PurchaseDetail purchase = new PurchaseDetail(id,productName,unit,quantity,costPrice,sellingPrice);
                purchasesDetail.Add(purchase);
                BindPurchaseDataToGrid();
            }
            SubClear();
        }
        private int GetPurchaseDetailNo()
        {
            PurchaseDetail purchase = purchasesDetail.OrderByDescending(p => p.Id).FirstOrDefault();
            if (purchase != null)
            {
                return purchase.Id + 1;
            }
            return 1;
        }
        private void BindPurchaseDataToGrid()
        {
            dgvPurchase.ItemsSource = null;
            dgvPurchase.ItemsSource = purchasesDetail;
        }

        private void btnProductRemove_Click(object sender, RoutedEventArgs e)
        {
            if(dgvPurchase.SelectedItems.Count == 0)
            {
                return;
            }
            int selectedIndex = dgvPurchase.SelectedIndex;
            purchasesDetail.RemoveAt(selectedIndex);
            for (int i = 0; i < dgvPurchase.Items.Count; i++)
            {
                purchasesDetail[i].Id = i + 1;
            }
            BindPurchaseDataToGrid();
        }
        private int GetNewPurchaseId()
        {
            if (purchases.Count == 0 || purchases == null)
            {
                return 1;
            }
            return purchases.OrderByDescending(p=>p.PurchaseID).FirstOrDefault().PurchaseID+1;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEmployeeName.Text))
            {
                MessageBox.Show("Please Select Employee Name");
                return;
            }

            Purchase purchase = new Purchase();
            
            purchase.PurchaseID = GetNewPurchaseId();
            purchase.EmployeeName = cmbEmployeeName.Text;
            purchase.PurchaseDetails = purchasesDetail;
            purchases.Add(purchase);
            fileManager.Wirte(purchaseFileName, purchases);
            MainClear();
            MessageBox.Show("Save successfully!");
            
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            MainClear();
        }
    }
}
