<?php
require_once("news_tableutil.php");

quote_news_create_table_if_not_exists();

$start_row_index=0;
$row_count=20;
$newscomp="";

if(isset($_GET["startrowindex"]))
{
	$start_row_index=intval($_GET["startrowindex"]);
}

if(isset($_GET["rowcount"]))
{
	$row_count=intval($_GET["rowcount"]);
}

if(isset($_GET["newscomp"]))
{
	$newscomp=$_GET["newscomp"];
}

quote_news_create_json($start_row_index, $row_count, $newscomp);

?>