    using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for frmProductList.xaml
    /// </summary>
    public partial class frmProductList : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Product> products = null;
        private frmProduct frmProduct = new frmProduct();
        public frmProductList()
        {
            Initialize();
        }
        public frmProductList(frmProduct frmProduct)
        {
            this.frmProduct = frmProduct;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();
            products = fileManager.Read<List<Product>>("Product");
            if (products == null)
            {
                products = new List<Product>();
            }
            foreach (var product in products)
            {
                dgvProductList.Items.Add(product);
            }
        }
        private void dgvProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(frmProduct == null)
            {
                return;
            }
            if (dgvProductList.SelectedItems.Count > 0)
            {
                int selectedIndex = dgvProductList.SelectedIndex;
                Product product = products[selectedIndex];
                frmProduct.BindData(product.Id);
                //require commit edit
                dgvProductList.CommitEdit(DataGridEditingUnit.Row, true);
                this.Close();
            }
        }
    }
}
