using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FaceNews.Core
{
    public class Article
    {
        static int nextId = 0;

        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public ImageRecord image { get; set; }
        public string description { get; set; }
        public DateTime datePublished { get; set; }
        public double sentiment { get; set; }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public ImageSource Image
        {
            get
            {
                return image.imgdata;
            }
        }

        public Article()
        {
            id = nextId++;
        }

    }
}
