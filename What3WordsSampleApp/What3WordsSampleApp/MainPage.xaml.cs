using System;
using System.Linq;
using What3Words;
using What3Words.Enums;
using What3WordsSampleApp.Utils;
using Xamarin.Forms;

namespace What3WordsSampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LatitudeLongitudeLanguagePicker.ItemsSource = EnumHelper.GetEnumAsEnumarable<LanguageCode>().ToList();
            LatitudeLongitudeLanguagePicker.SelectedIndex = 2;

            What3WordsLanguagePicker.ItemsSource = EnumHelper.GetEnumAsEnumarable<LanguageCode>().ToList();
            What3WordsLanguagePicker.SelectedIndex = 2;
        }

        private async void GetWhat3WordsAddressButtonOnClicked(object sender, EventArgs e)
        {
            var languageCode = LatitudeLongitudeLanguagePicker.SelectedItem as LanguageCode?;
            var what3wordsService = new What3WordsService(Statics.ApiKey, languageCode ?? LanguageCode.EN);

            var latitude = double.Parse(LatitudeEntry.Text);
            var longitude = double.Parse(LongitudeEntry.Text);
            var result = await what3wordsService.GetReverseGeocodingAsync(latitude, longitude);

            What3WordsAddressLabel.Text = result.Words;
        }

        private async void GetAddressFromWhat3WordsAddressButtonOnClicked(object sender, EventArgs e)
        {
            var languageCode = What3WordsLanguagePicker.SelectedItem as LanguageCode?;
            var what3wordsService = new What3WordsService(Statics.ApiKey, languageCode ?? LanguageCode.EN);

            var address = AddressEntry.Text;
            var result = await what3wordsService.GetForewordGeocodingAsync(address);

            AddressLabel.Text = $"Latitude: {result?.Geometry?.Lat} | Longitude: {result?.Geometry?.Lng}";
        }
    }
}
