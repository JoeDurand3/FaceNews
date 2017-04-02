using System;


namespace FaceNews.Core
{
	public class EmotionResponse
	{
		public Scores scores { get; set; } = new Scores();
		public EmotionResponse()
		{
		}
	}
}

