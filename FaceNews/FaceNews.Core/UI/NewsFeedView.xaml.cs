using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FaceNews.Core.UI
{
	public partial class NewsFeedView : ContentPage
	{
		public ObservableCollection<NewsFeedViewModel> test { get; set; }

		public NewsFeedView()
		{
			InitializeComponent();

			test = new ObservableCollection<NewsFeedViewModel>();
			test.Add(new NewsFeedViewModel { Name = "Testing", Type = "an image", Image = "MyEqualizer.png" });
			test.Add(new NewsFeedViewModel { Name = "Testing2", Type = "the second image", Image = "MyEqualizer.png" });
			test.Add(new NewsFeedViewModel { Name = "Testing3", Type = "the third image", Image = "MyEqualizer.png" });

			listView.ItemsSource = test;

		}
	}
}
