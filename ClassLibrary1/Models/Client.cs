using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Library.Models
{
    public class Client
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private DateTime openDate;
        public DateTime OpenDate { get {  return openDate; } set {  openDate = value; } }

        private DateTime closedDate;
        public DateTime ClosedDate { get { return closedDate; } set {  closedDate = value; } }

        private Boolean isActive;
        public Boolean IsActive {  get { return isActive; } set { isActive = value; } }

        public String? Name { get; set; }
        public String? Notes { get; set; }

        public override string ToString()
        {
            return "\nId: " + $"{Id}" + "\nOpenDate: " + $"{OpenDate}" +
                "\nClosedDate: " + $"{ClosedDate}" + "\nIsActive: " + $"{IsActive}" +
                "\nName: " + $"{Name}" + "\nNotes: " + $"{Notes}";     
        }
    }
}
