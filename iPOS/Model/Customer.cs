using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iPOS.Model
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Phone { get; set; }
        public string Address { get; set; }
        public Customer() { }
        public Customer(int id, string name, string phone, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
        }
        public static List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            for(int i = 1; i <= 10; i++)
            {
                var customer = new Customer(i,"name-"+1,"0909093232","pp");
                customers.Add(customer);
            }
            return customers;
        }
    }
}
