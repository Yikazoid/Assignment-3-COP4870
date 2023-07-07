using Program.Library.Models;
using Program.Library.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Program.MAUI.ViewModels;

public class ClientDetailViewModel : INotifyPropertyChanged
{
    private Client client;
    public ClientDetailViewModel(int id = 0)
    {
       if(id > 0)
        {
            LoadById(id);
        }
    }
    public int Id { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime ClosedDate { get; set; }
    public string IsActiveString { get; set; }
    public string Name { get; set; }
	public string Notes { get; set; }

    public void LoadById(int id)
    {
        if(id == 0) { return; }
        var client = ClientService.Current.GetById(id);
        if(client != null)
        {
            Id = client.Id;
            OpenDate = client.OpenDate;
            ClosedDate = client.ClosedDate;
            IsActiveString = BoolToString(client.IsActive);
            Name = client.Name;
            Notes = client.Notes;
        }
        NotifyPropertyChanged(nameof(Id));
        NotifyPropertyChanged(nameof(OpenDate));
        NotifyPropertyChanged(nameof(ClosedDate));
        NotifyPropertyChanged(nameof(IsActiveString));
        NotifyPropertyChanged(nameof(Name));
        NotifyPropertyChanged(nameof(Notes)); 
    }
    public void AddClient(Shell s)
    {
        if(Id <= 0)
        {
            ClientService.Current.Add(new Client
            {
                Id = ClientService.Current.IdIncrement,
                OpenDate = DateTime.Now,
                ClosedDate = ClosedDate,
                IsActive = StringToBool(IsActiveString),
                Name = Name,
                Notes = Notes
            });
        }
        else
        {
            var refToUpdate = ClientService.Current.GetById(Id) as Client;
            refToUpdate.ClosedDate = ClosedDate;
            refToUpdate.IsActive = StringToBool(IsActiveString);
            refToUpdate.Name = Name;
            refToUpdate.Notes = Notes;

            if(refToUpdate.IsActive == false) { refToUpdate.ClosedDate = DateTime.Now; }
            if(refToUpdate.IsActive == true) { refToUpdate.ClosedDate = new DateTime(); }
        }
        Shell.Current.GoToAsync("//Client");
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