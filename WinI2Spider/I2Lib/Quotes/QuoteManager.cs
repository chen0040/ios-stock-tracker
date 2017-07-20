using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Quotes
{
    public class QuoteManager : Util.JsonListener
    {
        public enum Stage
        {
            sNone,
            sCode,
            sLastDone,
            sDayHigh,
            sDayLow,
            sBestBuy,
            sBestSell,
            sVol,
            sChg,
            sChgP,
            sBuyVol,
            sSellVol,
            sOpenValue,
            sCloseValue
        };

        private Stage mStage = Stage.sNone;
        private int objectCounter;
        private Dictionary<string, Quote> mQuotes = new Dictionary<string, Quote>();
        private Quote mCurrQuote = null;
        private List<QuoteManagerListener> mListeners = new List<QuoteManagerListener>();

        public QuoteManager()
        {
        }

        public void clear()
        {
            mQuotes.Clear();
        }

        public void addListener(QuoteManagerListener listener)
        {
            mListeners.Add(listener);
        }

        public void objectEnd()
        {
            objectCounter--;
            //if(objectCounter == 0)
            //locations.add(curLonLat);
        }

        public void objectStart()
        {
            objectCounter++;
        }

        public void header(string _header)
        {
            string trim_header = Util.JsonParser.trimQuotes(_header);

            if(trim_header == "N")
            {
                mStage=Stage.sCode;
            }
            else if (trim_header == "LT")
            {
                mStage = Stage.sLastDone;
            }
            else if (trim_header == "H")
            {
                mStage = Stage.sDayHigh;
            }
            else if (trim_header == "L")
            {
                mStage = Stage.sDayLow;
            }
            else if (trim_header == "B")
            {
                mStage = Stage.sBestBuy;
            }
            else if (trim_header == "S")
            {
                mStage = Stage.sBestSell;
            }
            else if (trim_header == "VL")
            {
                mStage = Stage.sVol;
            }
            else if (trim_header == "C")
            {
                mStage = Stage.sChg;
            }
            else if (trim_header == "P")
            {
                mStage = Stage.sChgP;
            }
            else if (trim_header == "BV")
            {
                mStage = Stage.sBuyVol;
            }
            else if (trim_header == "SV")
            {
                mStage = Stage.sSellVol;
            }
            else if (trim_header == "O")
            {
                mStage = Stage.sOpenValue;
            }
            else if (trim_header == "PV")
            {
                mStage = Stage.sCloseValue;
            }
            else
            {
                mStage = Stage.sNone;
            }
        }

        public Quote getQuote(string code)
        {
            if (mQuotes.ContainsKey(code))
            {
                return mQuotes[code];
            }
            return null;
        }

        public void data(string _data)
        {
            string trim_data = Util.JsonParser.trimQuotes(_data);
            if (mCurrQuote == null)
            {
                mCurrQuote = new Quote();
            }

            switch (mStage)
            {
                case Stage.sCode:
                    {
                        string ck = mCurrQuote.Code;
                        if (ck == "")
                        {
                            mCurrQuote.Code = trim_data;
                            mQuotes[trim_data] = mCurrQuote;
                        }
                        else if (ck != trim_data)
                        {
                            mCurrQuote = new Quote();
                            mCurrQuote.Code = trim_data;
                            mQuotes[trim_data] = mCurrQuote;
                        }
                    
                        break;
                    }
                case Stage.sLastDone:
                    {
                        mCurrQuote.LastDone = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sDayHigh:
                    {
                        mCurrQuote.DayHigh = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sDayLow:
                    {
                        mCurrQuote.DayLow = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sBestBuy:
                    {
                        mCurrQuote.BestBuy = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sBestSell:
                    {
                        mCurrQuote.BestSell = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sVol:
                    {
                        mCurrQuote.Vol = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sChg:
                    {
                        mCurrQuote.Chg = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sChgP:
                    {
                        mCurrQuote.ChgP = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sBuyVol:
                    {
                        mCurrQuote.BuyVol = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sSellVol:
                    {
                        mCurrQuote.SellVol = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sOpenValue:
                    {
                        mCurrQuote.OpenValue = Convert.ToDouble(trim_data);
                        break;
                    }
                case Stage.sCloseValue:
                    {
                        mCurrQuote.CloseValue = Convert.ToDouble(trim_data);
                        break;
                    }
            }


        }

        public Dictionary<string, Quote> Quotes
        {
            get
            {
                return mQuotes;
            }
        }

        public void arrayEnd()
        {

        }

        public void arrayStart()
        {
        }

        public void parseJson(string json)
        {
            clear();

            Util.JsonParser parser = new Util.JsonParser();
            parser.addListener(this);

            parser.parseString(json);

            if (mCurrQuote != null && mCurrQuote.Code != "")
            {
                mQuotes[mCurrQuote.Code] = mCurrQuote;
                mCurrQuote = new Quote();
            }

            foreach (QuoteManagerListener listener in mListeners)
            {
                listener.onParsed(this);
            }
        }
    }
}
