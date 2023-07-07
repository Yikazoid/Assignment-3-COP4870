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
    public class TimeDetailViewModel : INotifyPropertyChanged
    {
        private Time time;
        public TimeDetailViewModel(int id = 0)
        {
            if(id > 0)
            {
                LoadById(id);
            }
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Narrative { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public void LoadById(int id)
        {
            if(id == 0) { return; }
            var time = TimeService.Current.GetById(id);
            if(time != null)
            {
                Id = time.Id;
                Date = time.Date;
                Narrative = time.Narrative;
                ProjectId = time.ProjectId;
                EmployeeId = time.EmployeeId;
            }
            NotifyPropertyChanged(nameof(Id));
            NotifyPropertyChanged(nameof(Date));
            NotifyPropertyChanged(nameof(Narrative));
            NotifyPropertyChanged(nameof(ProjectId));
            NotifyPropertyChanged(nameof(EmployeeId));
        }

        public void AddTime(Shell s)
        {
            if(Id <= 0)
            {
                TimeService.Current.Add(new Time
                {
                    Id = TimeService.Current.IdIncrement,
                    Date = DateTime.Now,
                    Narrative = Narrative,
                    ProjectId = ProjectId,
                    EmployeeId = EmployeeId

                });
            }
            else
            {
                var refToUpdate = TimeService.Current.GetById(Id) as Time;
                refToUpdate.Narrative = Narrative;
                refToUpdate.ProjectId = ProjectId;
                refToUpdate.EmployeeId = EmployeeId;
            }
            Shell.Current.GoToAsync("//Time");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
