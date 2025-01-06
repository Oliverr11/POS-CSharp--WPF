using iPOS.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for frmCategoryList.xaml
    /// </summary>
    public partial class frmCategoryList : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Category> categories = null;
        private frmCategory frmCategory = new frmCategory();
        public frmCategoryList()
        {
            Initialize();
        }
        public frmCategoryList(frmCategory frmCategory)
        {
            
            this.frmCategory = frmCategory;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();
            categories = fileManager.Read<List<Category>>("Category");
            if (categories == null)
            {
                categories = new List<Category>();
            }
            foreach (Category category in categories)
            {
                dgvCategoryList.Items.Add(category);
            }
        }

        private void dgvCategoryList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             if(frmCategory == null)
                {
                    return;
                }
            if(dgvCategoryList.Items.Count > 0)
            {
                    int selectIndex = dgvCategoryList.SelectedIndex;
                    Category category = categories[selectIndex];
                    frmCategory.BindData(category.Id);
                    dgvCategoryList.CommitEdit(DataGridEditingUnit.Row,true);
                    this.Close();

        }
    }
    
    }
}
