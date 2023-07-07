using Program.Library.Models;
using Program.Library.Services;
using Program.MAUI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Program.MAUI.Views;

public partial class ClientView : ContentPage
{
    public ClientView()
    {
        InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Search();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Refresh();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).AddClient(Shell.Current);
    } 

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).EditClient(Shell.Current);
    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).ProjectsClient(Shell.Current);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Delete();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).Refresh();
    }
}