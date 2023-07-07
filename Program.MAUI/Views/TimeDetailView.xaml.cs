using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

[QueryProperty(nameof(TimeId), "timeId")]
public partial class TimeDetailView : ContentPage
{
	public TimeDetailView()
	{
		InitializeComponent();
		BindingContext = new TimeDetailViewModel();
	}

	public int TimeId
	{
		get; set;
	}

	public void AddClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeDetailViewModel).AddTime(Shell.Current);
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Time");
	}

	private void Onleaving(object sender, NavigatedFromEventArgs e)
	{
		BindingContext = null;
	}

	private void OnArriving(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new TimeDetailViewModel(TimeId);
	}
}