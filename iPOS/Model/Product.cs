using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public double CostPrice {  get; set; }
        public double SellingPrice {  get; set; }
        public string Unit {  get; set; }

        public Product() { }
        public Product(int id, string name, Category category, double costPrice, double sellingPrice, string unit)
        {
            Id = id;
            Name = name;
            Category = category;
            CostPrice = costPrice;
            SellingPrice = sellingPrice;
            Unit = unit;
        }
    }
}
