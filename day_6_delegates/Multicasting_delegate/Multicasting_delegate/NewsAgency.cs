using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicasting_delegate
{
    class NewsAgency
    {
        public event Action<string> OnNewsPublished;

        public void Publish(string news)
        {
            if(OnNewsPublished != null)
            {
                OnNewsPublished(news);
            }
        }
    }
}
