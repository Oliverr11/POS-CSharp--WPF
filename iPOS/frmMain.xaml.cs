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

namespace iPOS
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Product> products = null;
        private frmProduct frmProduct = new frmProduct();
        public frmMain()
        {
            InitializeComponent();
            InitDgvProduct();
        }
        private void InitDgvProduct()
        {
            products = fileManager.Read<List<Product>>("Product");
            if (products == null)
            {
                products = new List<Product>();
            }
            foreach (var product in products)
            {
                dgvProductListMain.Items.Add(product);
            }
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.ShowDialog();
        }
        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.ShowDialog();
        }

        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.ShowDialog();
        }

        private void btnSale_Click(object sender, RoutedEventArgs e)
        {
            frmSale frmSale = new frmSale();
            frmSale.ShowDialog();
        }

        private void btnSupplier_Click(object sender, RoutedEventArgs e)
        {
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.ShowDialog();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            frmProduct frmProduct = new frmProduct();
            frmProduct.ShowDialog();
            RefreshMainFrm();
        }
        private void RefreshMainFrm()
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }
        private void frmEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMiniMize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }
        private void btnPurchase_Click(object sender, RoutedEventArgs e)
        {
            frmPurchaseOrder frmPurchaseOrder = new frmPurchaseOrder();
            frmPurchaseOrder.ShowDialog();
        }
        private void miBrowseEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmEmployeeList frmEmployeeList = new frmEmployeeList();
            frmEmployeeList.ShowDialog();
        }

        private void miDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            frmEmployee.btnBrowse_Click(sender,e);
            frmEmployee.btnDelete_Click(sender, e);
        }

        private void miUpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee frmEmployee = new frmEmployee();
            
            frmEmployee.btnBrowse_Click(sender, e);

                frmEmployee.ShowDialog();
                try
                {
                    frmEmployee.btnUpdate_Click(sender, e);
                }
                catch (Exception) { }

        }

        private void miDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.btnBrowse_Click(sender, e);
            frmCustomer.btnDelete_Click(sender, e);
        }

        private void miUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();

            frmCustomer.btnBrowse_Click(sender, e);
                frmCustomer.ShowDialog();
                try
                {
                    frmCustomer.btnUpdate_Click(sender, e);
                }
                catch(Exception) { }
        }

        private void miBrowseCustomer_Click(object sender, RoutedEventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList();
            frmCustomerList.ShowDialog();
        }

        private void miDeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            frmCategory frmCategory = new frmCategory();
            frmCategory.btnBrowse_Click(sender, e);
            frmCategory.btnDelete_Click(sender, e);
        }

        private void miUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            frmCategory frmCategory = new frmCategory();

            frmCategory.btnBrowse_Click(sender, e);
            frmCategory.ShowDialog();
            try
            {
                frmCategory.btnUpdate_Click(sender, e);
            }catch(Exception) { }
        }

        private void miBrowseCategory_Click(object sender, RoutedEventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList();
            frmCategoryList.ShowDialog();
        }

        private void miDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.btnBrowse_Click(sender, e);
            frmSupplier.btnDelete_Click(sender, e);
        }

        private void miUpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.btnBrowse_Click(sender,e);
            frmSupplier.ShowDialog();
            try
            {
                frmSupplier.btnUpdate_Click(sender, e);
            }catch(Exception) { }
        }

        private void miBrowseSupplier_Click(object sender, RoutedEventArgs e)
        {
            frmSupplierList frmSupplierList = new frmSupplierList();
            frmSupplierList.ShowDialog();
        }

        private void miDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            frmProduct frmProduct = new frmProduct();
            frmProduct.btnBrowse_Click(sender, e);
            frmProduct.btnDelete_Click(sender, e);
            RefreshMainFrm();
        }

        private void miUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            frmProduct frmProduct = new frmProduct();
            frmProduct.btnBrowse_Click(sender, e);
            frmProduct.ShowDialog();
            try
            {
                RefreshMainFrm();
                frmProduct.btnUpdate_Click(sender, e);
            }catch(Exception) { }
        }

        private void miBrowseProduct_Click(object sender, RoutedEventArgs e)
        {
            frmProductList frmProductList = new frmProductList();
            frmProductList.ShowDialog();
        }
    }
}
