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
    /// Interaction logic for frmCategory.xaml
    /// </summary>
    public partial class frmCategory : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Category> categories = new List<Category>();
        
        public frmCategory()
        {
            InitializeComponent();
            categories = fileManager.Read<List<Category>>("Category");
            if (categories == null)
            {
                categories = new List<Category>();
            }

            Clear();
        }
        public void Clear()
        {
            txtId.Text = GetLastedId().ToString();
            txtName.Text = string.Empty;
        }
        public int GetLastedId()
        {
            if (categories.Count == 0 || categories == null)
            {
                return 1;
            }
            else
            {
                return categories.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            Category category = new Category(id,name);
            categories.Add(category);
            fileManager.Wirte("Category", categories);
            MessageBox.Show("Added Successfully!");
            Clear();
        }

        public void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string name = txtName.Text;
            Category category = categories.Where(c => c.Id == id).FirstOrDefault();
            if (category!=null)
            {
                category.Id = id;
                category.Name = name;
                fileManager.Wirte("Category", categories);
                MessageBox.Show("Updated Successfully!");
                Clear();
            }
        }

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtId.Text);
            Category category = categories.Where(categories => categories.Id == id).FirstOrDefault();
            if (category!=null)
            {
                categories.Remove(category);
                fileManager.Wirte("Category", categories);
                Clear();
                MessageBox.Show("Deleted Successfully!");
            }
        }
        
        public void BindData(int id)
        {
            Category category = categories.Where(c => c.Id==id).FirstOrDefault();
            if (category!=null)
            {
                txtId.Text = category.Id.ToString();
                txtName.Text = category.Name.ToString();
            }
        }

        public void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList(this);
            frmCategoryList.ShowDialog();
        }
    }
}
