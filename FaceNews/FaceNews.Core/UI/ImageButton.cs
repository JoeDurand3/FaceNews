using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FaceNews
{
    /// <summary>
    /// A control with an image and text.
    /// Animates when pressed.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.StackLayout" />
    class ImageButton : StackLayout
    {
        private Image _image = new Image();
    

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public ImageSource Source
        {
            set { _image.Source = "angry"; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageButton"/> class.
        /// </summary>
        public ImageButton()
        {

            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () => await AnimateSelf()),
            });
            this.Children.Add(_image);
            this.Scale = .95;
        }

        /// <summary>
        /// Animates the icon.
        /// </summary>
        /// <returns></returns>
        private async Task AnimateSelf()
        {
            ///TODO: Handle disabled animations on Android (otherwise crashes)
            const Int32 ScaleTime = 25;

            await this.ScaleTo(0.9, ScaleTime, Easing.Linear);
            await this.ScaleTo(.95, ScaleTime, Easing.Linear);
        }
    }
}
