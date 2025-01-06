using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class Sale
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public double TotalAmount { get; set; }
        public double TotalAmountPaid {  get; set; }
        public double RemainAmount { get; set; }
        public List<SaleDetail> SaleDetails { get; set; }
        public Sale()
        {
            SaleDetails = new List<SaleDetail>();
        }
        public Sale(int invoiceId, string customerName, string employeeName, double totalAmount, double totalAmountPaid, double remainAmount, List<SaleDetail> saleDetails)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            EmployeeName = employeeName;
            TotalAmount = totalAmount;
            TotalAmountPaid = totalAmountPaid;
            RemainAmount = remainAmount;
        }

    }
}
