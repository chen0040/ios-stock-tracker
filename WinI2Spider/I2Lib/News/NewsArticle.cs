using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.News
{
    public class NewsArticle
    {
        private string mDateText;
        private string mTimeText;
        private string mCompany;
        private string mAnnTitle;
        private string mSiblings;
        private string mSNo;
        private string mKey;

        public string SNo
        {
            get { return mSNo; }
            set { mSNo = value; }
        }

        public string Key
        {
            get { return mKey; }
            set { mKey = value; }
        }

        public string Company
        {
            get { return mCompany; }
            set { mCompany = value; }
        }

        public string Title
        {
            get { return mAnnTitle; }
            set { mAnnTitle = value; }
        }

        public string Siblings
        {
            get { return mSiblings; }
            set { mSiblings = value; }
        }

        public NewsArticle()
        {

        }

        public DateTime UpdateTime
        {
            get
            {
                return DateTime.Parse(string.Format("{0} {1}", DateText, TimeText));
            }
        }

        public string DateText
        {
            get { return mDateText; }
            set { mDateText = value; }
        }

        public string TimeText
        {
            get { return mTimeText; }
            set { mTimeText = value; }
        }

    }
}
