using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetailView : ContentPage
{
	public EmployeeDetailView()
	{
		InitializeComponent();
		BindingContext = new EmployeeDetailViewModel();
	}

	public int EmployeeId { get; set; }

	public void AddClicked(object sender, EventArgs e)
	{
		(BindingContext as EmployeeDetailViewModel).AddEmployee(Shell.Current);
	}

	public void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Employee");
	}

	private void OnLeaving(object sender, NavigatedFromEventArgs e)
	{
		BindingContext = null;
	}

	private void OnArriving(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new EmployeeDetailViewModel(EmployeeId);
	}
}