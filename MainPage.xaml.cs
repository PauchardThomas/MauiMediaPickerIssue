namespace MediaPickerIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", "No camera available.", "Close");
                return;
            }

            try
            {
                await MediaPicker.CapturePhotoAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Close");
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                await MediaPicker.PickPhotoAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message + ex.Source + ex.StackTrace + ex.InnerException?.StackTrace, "Close");
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }
    }

}
