using Program.MAUI.ViewModels;

namespace Program.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();
		BindingContext = new TimeViewViewModel();
	}

	private void SearchClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeViewViewModel).Search();
	}

	private void RefreshClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeViewViewModel).Refresh();
	}

	private void AddClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeViewViewModel).AddTime(Shell.Current);
	}

	private void EditClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeViewViewModel).EditTime(Shell.Current);
	}

	private void DeleteClicked(object sender, EventArgs e)
	{
		(BindingContext as TimeViewViewModel).Delete();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TimeViewViewModel).Refresh();
    }
}
