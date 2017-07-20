using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.News
{
    public interface NewsArticleManagerListener
    {
        void onParsed(NewsArticleManager mgr);
    }
}
