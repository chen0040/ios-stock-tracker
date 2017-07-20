using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Util
{
    public interface JsonListener
    {
        void header(string header);
		void data(string value);
		void arrayStart();
		void arrayEnd();
		void objectStart();
		void objectEnd();
    }
}
