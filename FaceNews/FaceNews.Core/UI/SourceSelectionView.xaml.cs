using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FaceNews.Core.UI
{
	public partial class SourceSelectionView : ContentPage
	{
		public ObservableCollection<SourceSelectionViewModel> test { get; set; }

		public SourceSelectionView()
		{
			InitializeComponent();

			test = new ObservableCollection<SourceSelectionViewModel>();
			test.Add(new SourceSelectionViewModel { Name = "one", Image = "lindsey.jpg", Name2 = "two", Image2 = "lindsey.jpg", Name3 = "three", Image3 = "lindsey.jpg"});
			test.Add(new SourceSelectionViewModel { Name = "four", Image = "lindsey.jpg", Name2 = "five", Image2 = "lindsey.jpg", Name3 = "six", Image3 = "lindsey.jpg" });

			asdfView.ItemsSource = test;

		}
	}
}
