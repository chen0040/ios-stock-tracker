<?php
require_once("news_tableutil.php");

quote_news_create_table_if_not_exists();

$cls=intval($_POST["cls"]);

if($cls==1)
{
	quote_news_clear_table();
}

$array_newstime=$_POST["newstime"];
$array_newsdate=$_POST["newsdate"];
$array_newscomp=$_POST["newscomp"];
$array_newstitle=$_POST["newstitle"];
$array_newsiblings=$_POST["newsiblings"];
$array_newsno=$_POST["newsno"];
$array_newskey=$_POST["newskey"];

$array_size=count($array_newstime);
for($i=0; $i < $array_size; ++$i)
{
	$newstime=$array_newstime[$i];
	$newsdate=$array_newsdate[$i];
	$newscomp=$array_newscomp[$i];
	$newstitle=$array_newstitle[$i];
	$newsiblings=$array_newsiblings[$i];
	$newsno=$array_newsno[$i];
	$newskey=$array_newskey[$i];
	
	quote_news_insert_into_table($newstime, $newsdate, $newscomp, $newstitle, $newsiblings, $newsno, $newskey);
	//echo '{"new updated":"'.$newstime.'"...}'."\n";
}

echo '{"news updated":"'.$newstitle.'"...}';
//echo '{count:'.$array_size.'}'."\n";

?>