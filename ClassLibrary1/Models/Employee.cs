using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Library.Models
{
    public class Employee
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }

        }
        private double rate;
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public String? Name { get; set; }

        public override string ToString()
        {
            return "\nId: " + $"{Id}" + "\nRate: " + $"{Rate}" +
                "\nName: " + $"{Name}";
        }

    }
}
