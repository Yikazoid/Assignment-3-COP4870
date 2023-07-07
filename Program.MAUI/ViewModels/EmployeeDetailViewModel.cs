using Program.Library.Models;
using Program.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.MAUI.ViewModels
{
    public class EmployeeDetailViewModel : INotifyPropertyChanged
    {
        private Employee employee;
        public EmployeeDetailViewModel(int id = 0)
        {
            if(id > 0)
            {
                LoadById(id);
            }
        }
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }

        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var employee = EmployeeService.Current.GetById(id);
            if(employee != null)
            {
                Id = employee.Id;
                Rate = employee.Rate;
                Name = employee.Name;
            }
            NotifyPropertyChanged(nameof(Id));
            NotifyPropertyChanged(nameof(Rate));
            NotifyPropertyChanged(nameof(Name));
        }

        public void AddEmployee(Shell s)
        {
            if(Id <= 0)
            {
                EmployeeService.Current.Add(new Employee
                {
                    Id = EmployeeService.Current.IdIncrement,
                    Rate = Rate,
                    Name = Name
                });
            }
            else
            {
                var refToUpdate = EmployeeService.Current.GetById(Id) as Employee;
                refToUpdate.Rate = Rate;
                refToUpdate.Name = Name;
            }
            Shell.Current.GoToAsync("//Employee");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
