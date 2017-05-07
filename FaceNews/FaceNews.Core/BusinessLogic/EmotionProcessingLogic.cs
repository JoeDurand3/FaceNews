using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.IO;

using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;


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
        /// Authorizes the camera if necessary.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> authorizePermissions()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (status != PermissionStatus.Granted)
            {
                status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera))[0];
            }

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage))[0];
            }

            return (status == PermissionStatus.Granted) ? true : false;
        }

        /// <summary>
        /// Takes the picture.
        /// </summary>
        /// <returns>Take Picture Task.</returns>
        public async Task<string> TakePicture()
        {
            var camAuthorized = await authorizePermissions();

            if (!camAuthorized)
            {
                return "Camera Unauthorized. Verify the camera is enables in app settings.";
            }

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return "Camera not available, or photos not supported";
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "FaceNews",
                Name = "face.jpg"
            });

            if (file == null)
                return "photo error.";

            MediaFile = file;
            return null;
        }
    }
}
