using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Quotes
{
    public class QuoteDbManager
    {
        private static QuoteDbManager mInstance = null;
        private static object mLocker = new object();
        public static QuoteDbManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new QuoteDbManager();
                    }
                }
            }
        }

        private QuoteDbManager()
        {
        }


    }
}
