using Program.Library.Models;
using Program.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.MAUI.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Employee>(EmployeeService.Current.EmployeeList);
                }
                return new ObservableCollection<Employee>(EmployeeService.Current.Search(Query));
            }
        }

        public string Query { get; set; }
        public Employee SelectedEmployee { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Employees");
        }

        public void Refresh()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
            NotifyPropertyChanged("Employees");
        }

        public void AddEmployee(Shell s)
        {
            s.GoToAsync($"//EmployeeDetail?employeeId=0");
        }

        public void EditEmployee(Shell s)
        {
            var idParam = SelectedEmployee?.Id ?? 0;
            s.GoToAsync($"//EmployeeDetail?employeeId={idParam}");
        }

        public void Delete()
        {
            if(SelectedEmployee == null)
            {
                return;
            }
            EmployeeService.Current.Delete(SelectedEmployee);
            NotifyPropertyChanged("Employees");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
