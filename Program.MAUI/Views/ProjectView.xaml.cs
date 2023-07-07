using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(ClientIdTemp), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientIdTemp { get; set; }
    public int ClientId { get; set; }
	public ProjectView()
	{
		InitializeComponent();
	}

    private void ClientIdCheck(int id)
    {
        if(id > 0)
        {
            ClientId = id;
        }
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Search();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Refresh();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).AddProject(Shell.Current, ClientId);
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).EditProject(Shell.Current, ClientId);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).Delete();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        ClientIdCheck(ClientIdTemp);
        BindingContext = new ProjectViewViewModel(ClientId);
        (BindingContext as ProjectViewViewModel).Refresh();
    }
}