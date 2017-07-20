<?php
require_once("price_tableutil.php");

quote_prices_create_table_if_not_exists();

$cls=intval($_POST["cls"]);

if($cls==1)
{
	quote_prices_clear_table();
}

$array_code=$_POST["code"];
$array_type=$_POST["type"];
$array_lastdone=$_POST["lastdone"];
$array_dayhigh=$_POST["dayhigh"];
$array_daylow=$_POST["daylow"];
$array_bestbuy=$_POST["bestbuy"];
$array_bestsell=$_POST["bestsell"];
$array_vol=$_POST["vol"];
$array_chg=$_POST["chg"];
$array_chgp=$_POST["chgp"];
$array_buyvol=$_POST["buyvol"];
$array_sellvol=$_POST["sellvol"];
$array_openvalue=$_POST["openvalue"];
$array_closevalue=$_POST["closevalue"];
$array_updatetime=$_POST["updatetime"];

$array_size=count($array_code);
for($i=0; $i < $array_size; ++$i)
{
	$code=$array_code[$i];
	$type=$array_type[$i];
	$lastdone=$array_lastdone[$i];
	$dayhigh=$array_dayhigh[$i];
	$daylow=$array_daylow[$i];
	$bestbuy=$array_bestbuy[$i];
	$bestsell=$array_bestsell[$i];
	$vol=$array_vol[$i];
	$chg=$array_chg[$i];
	$chgp=$array_chgp[$i];
	$buyvol=$array_buyvol[$i];
	$sellvol=$array_sellvol[$i];
	$openvalue=$array_openvalue[$i];
	$closevalue=$array_closevalue[$i];
	$updatetime=$array_updatetime[$i];
	
	quote_prices_insert_into_table($code, $type, $lastdone, $dayhigh, $daylow, $bestbuy, $bestsell, $vol, $chg, $chgp, $buyvol, $sellvol, $openvalue, $closevalue, $updatetime);
	//echo '{"price updated":"'.$code.'"...}'."\n";
}

echo '{"price updated":"'.$code.'"...}';
//echo '{count:'.$array_size.'}'."\n";

?>