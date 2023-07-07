using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Program.Library.Models
{
    public class Time
    {
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
        public string? Narrative { get; set; }
        private int hours;
        public int Hours
        {
            get
            {
                return hours;
            }

            set
            {
                hours = value;
            }
        }
        private int projectId;
        public int ProjectId
        {
            get
            {
                return projectId;
            }

            set
            {
                projectId = value;
            }
        }
        private int employeeId;
        public int EmployeeId
        {
            get
            {
                return employeeId;
            }

            set
            {
                employeeId = value;
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public override string ToString()
        {
            return "\nDate:" + $"{Date}" + "\nNarrative: " + $"{Narrative}" +
                "\nHours: " + $"{Hours}" + "\nProjectId: " + $"{ProjectId}" +
                "\nEmployeeId: " + $"{EmployeeId}";
        }

    }
}
