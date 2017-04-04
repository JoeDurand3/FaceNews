using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using System.IO;
//using XLabs.Forms.Mvvm;
//using XLabs.Ioc;
//using XLabs.Platform.Device;
//using XLabs.Platform.Services.Media;

using Plugin.Media;
using Plugin.Media.Abstractions;


namespace FaceNews.Core.BusinessLogic
{
    public class EmotionProcessingLogic
    {
        public static EmotionProcessingLogic Instance { get; } = new EmotionProcessingLogic();

        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        /// <summary>
		/// The picture chooser.
		/// </summary>
		//private IMediaPicker _mediaPicker;

        public MediaFile MediaFile;


        /// <summary>
        /// Prevents a default instance of the <see cref="EmotionProcessingLogic"/> class from being created.
        /// </summary>
        private EmotionProcessingLogic()
        {

        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        /*private void Setup()
        {
            if (_mediaPicker != null)
            {
                return;
            }

            var device = Resolver.Resolve<IDevice>();

            ////RM: hack for working on windows phone? 
            _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
        }*/

        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <returns>Take Picture Task.</returns>
       /* public async Task<string> TakePicture1()
        {
            Setup();

            MediaFile = null;

            return await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    return t.Exception.InnerException.ToString();
                }
                else if (t.IsCanceled)
                {
                    return "Canceled";
                }
                else
                {
                    MediaFile = t.Result;

                    return null;
                }

            }, _scheduler);
        }*/


        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <returns>Take Picture Task.</returns>
        public async Task<string> TakePicture()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return "Camera not available, or photos not supported";
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return "no photo";

            MediaFile = file;
            return null;
        }
    }
}
