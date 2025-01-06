using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string EmployeeName {  get; set; }
        public List<PurchaseDetail> PurchaseDetails { get; set; }
        public Purchase()
        {
            PurchaseDetails = new List<PurchaseDetail>();
        }
        public Purchase(int purchaseID, string employeeName, List<PurchaseDetail> purchaseDetails)
        {
            PurchaseID = purchaseID;
            EmployeeName = employeeName;
        }
    }
}
