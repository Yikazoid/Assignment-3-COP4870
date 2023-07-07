using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
		BindingContext = new EmployeeViewViewModel();
	}

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).Search();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).Refresh();
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).AddEmployee(Shell.Current);
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).EditEmployee(Shell.Current);
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).Delete();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).Refresh();
    }
}