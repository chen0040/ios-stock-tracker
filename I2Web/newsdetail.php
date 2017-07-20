<?php

if(isset($_GET['key']))
{
	header('location: http://info.sgx.com/webcorannc.nsf/vwprint_portal/'.$_GET['key'].'?OpenDocument');
}
?>
