using iPOS.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for frmSupplierList.xaml
    /// </summary>
    public partial class frmSupplierList : Window
    {
        FileManager fileManager = new FileManager();
        List<Supplier> suppliers = null;
        frmSupplier frmSupplier = new frmSupplier();
        public frmSupplierList()
        {
            Initialize();
        }
        public frmSupplierList(frmSupplier frmSupplier)
        {   
            this.frmSupplier = frmSupplier;
            Initialize();
        }
        private void Initialize()
        {
            InitializeComponent();
            suppliers = fileManager.Read<List<Supplier>>("Suppliers");
            if (suppliers == null)
            {
                suppliers = new List<Supplier>();
            }
            foreach (var supplier in suppliers)
            {
                dgvSupplierList.Items.Add(supplier);
            }
        }

        private void dgvSupplierList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(frmSupplier == null)
            {
                return;
            }
            if(dgvSupplierList.Items.Count > 0)
            {
                int selectIndex = dgvSupplierList.SelectedIndex;
                Supplier supplier = suppliers[selectIndex];

                frmSupplier.BindData(supplier.Id);

                dgvSupplierList.CommitEdit(DataGridEditingUnit.Row,true);
                this.Close();
            }
        }
    }
}
