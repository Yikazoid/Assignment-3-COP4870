using Program.MAUI.ViewModels;
using System.ComponentModel.Design;

namespace Program.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void SearchClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Search();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }
    }
}