<?php
include("QuoteManager.php");

if(isset($_GET['code']))
{
	$qm=QuoteManager::getInstance();
	$qm->clear();
	$quote=$qm->find('http://www.sgx.com/JsonRead/JsonData?qryId=Stock&timeout=30', $_GET['code']); //'Ziwo'
	echo $quote->toJSON();
}

?>