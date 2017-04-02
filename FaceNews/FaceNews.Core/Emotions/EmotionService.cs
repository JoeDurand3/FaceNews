using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FaceNews.Core
{

	static class EmotionService
	{
		public static async Task<EmotionResponse> getEmotion(byte[] dataInput)
		{
			return await EmotionServiceHelper.SendAync(HttpMethod.Post, service: "", methodName: "", content: dataInput);
		}
	}
}
