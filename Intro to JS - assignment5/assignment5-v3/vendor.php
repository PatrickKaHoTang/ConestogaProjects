<!--
Purpose: PHP query from the connected database

File Name: vendor.php

Created by Patrick Tang

Revision History:
		April 11, 2016 - Created
		April 13, 2016 - Inserted data into the database successfully
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Vendor Added</title>
</head>

<body>
	<?php
		$message = validateVendor();
		
		if (validateVendor())
		{
			$vendorNum1 = $_POST["vendorNum1"];
			$vendorName = $_POST["vendorName"];
			$address    = $_POST["address"];
			$city       = $_POST["city"];
			$provState  = $_POST["provState"];
			$postalZip  = $_POST["postalZip"];
			$country    = $_POST["country"];
			if ($_POST["phone"] == "")
			{
				$phone = null;
			}
			else
			{
				$phone = $_POST["phone"];
			}
			if ($_POST["fax"] == "")
			{
				$fax = null;
			}
			else
			{
				$fax = $_POST["fax"];
			}
			
			$db = 'C:\\xampp\\htdocs\\db\\as4.accdb';
			$conn = new COM('ADODB.Connection') or die("Cannot start ADO");
			$conn->Open("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=$db");
			
			$sql = "INSERT INTO vendor (vendorNo, vendorName, address1, city, provState, postalZip, country, phone, FAX) 
					VALUES ('$vendorNum1', '$vendorName', '$address', '$city', '$provState', '$postalZip', '$country', '$phone', '$fax')";
			$rs = $conn->Execute($sql);
			
			print "<h2>Successful Vendor Entry</h2>";
			print "Vendor Number: $vendorNum1<br>";
			print "Vendor Name: $vendorName<br>";
			print "Address: $address<br>";
			print "City: $city<br>";
			print "Province/State: $provState<br>";
			print "Postal/Zip Code: $postalZip<br>";
			print "Country: $country<br>";
			print "Phone Number: $phone<br>";
			print "Fax Number: $fax";
		}
		else
		{
			print "<script type=\"text/javascript\"> alert(\"$message\"); </script>";
		}
		
		// Revalidating Vendor
		function validateVendor()
		{
			$message = "";
			
			$vendorNum1 = $_POST["vendorNum1"];
			$vendorName = $_POST["vendorName"];
			$address    = $_POST["address"];
			$city       = $_POST["city"];
			$provState  = $_POST["provState"];
			$postalZip  = $_POST["postalZip"];
			$country    = $_POST["country"];
			$phone      = $_POST["phone"];
			$fax        = $_POST["fax"];
			
			$message .= validateVendorNum1($vendorNum1);
			$message .= validateVendorName($vendorName,3);
			$message .= validateAddress($address,5);
			$message .= validateCity($city,3);
			$message .= validateProvState($provState);
			$message .= validatePostalZip($postalZip);
			$message .= validateCountry($country);
			$message .= validatePhone($phone);
			$message .= validateFax($fax);
			
			return $message;
		}
		
		//
		// Re-validations for PHP
		//
		
		// Validation for Vendor Number input (first)
		function validateVendorNum1($vendorNum1)
		{
			if (is_numeric($vendorNum1) || $vendorNum1 == "")
			{				
				return '- You must enter in a valid vendor number\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Vendor Name input
		function validateVendorName($vendorName,$x)
		{
			if (strlen($vendorName) < $x || $vendorName == "")
			{
				return '- You must enter in an vendor name " . $x . " characters minimum\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Address input
		function validateAddress($address,$x)
		{
			if (strlen($address) < $x || $address == "")
			{
				return '- You must enter in an address " . $x . " characters minimum\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for City input
		function validateCity($city,$x)
		{
			if (strlen($city) < $x || $city == "")
			{
				return '- You must enter in an city " . $x ." characters minimum\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Province and State input
		function validateProvState($provState)
			{
			if ($provState == "")
			{
				return '- You must enter a province or state\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Postal Code and Zip Code input
		function validatePostalZip($postalZip)
		{
			if (preg_match("/^[0-9A-Z][0-9][0-9A-Z][0-9][0-9A-Z]?[0-9]$/i", $postalZip))
			{
				return "";
			}
			else
			{
				return '- Your zip code must be 5 numbers long or your postal code must be 6 characters long\n';
			}
		}

		// Validation for Country input
		function validateCountry($country)
		{
			if (strlen($country == ""))
			{
				return '- You must select a country\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Phone Number input
		function validatePhone($phone)
		{			
			if (preg_match("/^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/", $phone))
			{
				return '- Your phone number must be 10 numbers long\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Fax input
		function validateFax($fax)
		{			
			if (preg_match("/^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/", $fax))
			{
				return '- Your fax number must be 10 numbers long\n';
			}
			else
			{
				return "";
			}
		}
	?>
<center><input name="" type="button" value="Go to Main Page" onClick="javascript:location.href='assignment5.html'"></center>
</body>
</html>
