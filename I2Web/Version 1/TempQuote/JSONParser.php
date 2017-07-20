<?php
	class JSONListener
	{
		public function header($_header)
		{
			return false;
		}
		
		public function data($_value)
		{
			return false;
		}
		
		public function arrayStart()
		{
			return false;
		}
		
		public function arrayEnd()
		{
			return false;
		}
		
		public function objectStart()
		{
			return false;
		}
		
		public function objectEnd()
		{
			return false;
		}
	}
	
	class JSONParser
	{
		private $data;
		private $temp;
		private $_start;
		private $_end;
		private $_listeners;
		private $gotHeader;
		
		public function __construct()
		{
			$this->data='';
			$this->temp='';
			$this->_listeners=array();
			$this->gotHeader=false;
			$this->_start=0;
		}
		
		public function parseString($jsondata)
		{
			$this->data = $jsondata;
			$this->_start = 0;
			$this->parse();
		}

		public function reset()
		{
			$this->_start = 0;
			$this->data='';
			$this->temp='';
			$this->gotHeader = false;
		}
		
		private function parse()
		{
			$nonstop=true;
			while($this->_start < strlen($this->data) && $nonstop==true)
			{
				//Move through white space
				$firstChar = $this->data[$this->_start];

				while($firstChar == ' ' || $firstChar == '&')
				{
					$this->_start+=1;
					$firstChar = $this->data[$this->_start];
				}

				//Check the first character, if it is an [,],{ or } raise the approriate event

				if($firstChar == '[')
				{
					foreach($this->_listeners as $i => $listener)
					{
						$listener->arrayStart();
					}
					$this->_start++;
					$this->gotHeader = false;
				}
				else if($firstChar == ']')
				{
					foreach($this->_listeners as $i => $listener)
					{
						$listener->arrayEnd();
					}
					$this->_start++;
					$this->gotHeader = false;
				}
				else if($firstChar == '{')
				{
					foreach($this->_listeners as $i => $listener)
					{
						$listener->objectStart();
					}
					$this->_start++;
					$this->gotHeader = false;
				}
				else if($firstChar == '}')
				{
					foreach($this->_listeners as $i => $listener)
					{
						if($listener->objectEnd())
						{
							$nonstop=false;
						}
					}
					$this->_start++;
					$this->gotHeader = false;
				}
				else if($firstChar == ',')
				{
					$this->_start++;
					$this->gotHeader = false;
				}
				else if($firstChar == ':')
				{
					$this->_start++;
					$this->gotHeader = true;
				}
				else if($this->gotHeader==false)
				{
				  //read the header
				  $this->temp='';
				  $this->_end = strpos($this->data, ':', $this->_start);

				  $this->_end -= $this->_start; //get the length
				  if($this->_end > 0)
				  {
					$this->temp = substr($this->data, $this->_start, $this->_end);
					$this->_start += $this->_end;
					foreach($this->_listeners as $i => $listener)
					{
					  $listener->header($this->temp);
					}
				  }
				}
				else
				{
				  //Processing data
				  if($firstChar == '\"')
				  {
					//Processing a string
					$this->_end = $this->findNextQuote($this->_start + 1) + 1;
					$this->_end -= $this->_start;
					if($this->_end > 150)
					{
					  $this->temp = substr($this->data, $this->_start + 1, 150); //don't take the leading quote, it won't have a pair
					}
					else
					{
					  $this->temp = substr($this->data, $this->_start, $this->_end);
					}
					$this->_start += $this->_end;
					foreach($this->_listeners as $i => $listener)
					{
					  $listener->data($this->temp);
					}
				  }
				  else
				  {
					$this->_end = $this->nextDelimiter($this->_start);
					$this->_end -= $this->_start;
					$this->temp = substr($this->data, $this->_start, $this->_end);
					$this->_start += $this->_end;
					foreach($this->_listeners as $i => $listener)
					{
					  $listener->data($this->temp);
					}
				  }
				}
			}
			
		}
		
		private function findNextQuote($startPos)
		{
			$startPos = strpos($this->data, '\"', $startPos);
			if($this->data[startPos-1] == '\\')
			{
				$startPos = $this->findNextQuote($startPos + 1); //Ignore any \" pairs in the string data
			}

			return $startPos;
		}
		
		public function addListener($listener)
		{
			$this->_listeners[]=$listener;
		}
		
		private function nextDelimiter($startPos)
		{
			$nextComma = $this->findPosition(',', $startPos);
			$nextSquareBrace = $this->findPosition(']', $startPos);
			$nextCurlyBrace = $this->findPosition('}', $startPos);

			$lowest = $nextComma < $nextSquareBrace ? $nextComma : $nextSquareBrace;
			if($nextCurlyBrace < $lowest)
			{
				$lowest = $nextCurlyBrace;
			}

			return $lowest;
		}
		
		private function findPosition($c, $startPos)
		{
			$cpos = strpos($this->data, $c, $startPos);
			if($cpos == -1)
			{
				$cpos = strlen($this->data);
			}

			return $cpos;
		}
	};
?>