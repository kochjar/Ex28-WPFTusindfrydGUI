using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_WPFTusindfrydGUI.Model
{
    public class EmployeeRepository
    {
        private List<Employee> employees;
        public EmployeeRepository() {
            employees = new List<Employee>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("employees.txt"))
                {
                    // Read the stream to a string, and instantiate a Person object
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(';');
                        // Adds an employee to the repository list based of the parts in each line of employees.txt
                        this.Add(parts[0], int.Parse(parts[1]), parts[2], parts[3]);

                        
                        line = sr.ReadLine();
                        
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }
        public Employee Add(string name, int age, string cpr, string imgPath)
        {
            Employee employee = new Employee(name, age, cpr, imgPath);
            employees.Add(employee);
            return employee;
        }

        public void UpdateEmployee(int id, string name, int age, string cpr, string imgPath)
        {
            bool FoundPerson = false;
            foreach (Employee employee in employees)
            {   if (id == employee.Id)
                {
                    employee.Name = name;
                    employee.Age = age;
                    employee.Cpr = cpr;
                    employee.ImgPath = imgPath;
                    FoundPerson = true;
                    
                } 
            }

            if (FoundPerson == false)
            { throw (new ArgumentException($"Person with ID of {id} was not found.")); }

            Debug.WriteLine(employees[0].Name);
        }

        public void RemoveEmployee(int id) {
            for (int i = employees.Count - 1; i >= 0; i--)
            {
                if (id == employees[i].Id) employees.RemoveAt(i);
            }
        }

        public Employee Get(int id)
        {
            foreach (Employee employee in employees)
            { if (id == employee.Id) return employee;}
            return null;
        }
        public List<Employee> GetAll()
        {
            return employees;
        }


    }
}
