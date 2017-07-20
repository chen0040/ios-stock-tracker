<?php 
require_once("JSONParser.php");
require_once("QuoteInstance.php");

class QuoteManager extends JSONListener
{ 
	// singleton instance 
	private static $instance; 
	private $parser;
	private $mQuotes;
	private $mStage;
	private $breakpoint_reached;
	private $mTargetCode;
	private $mTargetQuote;

	// private constructor function 
	// to prevent external instantiation 
	private function __construct() 
	{ 
		$this->parser=new JSONParser();
		$this->parser->addListener($this);
		$this->mQuotes=array();
		$this->mStage='sNone';
		$this->breakpoint_reached=false;
		$this->mTargetCode='';
		$this->mTargetQuote=new QuoteInstance();
	}

	// getInstance method 
	public static function getInstance() 
	{ 
		if(!self::$instance) 
		{ 
		  self::$instance = new self(); 
		} 

		return self::$instance; 
	}

	public function header($_header)
	{
		$header_content=$this->trimQuotes($_header);
		//echo $header_content . "<br />";

		if($header_content == "N")
		{
			$this->mStage='sCode';
		}
		else if($header_content == "LT") 
		{
			$this->mStage = 'sLastDone';
		}
		else if($header_content == "H") 
		{
			$this->mStage = 'sDayHigh';
		}
		else if($header_content == "L") 
		{
			$this->mStage = 'sDayLow';
		}
		else if($header_content == "B") 
		{
			$this->mStage='sBestBuy';
		}
		else if($header_content == "S") 
		{
			$this->mStage='sBestSell';
		}
		else if($header_content == "VL") 
		{
			$this->mStage ='sVol';
		}
		else if($header_content == "C") 
		{
			$this->mStage='sChg';
		}
		else if($header_content == "P") 
		{
			$this->mStage='sChgP';
		}
		else if($header_content == "BV") 
		{
			$this->mStage='sBuyVol';
		}
		else if($header_content == "SV") 
		{
			$this->mStage='sSellVol';
		}
		else if($header_content == "O") 
		{
			$this->mStage='sOpenValue';
		}
		else if($header_content == "PV") 
		{
			$this->mStage='sCloseValue';
		}
		else
		{
			$this->mStage = 'sNone';
		}
		
		
		return false;
		
	}

	public function data($_value)
	{
		$_value=$this->trimQuotes($_value);
		if($_value==$this->mTargetCode && $this->mStage=='sCode')
		{
			$this->breakpoint_reached=true;
		}
		if($this->breakpoint_reached==true)
		{
			if($this->mStage=='sCode')
			{
				$this->mTargetQuote->setCode($_value);
			}
			else if($this->mStage=='sLastDone')
			{ 
				$this->mTargetQuote->setLastDone((float)($_value));
			}
			else if($this->mStage=='sDayHigh')
			{ 
				$this->mTargetQuote->setDayHigh((float)($_value));
			}
			else if($this->mStage=='sDayLow')
			{ 
				$this->mTargetQuote->setDayLow((float)($_value));
			}
			else if($this->mStage=='sBestBuy')
			{ 
				$this->mTargetQuote->setBestBuy((float)($_value));
			}
			else if($this->mStage=='sBestSell')
			{ 
				$this->mTargetQuote->setBestSell((float)($_value));
			}
			else if($this->mStage=='sVol')
			{ 
				$this->mTargetQuote->setVol((float)($_value));
			}
			else if($this->mStage=='sChg')
			{ 
				$this->mTargetQuote->setChg((float)($_value));
			}
			else if($this->mStage=='sChgP')
			{ 
				$this->mTargetQuote->setChgP((float)($_value));
			}
			else if($this->mStage=='sBuyVol')
			{ 
				$this->mTargetQuote->setBuyVol((float)($_value));
			}
			else if($this->mStage=='sSellVol')
			{ 
				$this->mTargetQuote->setSellVol((float)($_value));
			}
			else if($this->mStage=='sOpenValue')
			{ 
				$this->mTargetQuote->setOpenValue((float)($_value));
			}
			else if($this->mStage=='sCloseValue')
			{ 
				$this->mTargetQuote->setCloseValue((float)($_value));
			}
		}
		return false;
	}
	
	public function trimQuotes($text)
	{
		$len=strlen($text);
		if($len == 0) return "";
		if($text[0]=='"' && $text[$$len-1]=='"')
		{
			return substr($text, 1, $len-2);
		}
		else if($text[0]=='"')
		{
			return substr($text, 1, $len-1);
		}
		if($text[0]=='\'' && $text[$len-1]=='\'')
		{
			return substr($text, 1, $len-2);
		}
		else if($text[0]=='\'')
		{
			return substr($text, 1, $len-1);
		}
		return substr($text, 0, $len);
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
		if($this->breakpoint_reached==true)
		{
			return true;
		}
		return false;
	}
	
	public function load($url)
	{
		$this->breakpoint_reached=false;
		
		/*
		$content = '';
		if ($fp = fopen($url, 'r'))
		{
			// keep reading until there's nothing left 
			while ($line = fread($fp, 1024)) 
			{
			  $content .= $line;
			}

			//$content=str_replace("{}&&", "", $content);
			//echo $content;
			$this->parser->parseString($content);
			
		}
		*/
		
		/*
		$content=file_get_contents($url);
		$this->parser->parseString($content);
		*/
		
		
		$ch = curl_init($url);
		$fp = @fopen("temp.txt", "w");
		curl_setopt($ch, CURLOPT_FILE, $fp);
		curl_setopt($ch, CURLOPT_HEADER, 0);
		curl_exec($ch);
		curl_close($ch);
		fclose($fp);
		$file = "temp.txt";
		if ($fp = fopen($file, 'r'))
		{
			// keep reading until there's nothing left 
			while ($line = fread($fp, 1024)) 
			{
			  $content .= $line;
			}

			//$content=str_replace("{}&&", "", $content);
			//echo $content;
			$this->parser->parseString($content);
			
		}
		
	}
	
	public function find($url, $targetCode)
	{
		$this->mTargetCode=$targetCode;
		$this->load($url);
		return $this->getTargetQuote();
	}
	
	public function clear()
	{
		unset($this->mQuotes);
		$this->mQuotes=array();
	}
	
	public function getTargetQuote()
	{
		return $this->mTargetQuote;
	}
} 
?>