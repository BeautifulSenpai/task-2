using Task_2.ViewModel;

namespace Task_2;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
    }

	private void ConvertButton_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(PhoneNumber.Text))
        {
            CallButton.IsEnabled = true;
        }
        else
        {
            CallButton.IsEnabled = false;

        }
    }
}

