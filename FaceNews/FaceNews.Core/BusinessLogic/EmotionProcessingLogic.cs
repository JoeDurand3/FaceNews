using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.IO;

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
                Name = "face.jpg"
            });

            if (file == null)
                return "no photo";

            MediaFile = file;
            return null;
        }
    }
}
