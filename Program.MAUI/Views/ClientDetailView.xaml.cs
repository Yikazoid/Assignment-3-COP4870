using Program.Library.Models;
using Program.Library.Services;
using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
        BindingContext = new ClientDetailViewModel();
	}

	public int ClientId
	{
        get; set;
    }

    public void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientDetailViewModel).AddClient(Shell.Current);
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientDetailViewModel(ClientId);
    }
}