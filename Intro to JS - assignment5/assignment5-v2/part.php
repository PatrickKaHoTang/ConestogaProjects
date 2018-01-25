<!--
Purpose: PHP query from the connected database

File Name: part.php

Created by Patrick Tang

Revision History:
		April 11, 2016 - Created
		April 13, 2016 - Inserted data into the database successfully
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Part Added</title>
</head>

<body>
	<?php
		$message = validatePart();
	
		if (validatePart())
		{			
			$vendorNum2  = $_POST["vendorNum2"];
			$description = $_POST["description"];
			$onHand      = $_POST["onHand"];
			$onOrder     = $_POST["onOrder"];
			$cost        = $_POST["cost"];
			$listPrice   = $_POST["listPrice"];
		
			$db = 'C:\\xampp\\htdocs\\db\\as4.accdb';
			$conn = new COM('ADODB.Connection');
			$conn->Open("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=$db");
		
			$sql = "INSERT INTO part (vendorNo, description, onHand, onOrder, cost, listPrice)
					VALUES ('$vendorNum2', '$description', '$onHand', '$onOrder', '$cost', '$listPrice')";
			$rs = $conn->Execute($sql);
			
			print "<h2>Successful Part Entry</h2>";
			print "Vendor Number: $vendorNum2<br>";
			print "Description: $description<br>";
			print "onHand: $onHand<br>";
			print "onOrder: $onOrder<br>";
			print "Cost: $cost<br>";
			print "listPrice: $listPrice<br>";
		}
		else
		{
			print "<script type=\"text/javascript\"> alert(\"$message\"); </script>";
		}
		
		// Revalidating parts
		function validatePart()
		{
			$message = "";
			
			$vendorNum2  = $_POST["vendorNum2"];
			$description = $_POST["description"];
			$onHand      = $_POST["onHand"];
			$onOrder     = $_POST["onOrder"];
			$cost        = $_POST["cost"];
			$listPrice   = $_POST["listPrice"];

			$message .= validateVendorNum2($vendorNum2);
			$message .= validateDescription($description,5);
			$message .= validateOnHand($onHand);
			$message .= validateOnOrder($onOrder);
			$message .= validateCost($cost);
			$message .= validateListPrice($listPrice);
			
			return $message;
		}
		
		//
		// Re-validations for PHP
		//
		
		// Validation for Vendor Number input (second)
		function validateVendorNum2($vendorNum2)
		{
			if ($vendorNum2 == "")
			{				
				return '- You must enter in a valid vendor number\n';
			}
			else
			{
				return "";
			}
		}	
		
		// Validation for Description input
		function validateDescription($description)
		{
			if ($description < 5 || $description == "")
			{
				return '- The description must be greater than 5 characters long\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for On Hand input
		function validateOnHand($onHand)
		{
			if (is_numeric($onHand) || $onHand == "")
			{
				return '- You must enter in what you have onHand\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for On Order input
		function validateOnOrder($onOrder)
		{
			if (is_numeric($onOrder) || $onOrder == "")
			{
				return '- You must enter in what you have onOrder\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for Cost input
		function validateCost($cost)
		{
			if (is_numeric($cost) || $cost == "")
			{
				return '- You must enter a value for cost\n';
			}
			else
			{
				return "";
			}
		}

		// Validation for List Price input
		function validateListPrice($listPrice)
		{
			if (is_numeric($listPrice) || $listPrice == "")
			{
				return '- You must enter a value for listPrice\n';
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
