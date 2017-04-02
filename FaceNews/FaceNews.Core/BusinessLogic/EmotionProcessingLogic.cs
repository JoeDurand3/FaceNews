using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Media;

using Xamarin.Forms;
using System.IO;

namespace FaceNews.Core.BusinessLogic
{
    public class EmotionProcessingLogic
    {
        public static EmotionProcessingLogic Instance { get; } = new EmotionProcessingLogic();

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
        public async Task<byte[]> getImage()
        {
            try
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {}
                );

                var memoryStream = new MemoryStream();
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                return memoryStream.ToArray();
            }
            catch (Exception)
            {

            }

            return null;
        }

    }
}
