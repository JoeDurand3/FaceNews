using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;

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

        private async void camButtonPressed(object oberserver, EventArgs e)
        {
            var result = await NewsEmotionLogic.Instance.updateHappiness();
            handleError("happiness is " + NewsEmotionLogic.Instance.emotions.scores.happiness);
            handleError(result);
            result = await NewsEmotionLogic.Instance.updateStories();
            handleError(result);
        }

        private async void handleError(string result)
        {
            if (result != null)
            {
                await DisplayAlert(title: "Whoops!", message: result, cancel: "Darn, OK.");
            }
        }
        
        private async void articleSelected(object observer, SelectedItemChangedEventArgs e)
        {
            var uri = (e.SelectedItem as Article).url;
            await Navigation.PushAsync(new WebPage(uri: uri));
        }


    }
}
