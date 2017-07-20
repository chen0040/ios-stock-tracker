using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Quotes
{
    public interface QuoteManagerListener
    {
        void onParsed(QuoteManager mgr);
    }
}
