using Program.Library.Models;
using Program.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.MAUI.ViewModels;

public class ProjectViewViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Project> Projects
    {
        get
        {
            if (string.IsNullOrEmpty(Query))
            {
                return new ObservableCollection<Project>(ProjectService.Current.ProjectList);
            }
            return new ObservableCollection<Project>(ProjectService.Current.Search(Query));
        }
    }

    public ProjectViewViewModel(int clientId)
    {
        if (clientId > 0)
        {
            Client = ClientService.Current.Get(clientId);
        }
        else
        {
            Client = new Client();
        }

    }

    public Client Client { get; set; }
    public string Query { get; set; }
    public Project SelectedProject { get; set; }
    public int ClientId { get; set; }

    public void Search()
    {
        NotifyPropertyChanged("Projects");
    }

    public void Refresh()
    {
        Query = string.Empty;
        NotifyPropertyChanged(nameof(Query));
        NotifyPropertyChanged("Projects");
    }

    public void AddProject(Shell s, int clientId)
    {
        var id = clientId;
        s.GoToAsync($"//ProjectDetail?projectId=0&clientId={id}");
    }

    public void EditProject(Shell s, int clientId)
    {
        var idParam = SelectedProject?.Id ?? 0;
        var id = clientId;
        s.GoToAsync($"//ProjectDetail?projectId={idParam}&clientId={id}");
    }

    public void Delete()
    {
        if(SelectedProject == null)
        {
            return;
        }
        ProjectService.Current.Delete(SelectedProject.Id);
        SelectedProject = null;
        NotifyPropertyChanged("Projects");
        NotifyPropertyChanged("SelectedProject");
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
