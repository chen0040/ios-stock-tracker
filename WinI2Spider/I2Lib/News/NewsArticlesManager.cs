using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.News
{
    //http://info.sgx.com/webcorannc.nsf/AnnouncementToday/4825735e007d263a482574b30032747d?OpenDocument
    //http://info.sgx.com/webcorannc.nsf/vwprint_portal/4825735E007D263A482574B30032747D?OpenDocument
    public class NewsArticleManager : Util.JsonListener
    {
        public enum Stage
        {
            sNone,
            sDate,
            sTime,
            sCompany,
            sAnnTitle,
            sSiblings,
            sSNo,
            sKey
        };

        Stage mStage=Stage.sNone;
        int objectCounter=0;
        List<NewsArticle> mNewsArticles=new List<NewsArticle>();
        List<NewsArticleManagerListener> mListeners = new List<NewsArticleManagerListener>();
        NewsArticle mCurrNewsArticle=null;

        public List<NewsArticle> NewsArticles
        {
            get
            {
                return mNewsArticles;
            }

        }

        public void addListener(NewsArticleManagerListener listener)
        {
            mListeners.Add(listener);
        }

        public NewsArticleManager()
        {

        }

        //JSON
        public void header(string _header)
        {
            string hheader=Util.JsonParser.trimQuotes(_header);
		    if(hheader == "Date")
		    {
			    mStage = Stage.sDate;
		    }
		    else if(hheader == "Time")
		    {
			    mStage = Stage.sTime;
		    }
		    else if(hheader == "Company")
		    {
			    mStage = Stage.sCompany;
		    }
		    else if(hheader == "AnnTitle")
		    {
			    mStage=Stage.sAnnTitle;
		    }
		    else if(hheader == "Siblings")
		    {
			    mStage=Stage.sSiblings;
		    }
		    else if(hheader == "SNo")
		    {
			    mStage =Stage.sSNo;
		    }
		    else if(hheader == "key")
		    {
			    mStage=Stage.sKey;
		    }
		    else
		    {
			    mStage = Stage.sNone;
		    }
        }
        public void data(string _data)
        {
            string ddata=Util.JsonParser.trimQuotes(_data);
		    if(mCurrNewsArticle == null)
		    {
			    mCurrNewsArticle=new NewsArticle();
		    }

		    switch(mStage)
		    {
		    case Stage.sDate:
		      mCurrNewsArticle.DateText=ddata;
		      break;
          case Stage.sTime:
		      mCurrNewsArticle.TimeText=ddata;
		      break;
          case Stage.sCompany:
		      mCurrNewsArticle.Company=ddata;
		      break;
          case Stage.sAnnTitle:
			    mCurrNewsArticle.Title=ddata;
			    break;
            case Stage.sSiblings:
		    {
			    mCurrNewsArticle.Siblings=ddata;
			    break;
		    }
        case Stage.sSNo:
		    {
			    mCurrNewsArticle.SNo=ddata;
			    break;
		    }
        case Stage.sKey:
		    {
                string ck = mCurrNewsArticle.Key;
                if (ck == "")
                {
                    mCurrNewsArticle.Key = ddata;
                    mNewsArticles.Add(mCurrNewsArticle);
                }
                else if (ck != ddata)
                {
                    mCurrNewsArticle = new NewsArticle();
                    mCurrNewsArticle.Key = ddata;
                    mNewsArticles.Add(mCurrNewsArticle);
                }

			    break;
		    }
		    }
        }
        public void arrayStart()
        {
        }
        public void arrayEnd()
        {
        }
        public void objectStart()
        {
            objectCounter++;
        }
        public void objectEnd()
        {
            objectCounter--;
        }

        public void parseJson(string json)
        {
            mNewsArticles.Clear();

            Util.JsonParser parser = new Util.JsonParser();
            parser.addListener(this);

            parser.parseString(json);

            if (mCurrNewsArticle != null && mCurrNewsArticle.Title != "")
            {
                mNewsArticles.Add( mCurrNewsArticle);
                mCurrNewsArticle = new NewsArticle();
            }

            foreach (NewsArticleManagerListener listener in mListeners)
            {
                listener.onParsed(this);
            }
        }
    }
}
