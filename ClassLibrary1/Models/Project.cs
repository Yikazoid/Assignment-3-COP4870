using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program.Library.Models
{
    public class Project
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private DateTime openDate;
        public DateTime OpenDate { get { return openDate; } set { openDate = value; } }

        private DateTime closedDate;
        public DateTime ClosedDate { get { return closedDate; } set { closedDate = value; } }

        private Boolean isActive;
        public Boolean IsActive { get { return isActive; } set { isActive = value; } }

        public String? ShortName { get; set; }
        public String? LongName { get; set; }

        private int clientId;
        public int ClientId { get { return clientId; } set { clientId = value; } }

        public Client? client;

        public override string ToString()
        {
            return "\nId: " + $"{Id}" + "\nClientId: " + $"{ClientId}" + "\nOpenDate: " + $"{OpenDate}" +
                 "\nClosedDate: " + $"{ClosedDate}" + "\nIsActive: " + $"{IsActive}" +
                 "\nShortName: " + $"{ShortName}" + "\nLongName: " + $"{LongName}";
        }
    }
}
