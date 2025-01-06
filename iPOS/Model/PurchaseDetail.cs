using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class PurchaseDetail
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Unit {  get; set; }
        public int Quantity { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public PurchaseDetail() { }
        public PurchaseDetail(int id, string name,string unit, int quantity, double costPrice, double sellingPrice)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            CostPrice = costPrice;
            SellingPrice = sellingPrice;
            Unit = unit;
        }
    }
}
