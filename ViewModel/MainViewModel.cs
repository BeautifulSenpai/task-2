using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Task_2.ViewModel
{

    public partial class MainViewModel : ObservableObject, INotifyPropertyChanged
    {
        private string convertNumber;
        [ObservableProperty]
        public string labelText = "Enter phone number";
        [ObservableProperty]
        public string phoneNumber = "+7-910-434-64-64";
        [ObservableProperty]
        public string convertButton = "Convert";
        [ObservableProperty]
        public string callButton = "Call";
        [ObservableProperty]
        private bool isReady = false;


        [RelayCommand]
        void Convert()
        {
            convertNumber = Task2.ToNumber(phoneNumber);
            if (!string.IsNullOrEmpty(convertNumber))
            {
                callButton = $"Call: {convertNumber}";
                this.IsReady = true;
            }
            else
            {
                callButton = "Call";
                this.IsReady = false;
            }
        }

        [RelayCommand]
         async void Call()
         {
            if (await App.Current.MainPage.DisplayAlert("Notification", "Are you sure you want to call this number?", "Yes", "No"))
            {
                if (await App.Current.MainPage.DisplayAlert(
                    "Dial the number",
                    "Call " + convertNumber + "?",
                    "Yes",
                    "No"))
                {
                    try
                    {
                        if (PhoneDialer.Default.IsSupported)
                            PhoneDialer.Default.Open(convertNumber);
                    }
                    catch (ArgumentNullException)
                    {
                        await App.Current.MainPage.DisplayAlert("Unable to dial number", "Phone number was invalid.", "OK");

                    }
                    catch (Exception)
                    {
                        await App.Current.MainPage.DisplayAlert("Unable to dial", "Failed to dial the phone number.", "OK");

                    }
                }

            }
         }


    }
}

