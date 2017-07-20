<?php 
require_once("JSONParser.php");
require_once("QuoteInstance.php");

class QuoteManager extends JSONListener
{ 
	// singleton instance 
	private static $instance; 
	private $parser;
	private $mStage;
	private $breakpoint_reached;
	private $mTargetCodes;
	private $mTargetQuotes;
	private $mCurrentCode;

	// private constructor function 
	// to prevent external instantiation 
	private function __construct() 
	{ 
		$this->parser=new JSONParser();
		$this->parser->addListener($this);
		$this->mStage='sNone';
		$this->breakpoint_reached=false;
		$this->mTargetCodes=array();
		$this->mTargetQuotes=array();
		$this->mCurrentCode='';
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
				$this->mCurrentCode=$_value;
				$this->mTargetQuotes[$this->mCurrentCode]->setCode($_value);
			}
			else if($this->mStage=='sLastDone')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setLastDone((float)($_value));
			}
			else if($this->mStage=='sDayHigh')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setDayHigh((float)($_value));
			}
			else if($this->mStage=='sDayLow')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setDayLow((float)($_value));
			}
			else if($this->mStage=='sBestBuy')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setBestBuy((float)($_value));
			}
			else if($this->mStage=='sBestSell')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setBestSell((float)($_value));
			}
			else if($this->mStage=='sVol')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setVol((float)($_value)*1000);
			}
			else if($this->mStage=='sChg')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setChg((float)($_value));
			}
			else if($this->mStage=='sChgP')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setChgP((float)($_value)/100);
			}
			else if($this->mStage=='sBuyVol')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setBuyVol((float)($_value)*1000);
			}
			else if($this->mStage=='sSellVol')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setSellVol((float)($_value)*1000);
			}
			else if($this->mStage=='sOpenValue')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setOpenValue((float)($_value));
			}
			else if($this->mStage=='sCloseValue')
			{ 
				$this->mTargetQuotes[$this->mCurrentCode]->setCloseValue((float)($_value));
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
		$this->mTargetCodes[]=$targetCode;
		$this->mTargetQuotes[]=new QuoteInstance();
		$this->load($url);
		
		return $this->mTargetQuotes[$targetCode];
	}
	
	public function findArray($url, $targetCodes)
	{
		$this->mTargetCodes=$targetCodes;
		foreach($this->mTargetCodes as $val)
		{
			$this->mTargetQuotes[$val]=new QuoteInstance();
		}
		
		$this->load($url);
		
		return $this->mTargetQuotes;
	}
	
	public function clear()
	{
	
	}
} 
?>