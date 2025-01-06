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
    /// Interaction logic for frmProduct.xaml
    /// </summary>
    public partial class frmProduct : Window
    {
        private readonly List<Product> products = null;
        private readonly List<Category> categories = null;
        private FileManager fileManager = new FileManager();
        public frmProduct()
        {
            InitializeComponent();
            //Util.GenerateSampleCategory();

            products = fileManager.Read<List<Product>>("Product");
            categories = fileManager.Read<List<Category>>("Category");
            if (products == null)
            {
                products = new List<Product>();
            }
            foreach (Category category in categories)
            {
                cmbCategory.Items.Add(category.Name);
            }
            Clear();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            string unit = txtUnit.Text;
            double costPrice = double.Parse(txtCostPrice.Text);
            double sellingPrice = double.Parse(txtSellingPrice.Text);
            string categoryName = cmbCategory.Text;
            Category categorymodel = categories.Where(c => c.Name == categoryName).FirstOrDefault();
            Product product = new Product(id, name, categorymodel, costPrice, sellingPrice, unit);
            products.Add(product);
            fileManager.Wirte("Product", products);
            MessageBox.Show("Add Successfully");
            Clear();
        }
        private void Clear()
        {
            txtId.Text = GetLastestId().ToString();
            txtName.Text = string.Empty;
            cmbCategory.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;

        }
        private int GetLastestId()
        {
            if (products == null || products.Count == 0)
            {
                return 1;
            }
            else
            {
                return products.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            }
        }

        private void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            frmProductList frmProductList = new frmProductList(this);
            frmProductList.ShowDialog();
        }
        public void BindData(int id)
        {
            Product product = products.Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                //MessageBox.Show("product : " + product.Id + ", " + product.Name + ", " + product.Category.Name);
                //this.DataContext = product;
                txtId.Text = product.Id.ToString();
                txtName.Text = product.Name;
                txtCostPrice.Text = product.CostPrice.ToString();
                txtSellingPrice.Text = product.SellingPrice.ToString();
                txtUnit.Text = product.Unit.ToString();
                cmbCategory.Text = product.Category.Name;
                
            }
            else
            {
                MessageBox.Show($"Product with ID {id} not found.");
            }
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            double costPrice = double.Parse(txtCostPrice.Text);
            double sellingPrice = double.Parse(txtSellingPrice.Text);
            string category = cmbCategory.Text;
            Product product = products.Where(p => p.Id == id).FirstOrDefault();
            if(product != null)
            {
                product.Id = id;
                product.Name = name;
                product.CostPrice = costPrice;
                product.SellingPrice = sellingPrice;
                product.Category.Name = category;
                
                fileManager.Wirte("Product", products);

                MessageBox.Show("Updated Successfully!");
                
                Clear();
            }
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Product product = products.Where(p =>p.Id == id).FirstOrDefault();
            if (product != null)
            {
                products.Remove(product);
                fileManager.Wirte("Product", products);
                Clear();
                MessageBox.Show("Deleted Successfully!");
            }
        }
    }
}
