using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FaceNews.Core
{
    public class ImageRecord
    {
        public Thumbnail thumbnail { get; set; }
        public ImageSource imgdata { get; set; }

        public ImageRecord()
        {
            
        }

        public async void downloadImg()
        {
            //imgdata = await ServiceHelper.DownloadRemoteImageFile(uri: thumbnail.contentUrl);
        }
    }
}
