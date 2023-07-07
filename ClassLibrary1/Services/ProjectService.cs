using Program.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private static object _lock = new object();
        public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if(instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }
        }
        private List<Project> projectList;
        private ProjectService()
        {
            projectList = new List<Project> { };
        }

        public List<Project> ProjectList
        {
            get { return projectList; }
        }

        private int idIncrementP;
        public int IdIncrementP
        {
            get
            {
                if (projectList.Count == 0) { idIncrementP++; }
                else
                {
                    for (int i = 0; i < projectList.Count; i++)
                    {
                        idIncrementP = projectList[i].Id;
                        if (projectList[i].Id > idIncrementP)
                        {
                            idIncrementP = projectList[i].Id;
                        }
                        idIncrementP++;
                    }
                }
                return idIncrementP;
            }
        }

        public List<Project> Search(string query)
        {
            return ProjectList.Where(s => s.ShortName.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Project? Get(int id)
        {
            return projectList.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Project? project)
        {
            if(project != null)
            {
                projectList.Add(project);
            }
        }

        public void Delete(int s)
        {
            var p = ProjectList.FirstOrDefault(c => c.Id == s);
            if (p != null)
            {
                ProjectList.Remove(p);
            }
        }

        public Project? GetById(int id)
        {
            return ProjectList.FirstOrDefault(p => p.Id == id);
        }

        public void Read()
        {
            projectList.ForEach(Console.WriteLine);
        }
    }
}
