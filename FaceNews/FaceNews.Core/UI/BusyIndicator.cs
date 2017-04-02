using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CitizenApp.Core.Controls
{
    /// <summary>
    /// An animated MBS-centric loading symbol that looks pretty spiffy.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Image" />
    public class BusyIndicator : Image
	{
		const int time = 4000;
		const int spins = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusyIndicator"/> class.
        /// </summary>
        public BusyIndicator()
		{
			Source = "mbs_busy_indicator.png";
		}

		/// <summary>
		/// Starts the indicator.
		/// </summary>
		public async Task startIndicator()
		{
			await Task.Run(async () => await this.FadeTo(opacity: 1, easing: Easing.Linear));
			await this.RotateYTo(rotation: 360 * spins, length: time, easing: Easing.Linear);
			RotationY = 0;
		}

		/// <summary>
		/// Stops the indicator.
		/// </summary>
		public async Task stopIndicator()
		{
			await Task.Run(async () => await this.FadeTo(opacity: 0, easing: Easing.Linear));
			RotationY = 0;
		}
	}
}
