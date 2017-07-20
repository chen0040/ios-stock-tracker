using System;
using System.Collections.Generic;
using System.Text;

namespace I2Lib.Util
{
    public class JsonParser
    {
        private string data;
        private string temp;
        private int _start;
        private int _end;
        private bool gotHeader;
        private List<JsonListener> _listeners=new List<JsonListener>();

        public static string trimQuotes(string text)
	    {
		    int len=text.Length;
		    if(len == 0) return "";
		    if(text[0]=='"' && text[len-1]=='"')
		    {
			    return text.Substring(1, len-2);
		    }
		    else if(text[0]=='"')
		    {
			    return text.Substring(1, len-1);
		    }
		    if(text[0]=='\'' && text[len-1]=='\'')
		    {
			    return text.Substring(1, len-2);
		    }
		    else if(text[0]=='\'')
		    {
			    return text.Substring(1, len-1);
		    }
		    return text.Substring(0, len);
	    }

		public JsonParser()
        {

        }

		public void parseString(string jsondata)
        {
            data = jsondata;
            _start = 0;
            parse();
        }

		public void addListener(JsonListener listener)
        {
            _listeners.Add(listener);
        }

		public void reset()
        {
            _start = 0;
	      data="";
	      temp="";
	      gotHeader = false;
        }



        
		private void parse()
        {
            while(_start < data.Length)
	          {
		        //Move through white space
		        char firstChar = data[_start];

		        while(firstChar < 33)
		          firstChar = data[++_start];

		        //Check the first character, if it is an [,],{ or } raise the approriate event

		        if(firstChar == '[')
		        {
		          foreach(JsonListener listener in _listeners)
                  {
			        listener.arrayStart();
                  }
                    _start++;
		          gotHeader = false;
		        }
		        else if(firstChar == ']')
		        {
		          foreach(JsonListener listener in _listeners)
                  {
                      listener.arrayEnd();
                  }
		          _start++;
		          gotHeader = false;
		        }
		        else if(firstChar == '{')
		        {
		          foreach(JsonListener listener in _listeners)
                  {
                      listener.objectStart();
                  }
		          _start++;
		          gotHeader = false;
		        }
		        else if(firstChar == '}')
		        {
		          foreach(JsonListener listener in _listeners)
                  {
                      listener.objectEnd();
                  }
		          _start++;
		          gotHeader = false;
		        }
		        else if(firstChar == ',')
		        {
		          _start++;
		          gotHeader = false;
		        }
		        else if(firstChar == ':')
		        {
		          _start++;
		          gotHeader = true;
		        }

		        else if(!gotHeader)
		        {
		          //read the header
                    temp = "";
		          _end = data.IndexOf(':', _start);

		          _end -= _start; //get the length
		          if(_end > 0)
		          {
			        temp = data.Substring(_start, _end);
			        _start += _end;
			        foreach(JsonListener listener in _listeners)
                    {
                        listener.header(temp);
                    }
		          }
		        }
		        else
		        {
		          //Processing data
		          if(firstChar == '\"')
		          {
			        //Processing a string
			        _end = findNextQuote(_start + 1) + 1;
			        _end -= _start;
			        if(_end > 150)
			          temp = data.Substring(_start + 1, 150); //don't take the leading quote, it won't have a pair
			        else
			        {
			          temp = data.Substring(_start, _end);
			        }
			        _start += _end;
			        foreach(JsonListener listener in _listeners)
                    {
                        listener.data(temp);
                    }
		          }
		          else
		          {
			        _end = nextDelimiter(_start);
			        _end -= _start;
			        temp = data.Substring(_start, _end);
			        _start += _end;
                    foreach (JsonListener listener in _listeners)
                    {
                        listener.data(temp);
                    }
		          }
		        }
	          }
        }

		private int findNextQuote(int startPos)
        {
            startPos = data.IndexOf('\"', startPos);
            if (data[startPos - 1] == '\\')
            {
                startPos = findNextQuote(startPos + 1); //Ignore any \" pairs in the string data
            }

            return startPos;
        }
		private int nextDelimiter(int startPos)
        {
            int nextComma = findPosition(',', startPos);
            int nextSquareBrace = findPosition(']', startPos);
            int nextCurlyBrace = findPosition('}', startPos);

            int lowest = nextComma < nextSquareBrace ? nextComma : nextSquareBrace;
            if (nextCurlyBrace < lowest)
            {
                lowest = nextCurlyBrace;
            }

            return lowest;
        }
		private int findPosition(char c, int startPos)
        {
            int cpos = data.IndexOf(c, startPos);
            if (cpos == -1)
                cpos = data.Length;

            return cpos;
        }
		
    }
}
