using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace iPOS.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Salary { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Employee() { }
        public Employee(int id, string name, string username, string password, double salary, string phone, string address)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Salary = salary;
            Phone = phone;
            Address = address;
        }
        //public static List<Employee> GetAll()
        //{
        //    var employees = new List<Employee>();
        //    for(int i = 1; i<= 10; i++)
        //    {
        //        var employee = new Employee(i,"emp-"+i,"username-"+i,"password"+i+1, i+1000,"090312312"+i,"pp-"+i);
        //        employees.Add(employee);    
        //    }
        //    return employees;
        //}
    }
}
