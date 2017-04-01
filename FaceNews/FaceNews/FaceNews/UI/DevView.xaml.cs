using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Plugin.Media;

using FaceNews.BusinessLogic;

namespace FaceNews.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DevView : ContentPage
    {

        public DevView()
        {
            InitializeComponent();
            CaptureButton.Clicked += image;
        }

        private async void image(object observer, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                SaveToAlbum = false,
                DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
            });

            ImageView.Source = ImageSource.FromStream(() => file.GetStream());
        }
    }
}
