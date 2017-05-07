using System;


namespace FaceNews.Core
{
	public class Scores
	{
		public double anger { get; set; } = 0;
		public double contempt { get; set; } = 0;
		public double disgust { get; set; } = 0;
		public double fear { get; set; } = 0;
		public double happiness { get; set; } = 0;
		public double neutral { get; set; } = 0;
		public double sadness { get; set; } = 0;
		public double surprise { get; set; } = 0;

        public override string ToString()
        {
            return "Anger: " + (int)(anger * 100) +
                "\nContempt: " + (int)(contempt * 100) +
                "\nDisgust: " + (int)(disgust * 100) +
                "\nFear: " + (int)(fear * 100) +
                "\nHappiness: " + (int)(happiness * 100) +
                "\nNeutral: " + (int)(neutral * 100) +
                "\nSadness: " + (int)(sadness * 100) +
                "\nSurprise: " + (int)(surprise * 100);
        }
    }
}

