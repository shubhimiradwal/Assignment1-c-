using System;
using System.Reflection;

namespace ConsoleApp3
{
    class Employee
    {
        private int Id;
        private string Name;
        private string DepartmentName;
        public string[] s = new string[3];
        public int i;
        public delegate void EmployeeDelegate(string[] msg, int i);
        public event EmployeeDelegate employ;




        public Employee(int Id, string Name, string DepartmentName)
        {
            this.Id = Id;
            this.Name = Name;
            this.DepartmentName = DepartmentName;
        }

        public Employee()
        {
        }

        public void GetId(Employee emp)
        {
            i = 0;
            s[0] = MethodBase.GetCurrentMethod().Name;
            emp.employ += new Employee.EmployeeDelegate(Changesmade);
            emp.Changeobserved();
            Console.WriteLine(Id);
        }
        public void GetName(Employee emp)
        {
            i = 1;
            s[1] = MethodBase.GetCurrentMethod().Name;
            emp.employ += new Employee.EmployeeDelegate(Changesmade);
            emp.employ -= new Employee.EmployeeDelegate(Changesmade);
            emp.Changeobserved();

            Console.WriteLine(Name);

            
        }
        public void GetDepartmentName(Employee emp)
        {
            i = 2;
            s[2] = MethodBase.GetCurrentMethod().Name;
            emp.employ += new Employee.EmployeeDelegate(Changesmade);
            emp.employ -= new Employee.EmployeeDelegate(Changesmade);
            emp.Changeobserved();
            Console.WriteLine(DepartmentName);

        }

        public void Update(int Id)
        {
            this.Id = int.Parse(Console.ReadLine());
        }

        public void Update(string Name)
        {
            this.Name = Console.ReadLine();
        }

        public void Update(string Name, string DepartmentName)

        {
            this.Name = Console.ReadLine();
            this.DepartmentName = Console.ReadLine();
        }


        public void Changeobserved()
        {
            employ(s, i);
        }
        static void Changesmade(string[] msg,int i)
        {
            Console.WriteLine(msg[i]+ "method called");
        }

        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the id");
            int Id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter DepartmentName");
            String DepartmentName = Console.ReadLine();
            Employee emp = new Employee(Id , Name,  DepartmentName);
            emp.GetId(emp);
            emp.GetName(emp);
            emp.GetDepartmentName(emp);
        }
 

    }
}
