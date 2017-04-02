using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FaceNews.Core.UI
{
	public partial class NewsFeedView : ContentPage
	{
        public ObservableCollection<Article> articles { get; set; } = new ObservableCollection<Article>();

		public NewsFeedView()
		{
			InitializeComponent();
            listView.ItemsSource = articles;
            listView.ItemSelected += ViewCell_Tapped;
            refreshStories();
        }

        private async void refreshStories()
        {
            var resp = await NewsService.Instance.GetNewsAsync();
            foreach (Article a in resp.value)
            {
                articles.Add(a);
            }
        }

        private async void ViewCell_Tapped(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var uri = (e.SelectedItem as Article).url;
                await Navigation.PushAsync(new WebPage(uri: uri));
            }
            catch (Exception)
            {

            }
        }
    }
}
