<?php
require_once("price_tableutil.php");

quote_prices_create_table_if_not_exists();

$start_row_index=0;
$row_count=20;
$quotetype="";

if(isset($_GET["startrowindex"]))
{
	$start_row_index=intval($_GET["startrowindex"]);
}

if(isset($_GET["rowcount"]))
{
	$row_count=intval($_GET["rowcount"]);
}

if(isset($_GET["quotetype"]))
{
	$quotetype=$_GET["quotetype"];
}

quote_prices_create_json($start_row_index, $row_count, $quotetype);

?>