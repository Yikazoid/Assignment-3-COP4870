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
    public class ProjectDetailViewModel : INotifyPropertyChanged
    {
        private Project project;
        public ProjectDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }
        public int Id { get; set; }
        public DateTime OpenDate {get; set;}
        public DateTime ClosedDate { get; set; }
        public string IsActiveString { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientId { get; set; }

        public void LoadById(int id)
        {
            if(id == 0) { return; }
            var project = ProjectService.Current.GetById(id);
            if(project != null)
            {
                Id = project.Id;
                OpenDate = project.OpenDate;
                ClosedDate = project.ClosedDate;
                IsActiveString = BoolToString(project.IsActive);
                ShortName = project.ShortName;
                LongName = project.LongName;
                ClientId = project.ClientId;
            }
            NotifyPropertyChanged(nameof(Id));
            NotifyPropertyChanged(nameof(OpenDate));
            NotifyPropertyChanged(nameof(ClosedDate));
            NotifyPropertyChanged(nameof(ShortName));
            NotifyPropertyChanged(nameof(LongName));
            NotifyPropertyChanged(nameof(ClientId));
        }

        public void AddProject(Shell s, int cId)
        {
            if (Id <= 0)
            {
                ProjectService.Current.Add(new Project
                {
                    Id = ProjectService.Current.IdIncrementP,
                    OpenDate = DateTime.Now,
                    ClosedDate = ClosedDate,
                    IsActive = StringToBool(IsActiveString),
                    ShortName = ShortName,
                    LongName = LongName,
                    ClientId = cId
                });
            }
            else
            {
                var refToUpdate = ProjectService.Current.GetById(Id) as Project;
                refToUpdate.ClosedDate = ClosedDate;
                refToUpdate.IsActive = StringToBool(IsActiveString);
                refToUpdate.ShortName = ShortName;
                refToUpdate.LongName = LongName;
                refToUpdate.ClientId = ClientId;

                if (refToUpdate.IsActive == false) { refToUpdate.ClosedDate = DateTime.Now; }
                if (refToUpdate.IsActive == true) { refToUpdate.ClosedDate = new DateTime(); }
            }
            Shell.Current.GoToAsync("//Project");
        }

        private Boolean StringToBool(string s)
        {
            Boolean b;
            switch (s)
            {
                case "True":
                default:
                    b = true;
                    break;
                case "False":
                    b = false;
                    break;
            }
            return b;
        }

        private string BoolToString(Boolean b)
        {
            var cString = string.Empty;
            switch (b)
            {
                case true:
                default:
                    cString = "True";
                    break;
                case false:
                    cString = "False";
                    break;
            }
            return cString;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
