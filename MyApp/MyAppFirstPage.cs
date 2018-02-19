using Xamarin.Forms;
using System;

namespace MyApp
{
    public class MyAppFirstPage : ContentPage
    {
        Entry phoneNumberText;
        Button translateButton;
        Button callButton;
        string translatedNumber;

        public MyAppFirstPage(){
            
            this.Padding = new Thickness(20, 20, 20, 20);
            StackLayout panel = new StackLayout();
            panel.Spacing = 15;

            // Creating and adding view elements to LayoutContainer(for instance: StackLayout)
            panel.Children.Add(new Label { Text = "Enter a PhoneWord", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) });
            panel.Children.Add(phoneNumberText = new Entry{ Text = "1-855-XAMARIN" });
            panel.Children.Add(translateButton = new Button(){ Text = "Translate"});
            panel.Children.Add(callButton = new Button(){ Text = "Call", IsEnabled = false});

            //Adding action to buttons
            translateButton.Clicked += TranslateButton_Clicked;
            callButton.Clicked += CallButton_Clicked;

            //Setting LayoutContainer to ContentPage
            this.Content = panel;
        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            if(await this.DisplayAlert("Dail a Number", "Would you like to call" + translatedNumber + "?", "Yes", "No")){
                IDailer dialer = DependencyService.Get<IDailer>();
                if(dialer != null){
                    await dialer.DialAsync(translatedNumber);
                }
            }
        }

        private void TranslateButton_Clicked(object sender, System.EventArgs e)
        {
            translatedNumber = Core.PhoneWordTranslator.ToNumber(phoneNumberText.Text);
            if(!string.IsNullOrEmpty(translatedNumber)){
                callButton.IsEnabled = true;
                callButton.Text = "Call  " + translatedNumber;
            }else{
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }
    }
}
