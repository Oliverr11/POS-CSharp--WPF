using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class SaleDetail
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Unit {  get; set; }
        public double SellingPrice {  get; set; }
        public double TotalPrice { get; set; }
        public SaleDetail() { }
        public SaleDetail(int id, string producName, int quantity, string unit, double sellingPrice, double totalPrice)
        {
            Id = id;
            ProductName = producName;
            Quantity = quantity;
            Unit = unit;
            SellingPrice = sellingPrice;
            TotalPrice = totalPrice;
        }
        //public List<SaleDetail> GetAll()
        //{
        //    var saleDetails = new List<SaleDetail>();
        //    for(int i = 1; i <= 10; i++)
        //    {
        //        var saleDetail = new SaleDetail(i,"name-"+i, i,"unit-"+i,i*200,i*200);
        //        saleDetails.Add(saleDetail);    
        //    }
        //    return saleDetails;
        //}
    }
}
