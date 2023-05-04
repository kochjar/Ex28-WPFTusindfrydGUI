using Ex28_WPFTusindfrydGUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Ex28_WPFTusindfrydGUI.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        private int age;
        private string cpr;
        private string imgPath;
        private Employee employee;
        public string Name { 
            get { return name; } 
            set { name = value;  OnPropertyChanged("Name");} 
        }
        public int Age { 
            get { return age; } 
            set { age = value; OnPropertyChanged("Age"); } 
        }
        public string Cpr { 
            get { return cpr; } 
            set { cpr = value; OnPropertyChanged("Cpr"); } 
        }
        public string ImgPath { 
            get { return imgPath; } 
            set { imgPath = value; OnPropertyChanged("ImgPath"); } 
        }

        public EmployeeViewModel(Employee employee)
        {
            this.employee = employee;
            this.Name = employee.Name;
            this.Age = employee.Age;
            this.Cpr = employee.Cpr;
            this.ImgPath = employee.ImgPath;
        }

        public void DeleteEmployee(EmployeeRepository employeeRepository)
        {
            if (employeeRepository == null) return;
            employeeRepository.RemoveEmployee(employee.Id);
        }

        public int GetId()
        {
            return employee.Id;
        }
    }
}
