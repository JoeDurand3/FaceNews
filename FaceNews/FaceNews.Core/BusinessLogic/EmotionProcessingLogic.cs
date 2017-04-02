﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Media;

using Xamarin.Forms;

namespace FaceNews.Core.BusinessLogic
{
    class EmotionProcessingLogic
    {
        public static EmotionProcessingLogic Instance { get; } = new EmotionProcessingLogic();

        private ImageSource _imageData;

        /// <summary>
        /// Gets the image data.
        /// </summary>
        /// <value>
        /// The image data.
        /// </value>
        public ImageSource imageData
        {
            get
            {
                return _imageData;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="EmotionProcessingLogic"/> class from being created.
        /// </summary>
        private EmotionProcessingLogic()
        {
            
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void getImage(object observer, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = false,
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Front
                });

                _imageData = ImageSource.FromStream(() => file.GetStream());
            }
            catch (Exception)
            {
                //do nothing
            }
        }

    }
}
