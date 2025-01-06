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
    /// Interaction logic for frmCustomerList.xaml
    /// </summary>
    public partial class frmCustomerList : Window
    {
        private FileManager fileManager = new FileManager();
        private List<Customer> customers = null;
        private frmCustomer frmCustomer = new frmCustomer();
        public frmCustomerList()
        {
            Initialize();
        }
        public frmCustomerList(frmCustomer frmCustomer)
        {
            this.frmCustomer = frmCustomer;
            customers = fileManager.Read<List<Customer>>("Customers");
            Initialize();
            
        }
        private void Initialize()
        {
            InitializeComponent();

            customers = fileManager.Read<List<Customer>>("Customers");
            if (customers == null)
            {
                customers = new List<Customer>();
            }
            foreach (Customer customer in customers)
            {
                dgvCustomer.Items.Add(customer);
            }

        }

        private void dgvCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(frmCustomer == null)
            {
                return;
            }
            if(dgvCustomer.Items.Count > 0)
            {
                int selectIndex = dgvCustomer.SelectedIndex;
                Customer customer = customers[selectIndex];
                frmCustomer.BindData(customer.Id);
                dgvCustomer.CommitEdit(DataGridEditingUnit.Row,true);
                this.Close();
            }
        }
    }
}
