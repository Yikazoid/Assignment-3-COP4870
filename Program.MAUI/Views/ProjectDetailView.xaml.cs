using Program.Library.Models;
using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectDetailView : ContentPage
{
	public ProjectDetailView()
	{
		InitializeComponent();
		//BindingContext = new ProjectDetailViewModel();
	}

	public int ProjectId
	{
		get; set;
	}
	public int ClientId
	{
		get; set;
	}

	public void AddClicked(object sender, EventArgs e)
	{
		(BindingContext as ProjectDetailViewModel).AddProject(Shell.Current, ClientId);
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
        BindingContext = new ProjectDetailViewModel(ProjectId);
    }
}