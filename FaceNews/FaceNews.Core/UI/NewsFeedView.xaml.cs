using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FaceNews.Core.UI
{
	public partial class NewsFeedView : ContentPage
	{
		public ObservableCollection<Article> articles { get; set; }

		public NewsFeedView()
		{
			InitializeComponent();

			articles = new ObservableCollection<Article>();
            listView.ItemsSource = articles;

            refreshStories();
            
		}

        private async void refreshStories()
        {
            listView.IsRefreshing = true;
            var resp = await NewsService.Instance.GetNewsAsync();
            articles = new ObservableCollection<Article>(collection: resp.value);
            listView.IsRefreshing = false;
        }
	}
}
