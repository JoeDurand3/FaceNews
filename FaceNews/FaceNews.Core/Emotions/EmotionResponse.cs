using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
   public class EmotionResponse
    {
        public Scores scores { get; set; }

        public override string ToString()
        {
            return scores.ToString();
        }
    }
}
