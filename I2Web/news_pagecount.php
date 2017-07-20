<?php
require_once("news_tableutil.php");

quote_news_create_table_if_not_exists();

$page_size=20;

if(isset($_GET["pagesize"]))
{
	$page_size=intval($_GET["pagesize"]);
}

$count=quote_news_count('All');

if($page_size < 1)
{
	$page_size=1;
}

echo ''.ceil(floatval($count) / floatval($page_size));

?>
