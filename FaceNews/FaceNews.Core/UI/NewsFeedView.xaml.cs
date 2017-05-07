using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using FaceNews.Core.BusinessLogic;


namespace FaceNews.Core.UI
{
	public partial class NewsFeedView : ContentPage
	{
        public NewsFeedView()
        {
            InitializeComponent();
            
            setup();
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        private async void setup()
        {
            listView.IsRefreshing = true;
            listView.ItemsSource = NewsEmotionLogic.Instance.currentArticles;
            listView.ItemSelected += articleSelected;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                camButtonPressed(this, null);
            };
            cameraButton.GestureRecognizers.Add(tapGestureRecognizer);
            var result = await NewsEmotionLogic.Instance.downloadStories();
            handleError(result);
            result = await NewsEmotionLogic.Instance.updateStories();
            handleError(result);
            listView.IsRefreshing = false;
        }

        /// <summary>
        /// Cams the button pressed.
        /// </summary>
        /// <param name="oberserver">The oberserver.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void camButtonPressed(object oberserver, EventArgs e)
        {

            listView.IsRefreshing = true;
            var result = await NewsEmotionLogic.Instance.updateHappiness();
            listView.IsRefreshing = false;
            await DisplayAlert(title: "Face Analysis:", message: NewsEmotionLogic.Instance.emotions.ToString(), cancel: "OK");
            handleError(result);
            result = await NewsEmotionLogic.Instance.updateStories();
            handleError(result);
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="result">The result.</param>
        private async void handleError(string result)
        {
            if (result != null)
            {
                await DisplayAlert(title: "Whoops!", message: result, cancel: "Darn, OK.");
            }
        }

        /// <summary>
        /// Articles the selected.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private async void articleSelected(object observer, SelectedItemChangedEventArgs e)
        {
            var uri = (e.SelectedItem as Article).url;
            await Navigation.PushAsync(new WebPage(uri: uri));
        }
    }
}
