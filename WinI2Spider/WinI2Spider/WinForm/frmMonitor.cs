using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using I2Lib.Quotes;
using I2Lib.News;
using I2Lib.Util;

namespace WinI2Spider.WinForm
{
    public partial class frmMonitor : Form, QuoteManagerListener, NewsArticleManagerListener
    {
        private QuoteManager mStockQuoteManager = new QuoteManager();
        private QuoteManager mWarrantQuoteManager = new QuoteManager();
        private NewsArticleManager mNewsManager = new NewsArticleManager();
        private bool mTaskDone = false;

        public frmMonitor()
        {
            mStockQuoteManager.addListener(this);
            mWarrantQuoteManager.addListener(this);
            mNewsManager.addListener(this);
            InitializeComponent();
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {
            mTaskDone = true;
            tmrMonitor.Interval = int.Parse(txtMonitorInterval.Text);
            tmrMonitor.Enabled = true;
            btnMonitor.Enabled = false;
            btnStopMonitor.Enabled = true;
        }

        public void onParsed(QuoteManager mgr)
        {
            if (mgr == mStockQuoteManager)
            {
                txtCrawledStockQuoteCount.Text = string.Format("{0}", mgr.Quotes.Count);
            }
            else
            {
                txtCrawledWarrantQuoteCount.Text = string.Format("{0}", mgr.Quotes.Count);
            }
        }

        public void onParsed(NewsArticleManager mgr)
        {
            txtCrawledNewsCount.Text=string.Format("{0}", mgr.NewsArticles.Count);
            dtpUpdateDate.Value = DateTime.Now;
            dtpUpdateTime.Value = DateTime.Now;
        }

        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            if (mTaskDone==false)
            {
                return;
            }
            DateTime start = DateTime.Now;

            mTaskDone = false;
            //http://www.sgx.com/JsonRead/JsonData?qryId=Stock&timeout=30
            string json =DownloadUtil.Instance.HttpStringGet("http://www.sgx.com/JsonRead/JsonData?qryId=Stock&timeout=30");
            mStockQuoteManager.parseJson(json);

            json =DownloadUtil.Instance.HttpStringGet("http://www.sgx.com/JsonRead/JsonData?qryId=Warrant&timeout=30");
            mWarrantQuoteManager.parseJson(json);

            //http://info.sgx.com/webcorannc.nsf/AnnouncementToday?openview&count=800
            json =DownloadUtil.Instance.HttpStringGet("http://info.sgx.com/webcorannc.nsf/AnnouncementToday?openview");
            mNewsManager.parseJson(json);

            Dictionary<string, Quote> stocks = mStockQuoteManager.Quotes;
            Dictionary<string, Quote> warrants = mWarrantQuoteManager.Quotes;
            List<NewsArticle> articles = mNewsManager.NewsArticles;

            txtHttpStats.Text = "";

            int unit_size = int.Parse(txtPacketSize.Text);
            Queue<List<Quote>> quote_queue = new Queue<List<Quote>>();
            List<Quote> quote_unit = new List<Quote>();
            foreach (string aKey in stocks.Keys)
            {
                if (quote_unit.Count == unit_size)
                {
                    quote_queue.Enqueue(quote_unit);
                    quote_unit = new List<Quote>();
                }
                stocks[aKey].Type = Quote.QuoteType.Stocks;
                quote_unit.Add(stocks[aKey]);
            }

            foreach (string aKey in warrants.Keys)
            {
                if (quote_unit.Count == unit_size)
                {
                    quote_queue.Enqueue(quote_unit);
                    quote_unit = new List<Quote>();
                }
                warrants[aKey].Type = Quote.QuoteType.Warrants;
                quote_unit.Add(warrants[aKey]);
            }

            if (quote_unit.Count != 0)
            {
                quote_queue.Enqueue(quote_unit);
            }

            bool first_entry = true;
            while (quote_queue.Count != 0)
            {
                quote_unit = quote_queue.Dequeue();
                StringBuilder sb=new StringBuilder();
                if (first_entry)
                {
                    sb.Append("cls=1");
                    first_entry = false;
                }
                else
                {
                    sb.Append("cls=0");
                }
                foreach (Quote quote in quote_unit)
                {
                    sb.AppendFormat("&code[]={0}", DownloadUtil.UrlEncode(quote.Code));
                    if (quote.Type == Quote.QuoteType.Stocks)
                    {
                        sb.Append("&type[]=Stocks");
                    }
                    else if (quote.Type == Quote.QuoteType.Warrants)
                    {
                        sb.Append("&type[]=Warrants");
                    }
                    sb.AppendFormat("&lastdone[]={0}", DownloadUtil.UrlEncode(quote.LastDone));
                    sb.AppendFormat("&dayhigh[]={0}", DownloadUtil.UrlEncode(quote.DayHigh));
                    sb.AppendFormat("&daylow[]={0}", DownloadUtil.UrlEncode(quote.DayLow));
                    sb.AppendFormat("&bestbuy[]={0}", DownloadUtil.UrlEncode(quote.BestBuy));
                    sb.AppendFormat("&bestsell[]={0}", DownloadUtil.UrlEncode(quote.BestSell));
                    sb.AppendFormat("&vol[]={0}", DownloadUtil.UrlEncode(quote.Vol));
                    sb.AppendFormat("&chg[]={0}", DownloadUtil.UrlEncode(quote.Chg));
                    sb.AppendFormat("&chgp[]={0}", DownloadUtil.UrlEncode(quote.ChgP));
                    sb.AppendFormat("&buyvol[]={0}", DownloadUtil.UrlEncode(quote.BuyVol));
                    sb.AppendFormat("&sellvol[]={0}", DownloadUtil.UrlEncode(quote.SellVol));
                    sb.AppendFormat("&openvalue[]={0}", DownloadUtil.UrlEncode(quote.OpenValue));
                    sb.AppendFormat("&closevalue[]={0}", DownloadUtil.UrlEncode(quote.CloseValue));
                    sb.AppendFormat("&updatetime[]={0}", DownloadUtil.UrlEncode(quote.UpdateTime));
                }
                txtHttpStats.Text += DateTime.Now.ToShortTimeString();
                txtHttpStats.Text += ":\t";
                txtHttpStats.Text +=DownloadUtil.Instance.HttpPost("http://myi2web/quote/update_price.php", sb.ToString());
                txtHttpStats.Text += "\r\n";
            }

            Queue<List<NewsArticle>> news_queue = new Queue<List<NewsArticle>>();
            List<NewsArticle> news_unit = new List<NewsArticle>();
            foreach (NewsArticle article in articles)
            {
                if (news_unit.Count == unit_size)
                {
                    news_queue.Enqueue(news_unit);
                    news_unit = new List<NewsArticle>();
                }
                news_unit.Add(article);
            }

            if (news_unit.Count != 0)
            {
                news_queue.Enqueue(news_unit);
            }

            first_entry = true;
            while (news_queue.Count != 0)
            {
                news_unit = news_queue.Dequeue();
                StringBuilder sb = new StringBuilder();
                if (first_entry)
                {
                    sb.Append("cls=1");
                    first_entry = false;
                }
                else
                {
                    sb.Append("cls=0");
                }
                foreach (NewsArticle article in news_unit)
                {
                    sb.AppendFormat("&newsdate[]={0}", DownloadUtil.UrlEncode(article.DateText));
                    sb.AppendFormat("&newstime[]={0}", DownloadUtil.UrlEncode(article.TimeText));
                    sb.AppendFormat("&newscomp[]={0}", DownloadUtil.UrlEncode(article.Company));
                    sb.AppendFormat("&newstitle[]={0}", DownloadUtil.UrlEncode(article.Title));
                    sb.AppendFormat("&newsiblings[]={0}", DownloadUtil.UrlEncode(article.Siblings));
                    sb.AppendFormat("&newsno[]={0}", DownloadUtil.UrlEncode(article.SNo));
                    sb.AppendFormat("&newskey[]={0}", DownloadUtil.UrlEncode(article.Key));
                    
                }
                txtHttpStats.Text+= DateTime.Now.ToShortTimeString();
                txtHttpStats.Text += ":\t";
                txtHttpStats.Text +=DownloadUtil.Instance.HttpPost("http://myi2web/quote/update_news.php", sb.ToString());
                txtHttpStats.Text += "\r\n";
            }

            

            

            DateTime end = DateTime.Now;
            TimeSpan ts = end - start;

            txtUpdateDuration.Text =string.Format("{0}", ts.Milliseconds);

            mTaskDone = true;
        }

        private void btnStopMonitor_Click(object sender, EventArgs e)
        {
            tmrMonitor.Enabled = false;
            btnMonitor.Enabled = true;
            btnStopMonitor.Enabled = false;
        }
    }
}
