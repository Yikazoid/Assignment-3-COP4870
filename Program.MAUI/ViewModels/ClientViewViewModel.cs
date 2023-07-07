using Program.Library.Models;
using Program.Library.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Program.MAUI.ViewModels;

public class ClientViewViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Client> Clients
    {
        get
        {
            if (string.IsNullOrEmpty(Query))
            {
                return new ObservableCollection<Client>(ClientService.Current.ClientList);
            }
            return new ObservableCollection<Client>(ClientService.Current.Search(Query));
        }
    }

    public string Query { get; set; }
    public Client SelectedClient { get; set; }

    public void Search()
    {
        NotifyPropertyChanged("Clients");
    }

    public void Refresh()
    {
        Query = string.Empty;
        NotifyPropertyChanged(nameof(Query));
        NotifyPropertyChanged("Clients");
    }

    public void AddClient(Shell s)
    {
        s.GoToAsync($"//ClientDetail?clientId=0");
    }

    public void EditClient(Shell s)
    {
        var idParam = SelectedClient?.Id ?? 0;
        s.GoToAsync($"//ClientDetail?clientId={idParam}");
    }

    public void ProjectsClient(Shell s)
    {
        var idParam = SelectedClient?.Id ?? 0;
        if (idParam == 0)
        {
            return;
        }
        s.GoToAsync($"//Project?clientId={idParam}");
    }

    public void Delete()
    {
        if (SelectedClient == null)
        {
            return;
        }
        ClientService.Current.Delete(SelectedClient);
        NotifyPropertyChanged("Clients");
    }


    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}