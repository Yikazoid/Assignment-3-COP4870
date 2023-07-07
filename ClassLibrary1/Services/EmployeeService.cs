using Program.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Library.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        private static object _lock = new object();
        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                    {
                        instance = new EmployeeService();
                    }
                }
                return instance;
            }
        }
        private List<Employee> employeeList;
        private EmployeeService()
        {
            employeeList = new List<Employee> { };
        }

        public List<Employee> EmployeeList
        {
            get
            {
                return employeeList;
            }
        }

        private int idIncrement;
        public int IdIncrement
        {
            get
            {
                if(employeeList.Count == 0) { idIncrement++; }
                else
                {
                    for(int i = 0; i < employeeList.Count; i++)
                    {
                        idIncrement = employeeList[i].Id;
                        if (employeeList[i].Id > idIncrement)
                        {
                            idIncrement = employeeList[i].Id;
                        }
                    }
                    idIncrement++;
                }
                return idIncrement;
            }
        }

        public List<Employee> Search(string query)
        {
            return EmployeeList.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Employee? Get(int id)
        {
            return employeeList.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee? employee)
        {
            if(employee != null)
            {
                employeeList.Add(employee);
            }
        }

        public void Delete(int id)
        {
            var employeeToRemove = Get(id);
            if(employeeToRemove != null)
            {
                employeeList.Remove(employeeToRemove);
            }
        }

        public Employee? GetById(int id)
        {
            return EmployeeList.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Employee s)
        {
            Delete(s.Id);
        }

        public void Read()
        {
            employeeList.ForEach(Console.WriteLine);
        }
    }
}
