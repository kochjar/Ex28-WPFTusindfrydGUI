using Ex28_WPFTusindfrydGUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Ex28_WPFTusindfrydGUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null) propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private EmployeeRepository employeeRepository { get; set; } 
        public ObservableCollection<EmployeeViewModel> EmployeesVM { get; set; } = new ObservableCollection<EmployeeViewModel>();

        public EmployeeViewModel currentEmployee { get; set; }
        public MainViewModel() {
            employeeRepository= new EmployeeRepository();

            foreach (Employee employee in employeeRepository.GetAll())
            {
                EmployeesVM.Add(new EmployeeViewModel(employee));
                Debug.WriteLine(employee.Name);
            }
            
        }

        public void UpdateCurrentEmployee()
        {
            OnPropertyChanged("currentEmployee");
            if (currentEmployee!= null) {
              employeeRepository.UpdateEmployee(
              currentEmployee.GetId(),
              currentEmployee.Name,
              currentEmployee.Age,
              currentEmployee.Cpr,
              currentEmployee.ImgPath
          );
            }
      
        }

        public void DeleteCurrentEmployee()
        {
            if (currentEmployee != null)
            { 
                currentEmployee.DeleteEmployee(employeeRepository);
                EmployeesVM.Remove(currentEmployee);
            }
            
        }

        public void AddEmployee()
        {
            Employee employee = employeeRepository.Add("", 0, "", "/View/pb.png");
            EmployeeViewModel employeeViewModel = new EmployeeViewModel(employee);
            EmployeesVM.Add(employeeViewModel);
            currentEmployee = employeeViewModel;
            OnPropertyChanged("currentEmployee");
        }
    }
}
