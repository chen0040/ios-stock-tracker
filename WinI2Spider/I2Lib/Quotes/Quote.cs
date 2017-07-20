using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Quotes
{
    public class Quote
    {
        public enum QuoteType
        {
            Warrants,
            Stocks,
            ETF,
            ES,
            ADR
        };

        private string mCode = "";
        private QuoteType mType = QuoteType.Stocks;
        private double mLastDone;
        private double mDayHigh;
        private double mDayLow;
        private double mBestBuy;
        private double mBestSell;
        private double mVol;
        private double mChg;
        private double mChgP;
        private double mBuyVol;
        private double mSellVol;
        private double mOpenValue;
        private double mCloseValue;
        private DateTime mUpdateTime;

        public Quote()
        {
            mUpdateTime = DateTime.Now;
        }

        public DateTime UpdateTime
        {
            get
            {
                return mUpdateTime;
            }
            set
            {
                mUpdateTime = value;
            }
        }

        public string Code
        {
            get { return mCode; }
            set { mCode = value; }
        }
        public QuoteType Type
        {
            get { return mType; }
            set { mType = value; }
        }
        public double LastDone
        {
            get { return mLastDone; }
            set { mLastDone = value; }
        }
        public double DayHigh
        {
            get { return mDayHigh; }
            set { mDayHigh = value; }
        }
        public double DayLow
        {
            get { return mDayLow; }
            set { mDayLow = value; }
        }
        public double BestBuy
        {
            get { return mBestBuy; }
            set { mBestBuy = value; }
        }
        public double BestSell
        {
            get { return mBestSell; }
            set { mBestSell = value; }
        }
        public double Vol
        {
            get { return mVol; }
            set { mVol = value; }
        }
        public double Chg
        {
            get { return mChg; }
            set { mChg = value; }
        }
        public double ChgP
        {
            get { return mChgP; }
            set { mChgP = value; }
        }
        public double BuyVol
        {
            get { return mBuyVol; }
            set { mBuyVol = value; }
        }
        public double SellVol
        {
            get { return mSellVol; }
            set { mSellVol = value; }
        }
        public double OpenValue
        {
            get { return mOpenValue; }
            set { mOpenValue = value; }
        }
        public double CloseValue
        {
            get { return mCloseValue; }
            set { mCloseValue = value; }
        }
    }
}
