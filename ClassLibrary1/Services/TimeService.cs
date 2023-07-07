using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program.Library.Models;

namespace Program.Library.Services
{
    public class TimeService
    {
        private static TimeService? instance;
        private static object _lock = new object();
        public static TimeService Current
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                    {
                        instance = new TimeService();
                    }
                }
                return instance;
            }
        }

        private List<Time> timeList;
        private TimeService()
        {
            timeList = new List<Time> { };
        }

        public List<Time> TimeList
        {
            get
            {
                return timeList;
            }
        }

        private int idIncrement;
        public int IdIncrement
        { 
            get
            {
                if(timeList.Count == 0) { idIncrement++; }
                else
                {
                    for(int i = 0; i < timeList.Count; i++)
                    {
                        idIncrement = timeList[i].Id;
                        if (timeList[i].Id > idIncrement)
                        {
                            idIncrement = timeList[i].Id;
                        }
                    }
                    idIncrement++;
                }
                return idIncrement;
            }
        }

        public List<Time> Search(string query)
        {
            return TimeList.Where(s => s.Narrative.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Time? Get(int id)
        {
            return timeList.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Time? time)
        {
            if(time != null)
            {
                timeList.Add(time);
            }
        }

        public void Delete(int id)
        {
            var timeToRemove = Get(id);
            if(timeToRemove != null)
            {
                timeList.Remove(timeToRemove);
            }
        }

        public Time? GetById(int id)
        {
            return TimeList.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(Time s)
        {
            Delete(s.Id);
        }

        public void Read()
        {
            timeList.ForEach(Console.WriteLine);
        }
    }
}
