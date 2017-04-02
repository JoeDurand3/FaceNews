using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FaceNews.Core.BusinessLogic
{
    class EmotionProcessingLogic
    {

        public static EmotionProcessingLogic Instance { get; } = new EmotionProcessingLogic();


        private EmotionProcessingLogic()
        {
            
        }
        
    }
}
