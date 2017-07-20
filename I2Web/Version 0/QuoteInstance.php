<?php	
	class QuoteInstance
	{
		private $mCode;
		private $mType;
		private $mLastDone;
		private $mDayHigh;
		private $mDayLow;
		private $mBestBuy;
		private $mBestSell;
		private $mVol;
		private $mChg;
		private $mChgP;
		private $mBuyVol;
		private $mSellVol;
		private $mOpenValue;
		private $mCloseValue;
		
		public function __construct()
		{
			$this->mCode='';
			$this->mType='QuoteTypeStock';
			$this->mLastDone=0;
			$this->mDayHigh=0;
			$this->mDayLow=0;
			$this->mBestBuy=0;
			$this->mBestSell=0;
			$this->mVol=0;
			$this->mChg=0;
			$this->mChgP=0;
			$this->mBuyVol=0;
			$this->mSellVol=0;
			$this->mOpenValue=0;
			$this->mCloseValue=0;
		}
		
		public function getCode()  { return $this->mCode; }
		public function getType()  { return $this->mType; }
		public function getLastDone()  { return $this->mLastDone; }
		public function getDayHigh()  { return $this->mDayHigh; }
		public function getDayLow()  { return $this->mDayLow; }
		public function getBestBuy()  { return $this->mBestBuy; }
		public function getBestSell()  { return $this->mBestSell; }
		public function getVol()  { return $this->mVol; }
		public function getChg()  { return $this->mChg; }
		public function getChgP()  { return $this->mChgP; }
		public function getBuyVol()  { return $this->mBuyVol; }
		public function getSellVol()  { return $this->mSellVol; }
		public function getOpenValue()  { return $this->mOpenValue; }
		public function getCloseValue()  { return $this->mCloseValue; }

		public function setCode($code)
		{
			$this->mCode=$code;
			if(strpos($code, 'W1', 0) != -1)
			{
				$this->mType='QuoteTypeWarrant';
			}
			else
			{
				$this->mType='QuoteTypeStock';
			}
		}
		public function setType($val) {$this->mType=$val; }
		public function setLastDone($val) {$this->mLastDone=$val; }
		public function setDayHigh($val) {$this->mDayHigh=$val; }
		public function setDayLow($val) {$this->mDayLow=$val; }
		public function setBestBuy($val) {$this->mBestBuy=$val; }
		public function setBestSell($val) {$this->mBestSell=$val; }
		public function setVol($val) {$this->mVol=$val; }
		public function setChg($val) {$this->mChg=$val; }
		public function setChgP($val) {$this->mChgP=$val; }
		public function setBuyVol($val) {$this->mBuyVol=$val; }
		public function setSellVol($val) {$this->mSellVol=$val; }
		public function setOpenValue($val) {$this->mOpenValue=$val; }
		public function setCloseValue($val) {$this->mCloseValue=$val; }
		
		public function toString()
		{
			$content='';
			$content.=("Code: " . $this->getCode() . "<br />"."\n");
			$content.=("Type: " . $this->getType() . "<br />"."\n");
			$content.=("LastDone: " . $this->getLastDone() . "<br />"."\n");
			$content.=("DayHigh: " . $this->getDayHigh() . "<br />"."\n");
			$content.=("DayLow: " . $this->getDayLow() . "<br />"."\n");
			$content.=("BestBuy: " . $this->getBestBuy() . "<br />"."\n");
			$content.=("BestSell: " . $this->getBestSell() . "<br />"."\n");
			$content.=("Vol: " . $this->getVol() . "<br />"."\n");
			$content.=("Chg: " . $this->getChg() . "<br />"."\n");
			$content.=("ChgP: " . $this->getChgP() . "<br />"."\n");
			$content.=("BuyVol: " . $this->getBuyVol() . "<br />"."\n");
			$content.=("SellVol: " . $this->getSellVol() . "<br />"."\n");
			$content.=("OpenValue: " . $this->getOpenValue() . "<br />"."\n");
			$content.=("CloseValue: " . $this->getCloseValue() . "<br />"."\n");
			
			return $content;
		}
		
		public function toJSON()
		{
			$content="{";
			$content.=("\"Code\": \"" . $this->getCode() . "\", ");
			$content.=("\"Type\": \"" . $this->getType() . "\", ");
			$content.=("\"LastDone\": \"" . $this->getLastDone() . "\", ");
			$content.=("\"DayHigh\": \"" . $this->getDayHigh() . "\", ");
			$content.=("\"DayLow\": \"" . $this->getDayLow() . "\", ");
			$content.=("\"BestBuy\": \"" . $this->getBestBuy() . "\", ");
			$content.=("\"BestSell\": \"" . $this->getBestSell() . "\", ");
			$content.=("\"Vol\": \"" . $this->getVol() . "\", ");
			$content.=("\"Chg\": \"" . $this->getChg() . "\", ");
			$content.=("\"ChgP\": \"" . $this->getChgP() . "\", ");
			$content.=("\"BuyVol\": \"" . $this->getBuyVol() . "\", ");
			$content.=("\"SellVol\": \"" . $this->getSellVol() . "\", ");
			$content.=("\"OpenValue\": \"" . $this->getOpenValue() . "\", ");
			$content.=("\"CloseValue\": \"" . $this->getCloseValue() . "\"");
			$content.="}";
			
			return $content;
		}
	}
?>