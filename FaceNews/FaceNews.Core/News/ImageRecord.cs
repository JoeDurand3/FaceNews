using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using Xamarin.Forms;

namespace FaceNews.Core
{
    public class ImageRecord
    {
        public Thumbnail thumbnail { get; set; }
        public ImageSource imgdata { get; set; }

        public ImageRecord()
        {
			//downloadImg();
        }

        public void downloadImg()
        {
			var webImage = new Image { };
			webImage.Source = ImageSource.FromUri(new Uri(thumbnail.contentUrl));
			imgdata = webImage.Source;
			//imgdata = await ServiceHelper.DownloadRemoteImageFile(uri: thumbnail.contentUrl);
        }
    }
}
