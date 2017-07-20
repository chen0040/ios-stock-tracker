<?php
require_once("MySQLHandler.php");

function quote_prices_clear_table()
{
	
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	$query="DELETE FROM quote_prices";
	mysql_query($query) or die(mysql_error());
	
	$handler->disconnect();
	
	
}

function quote_prices_count($quotetype)
{
	$count=0;
	
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	if(strcmp($quotetype, 'All')==0)
	{
		$query="SELECT COUNT(*) FROM quote_prices";
	}
	else
	{
		$query="SELECT COUNT(*) FROM quote_prices WHERE quotetype='".$quotetype."'";
	}
	$result=mysql_query($query) or die(mysql_error());
	$row = mysql_fetch_array($result);
	$count=intval($row[0]);
	$handler->disconnect();
	
	return $count;
}

function quote_prices_create_table_if_not_exists()
{
	$handler=new MySQLHandler();

	if(!$handler->table_exists("quote_prices"))
	{
		$fields=array();
		$primary_key="quoteid";
		$fields['quoteid']='INT NOT NULL AUTO_INCREMENT';
		$fields['quotecode']='VARCHAR(255)';
		$fields['quotetype']='VARCHAR(255)';
		$fields['lastdone']='VARCHAR(255)';
		$fields['dayhigh']='FLOAT';
		$fields['daylow']='FLOAT';
		$fields['bestbuy']='FLOAT';
		$fields['bestsell']='FLOAT';
		$fields['vol']='FLOAT';
		$fields['chg']='FLOAT';
		$fields['chgp']='FLOAT';
		$fields['buyvol']='FLOAT';
		$fields['sellvol']='FLOAT';
		$fields['openvalue']='FLOAT';
		$fields['closevalue']='FLOAT';
		$fields['updatetime']='VARCHAR(255)';

		$handler->create_table("quote_prices", $fields, $primary_key);
	}
}

function quote_prices_insert_into_table($code, $type, $lastdone, $dayhigh, $daylow, $bestbuy, $bestsell, $vol, $chg, $chgp, $buyvol, $sellvol, $openvalue, $closevalue, $updatetime)
{
	$handler=new MySQLHandler();
	$keys=array("quotecode", "quotetype", "lastdone", "dayhigh", "daylow", "bestbuy", "bestsell", "vol", "chg", "chgp", "buyvol", "sellvol", "openvalue", "closevalue", "updatetime");
	$values=array($code, $type, $lastdone, $dayhigh, $daylow, $bestbuy, $bestsell, $vol, $chg, $chgp, $buyvol, $sellvol, $openvalue, $closevalue, $updatetime);
	$handler->insert_into_table("quote_prices", $keys, $values);
}

function quote_prices_create_html_table()
{
	$handler=new MySQLHandler();
	$keys=array("quotecode", "quotetype", "lastdone", "dayhigh", "daylow", "bestbuy", "bestsell", "vol", "chg", "chgp", "buyvol", "sellvol", "openvalue", "closevalue", "updatetime");
	$criteria="";
	$display_fields=array("quotecode", "quotetype", "lastdone", "dayhigh", "daylow", "bestbuy", "bestsell", "vol", "chg", "chgp", "buyvol", "sellvol", "openvalue", "closevalue", "updatetime");
	$display_style="";
	echo $handler->create_html_table("quote_prices", $keys, $criteria, $display_fields, $display_style);
}

function quote_prices_create_json($start_row_index, $row_count, $quotetype)
{
	$total_count=quote_prices_count($quotetype);
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	$keys=array("quotecode", "quotetype", "lastdone", "dayhigh", "daylow", "bestbuy", "bestsell", "vol", "chg", "chgp", "buyvol", "sellvol", "openvalue", "closevalue", "updatetime");
	
	$criteria="LIMIT ".$start_row_index.", ".$row_count;
	if(strcmp($quotetype, "All") !=0)
	{
		$criteria="WHERE quotetype='".mysql_real_escape_string($quotetype)."' ".$criteria;
	}
	
	echo '{';
	echo '"PageCount":"'.ceil(floatval($total_count) / floatval($row_count)).'",';
	echo '"PageIndex":"'.floor(floatval($start_row_index) / floatval($row_count)).'",';
	echo '"PageSize":"'.$row_count.'",';
	echo '"Codes":[';

	$data=$handler->naked_select_from_table("quote_prices", $keys, $criteria);
	
	$counter=0;
	while($row = mysql_fetch_array($data))
	{
		if($counter!=0)
		{
			echo ',';
		}
		$counter+=1;
		
		$code=mysql_real_escape_string($row["quotecode"]);
		$type=mysql_real_escape_string($row["quotetype"]);
		$lastdone=mysql_real_escape_string($row["lastdone"]);
		$dayhigh=mysql_real_escape_string($row["dayhigh"]);
		$daylow=mysql_real_escape_string($row["daylow"]);
		$bestbuy=mysql_real_escape_string($row["bestbuy"]);
		$bestsell=mysql_real_escape_string($row["bestsell"]);
		$vol=mysql_real_escape_string($row["vol"]);
		$chg=mysql_real_escape_string($row["chg"]);
		$chgp=mysql_real_escape_string($row["chgp"]);
		$buyvol=mysql_real_escape_string($row["buyvol"]);
		$sellvol=mysql_real_escape_string($row["sellvol"]);
		$openvalue=mysql_real_escape_string($row["openvalue"]);
		$closevalue=mysql_real_escape_string($row["closevalue"]);
		$updatetime=mysql_real_escape_string($row["updatetime"]);
			
		echo '{"Code": "'.$code.'", "Type": "'.$type.'", "LastDone": "'.$lastdone.'", "DayHigh": "'.$dayhigh.'", "DayLow": "'.$daylow.'", "BestBuy": "'.$bestbuy.'", "BestSell": "'.$bestsell.'", "Vol": "'.$vol.'", "Chg": "'.$chg.'", "ChgP": "'.$chgp.'", "BuyVol": "'.$buyvol.'", "SellVol": "'.$sellvol.'", "OpenValue": "'.$openvalue.'", "CloseValue": "'.$closevalue.'"}';
	}

	$handler->disconnect();
	
	echo ']';
	echo '}';
}
?>