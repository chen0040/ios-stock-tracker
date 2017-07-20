<?php
require_once("MySQLHandler.php");

function quote_news_clear_table()
{
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	$query="DELETE FROM quote_news";
	mysql_query($query) or die(mysql_error());
	$handler->disconnect();
}

function quote_news_count($newscomp)
{
	$count=0;
	
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	if(strcmp($newscomp, 'All')==0)
	{
		$query="SELECT COUNT(*) FROM quote_news";
	}
	else
	{
		$query="SELECT COUNT(*) FROM quote_news WHERE newscomp='".$newscomp."'";
	}
	
	$result=mysql_query($query) or die(mysql_error());
	$row = mysql_fetch_array($result);
	$count=intval($row[0]);
	$handler->disconnect();
	
	return $count;
}

function quote_news_create_table_if_not_exists()
{
	$handler=new MySQLHandler();
	
	if(!$handler->table_exists("quote_news"))
	{
		$fields=array();
		$primary_key="newsid";
		$fields['newsid']='INT NOT NULL AUTO_INCREMENT';
		$fields['newstime']='VARCHAR(255)';
		$fields['newsdate']='VARCHAR(255)';
		$fields['newscomp']='VARCHAR(255)';
		$fields['newstitle']='VARCHAR(255)';
		$fields['newsiblings']='VARCHAR(255)';
		$fields['newsno']='VARCHAR(255)';
		$fields['newskey']='VARCHAR(255)';

		$handler->create_table("quote_news", $fields, $primary_key);
	}
}

function quote_news_insert_into_table($newstime, $newsdate, $newscomp, $newstitle, $newsiblings, $newsno, $newskey)
{
	$handler=new MySQLHandler();
	$keys=array("newstime", "newsdate", "newscomp", "newstitle", "newsiblings", "newsno", "newskey");
	$values=array($newstime, $newsdate, $newscomp, $newstitle, $newsiblings, $newsno, $newskey);
	$handler->insert_into_table("quote_news", $keys, $values);
}

function quote_news_create_html_table()
{
	$handler=new MySQLHandler();
	$keys=array("newstime", "newsdate", "newscomp", "newstitle", "newsiblings", "newsno", "newskey");
	$criteria="";
	$display_fields=array("newstime", "newsdate", "newscomp", "newstitle", "newsiblings", "newsno", "newskey");
	$display_style="";
	echo $handler->create_html_table("quote_news", $keys, $criteria, $display_fields, $display_style);
}

function quote_news_create_json($start_row_index, $row_count, $newscomp)
{
	$total_count=quote_news_count($newscomp);
	$handler=new MySQLHandler();
	$handler->connect();
	$handler->select_database();
	
	$keys=array("newstime", "newsdate", "newscomp", "newstitle", "newsiblings", "newsno", "newskey");
	
	$criteria="LIMIT ".$start_row_index.", ".$row_count;
	if(strcmp($newscomp, "All") !=0)
	{
		$criteria="WHERE newscomp='".mysql_real_escape_string($newscomp)."' ".$criteria;
	}
	
	echo '{';
	echo '"PageCount":"'.ceil(floatval($total_count) / floatval($row_count)).'",';
	echo '"PageIndex":"'.floor(floatval($start_row_index) / floatval($row_count)).'",';
	echo '"PageSize":"'.$row_count.'",';
	echo '"News":[';
	

	$data=$handler->naked_select_from_table("quote_news", $keys, $criteria);
	
	$counter=0;
	while($row = mysql_fetch_array($data))
	{
		if($counter!=0)
		{
			echo ',';
		}
		$counter+=1;
		
		$newstime=mysql_real_escape_string($row["newstime"]);
		$newsdate=mysql_real_escape_string($row["newsdate"]);
		$newscomp=mysql_real_escape_string($row["newscomp"]);
		$newstitle=mysql_real_escape_string($row["newstitle"]);
		$newsiblings=mysql_real_escape_string($row["newsiblings"]);
		$newsno=mysql_real_escape_string($row["newsno"]);
		$newskey=mysql_real_escape_string($row["newskey"]);
			
		echo '{"Time": "'.$newstime.'", "Date": "'.$newsdate.'", "Company": "'.$newscomp.'", "Title": "'.$newstitle.'", "Siblings": "'.$newsiblings.'", "SNo": "'.$newsno.'", "Key": "'.$newskey.'"}';
	}

	$handler->disconnect();
	
	echo ']';
	echo '}';
}
?>