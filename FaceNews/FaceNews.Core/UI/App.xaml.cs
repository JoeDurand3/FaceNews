using System;
using System.Collections.Generic;

using Xamarin.Forms;

using FaceNews.Core.UI;

namespace FaceNews.Core
{
    /// <summary>
    /// The Xamarin Forms App that exists as the MBS App.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(root: new NewsFeedView());
        }
    }
}
