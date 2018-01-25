<!--
Purpose:   Assignment 4 validations with PHP and printing the receipt onto the screen to show
		   the user the information they have selected and entered.

File Name: validation.php

Created by Patrick Tang

Revision History:
	March 10, 2016 - Created
	March 13, 2016 - Added PHP validations from JavaScript, changing the JavaScript variables
					 to PHP variables
	March 23, 2016 - Added calculations for subtotal, shipping, delivery and tax, used 
					 number_format for proper decimal placement, and the receipt page display
	March 29, 2016 - Added a non-numeric validation for names
				   - Fixed delivery "days" to an actual date
				   - Added a better presentation for the receipt by changing some alphabetical
				     characters to uppercase
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Receipt</title>
</head>

<body>
	<?php
		print receipt();
	
		// Displays the receipt
		function receipt()
		{			
			$firstName    = $_POST["firstName"];
			$lastName     = $_POST["lastName"];
			$address      = $_POST["address"];
			$city         = $_POST["city"];
			$provinceCode = $_POST["provinceCode"];
			$postalCode   = $_POST["postalCode"];
			
			// Today's date
			$date = date("F j, Y");
			
			// Changes certain alphabetical characters to uppercase for a better
			// presentation on the receipt
			$firstName       = ucfirst($firstName);
			$lastName        = ucfirst($lastName);
			$city            = ucfirst($city);
			$postalCodeUpper = strtoupper($postalCode);
			
			// Items that are being sold
			$item4GBQuantity   = $_POST["item4GB"];   // Selling 4 GB SD Card
			$item8GBQuantity   = $_POST["item8GB"];   // Selling 8 GB SD Card
			$item16GBQuantity  = $_POST["item16GB"];  // Selling 16 GB SD Card
			$item32GBQuantity  = $_POST["item32GB"];  // Selling 32 GB SD Card
			$item64GBQuantity  = $_POST["item64GB"];  // Selling 64 GB SD Card
			$item128GBQuantity = $_POST["item128GB"]; // Selling 128 GB SD Card
			
			$message = validateForm();
			
			// Calculations from functions
			$subTotal	  = subTotal();
			$tax		  = tax($subTotal);
			$shipping     = shipping($subTotal);
			$deliveryDate = deliveryDate($subTotal);
			
			// Calculations on receipt
			$taxTotal   = $subTotal * $tax;
			$total		= $subTotal + $taxTotal;
			$grandTotal = $total + $shipping;
			
			// Calculation formats with correct decimal places
			$shippingFormat   = number_format($shipping,2,'.',',');
			$subTotalFormat   = number_format($subTotal,2,'.',',');
			$taxTotalFormat   = number_format($taxTotal,2,'.',',');
			$grandTotalFormat = number_format($grandTotal,2,'.',',');
		
			if ($message == "")
			{
				print "<h2>Order Information</h2>";
				print "Your order has been processed. Please verify the following information:<br>";
				print "<h3>Shipping To:</h3>";
				print "$firstName $lastName<br>";
				print "$address<br>";
				print "$city, $provinceCode<br>";
				print "$postalCodeUpper<br>";
				print "<h3>Items:</h3>";
				
				if ($item4GBQuantity > 0)
				{
					print "$item4GBQuantity x $4.99 = 4 GB SD Card<br>";
				}
				
				if ($item8GBQuantity > 0)
				{
					print "$item8GBQuantity x $9.99 = 8 GB SD Card<br>";
				}
				
				if ($item16GBQuantity > 0)
				{
					print "$item16GBQuantity x $14.99 = 16 GB SD Card<br>";
				}
				
				if ($item32GBQuantity > 0)
				{
					print "$item32GBQuantity x $19.99 = 32 GB SD Card<br>";
				}
				
				if ($item64GBQuantity > 0)
				{
					print "$item64GBQuantity x $39.99 = 64 GB SD Card<br>";
				}
				
				if ($item128GBQuantity > 0)
				{
					print "$item128GBQuantity x $59.99 = 128 GB SD Card<br>";
				}
				
				print "<br>Subtotal = $$subTotalFormat";
				print "<br>Tax = $$taxTotalFormat";
				print "<br>Delivery = $$shippingFormat";
				print "<br>Total Order = $$grandTotalFormat";
				print "<br><br>Date of purchase: $date";
				print "<br><br>Estimated delivery date: $deliveryDate";
			}
			else
			{
				print "<script type=\"text/javascript\"> alert(\"$message\"); </script>";
			}
		}
		
		// Quantity and total of items purchased
		function subTotal()
		{
			$item4GBQuantity   = $_POST["item4GB"];
			$item8GBQuantity   = $_POST["item8GB"];
			$item16GBQuantity  = $_POST["item16GB"];
			$item32GBQuantity  = $_POST["item32GB"];
			$item64GBQuantity  = $_POST["item64GB"];
			$item128GBQuantity = $_POST["item128GB"];
			
			// Quantity calculation with the value
			$amount = ($item4GBQuantity   * 4.99)  +
					  ($item8GBQuantity   * 9.99)  +
					  ($item16GBQuantity  * 14.99) +
					  ($item32GBQuantity  * 19.99) + 
					  ($item64GBQuantity  * 39.99) +
					  ($item128GBQuantity * 59.99);
					  
			return $amount;
		}
		
		// Shipping cost depending on the subTotal value
		function shipping($subTotal)
		{
			if ($subTotal > 0 && $subTotal <= 25)
			{
				$shipping = 3;
				return $shipping;
			}
			else if ($subTotal > 25 && $subTotal <= 50)
			{
				$shipping = 4;
				return $shipping;
			}
			else if ($subTotal > 50 && $subTotal <= 75)
			{
				$shipping = 5;
				return $shipping;
			}
			else if ($subTotal > 75)
			{
				$shipping = 6;
				return $shipping;
			}
			else
			{
				$shipping = 0;
				return $shipping;
			}
		}
		
		// Delivery cost depending on the subTotal value
		function deliveryDate($subTotal)
		{
			if ($subTotal > 0 && $subTotal <= 25)
			{
				$date = date("F j, Y", strtotime("+1 day"));
				return $date;
			}
			else if ($subTotal > 25 && $subTotal <= 50)
			{
				$date = date("F j, Y", strtotime("+1 day"));
				return $date;
			}
			else if ($subTotal > 50 && $subTotal <= 75)
			{
				$date = date("F j, Y", strtotime("+3 day"));
				return $date;
			}
			else if ($subTotal > 75)
			{
				$date = date("F j, Y", strtotime("+4 day"));
				return $date;
			}
			else
			{
				return 'Unknown as you have nothing purchased';
			}
		}
		
		// Tax depending on which province you are ordering from
		function tax($subTotal)
		{
			$provinceCode = $_POST["provinceCode"];
			
			// Using an array to select the value from the selected province code
			$tax = array('AB' => 0.05,
						 'BC' => 0.12,
						 'MB' => 0.08,
						 'NB' => 0.08,
						 'NL' => 0.13,
						 'NT' => 0.13,
						 'NU' => 0.05,
						 'NS' => 0.15,
						 'ON' => 0.13,
						 'PE' => 0.14,
						 'QC' => 0.14975,
						 'SK' => 0.10,
						 'YK' => 0.05);
						 
			return $tax[$provinceCode];
		}
		
		// Re-validates the whole form
		function validateForm()
		{
			$message      = "";
			$firstName    = $_POST["firstName"];
			$lastName     = $_POST["lastName"];
			$address      = $_POST["address"];
			$city         = $_POST["city"];
			$provinceCode = $_POST["provinceCode"];
			$postalCode   = $_POST["postalCode"];
			
			$message .= validateFirstName($firstName,2);
			$message .= validateLastName($lastName,2);
			$message .= validateAddress($address,5);
			$message .= validateCity($city,3);
			$message .= validateProvinceCode($provinceCode);
			$message .= validatePostalCode($postalCode);
			
			return $message;
		}
		
		// Validates the first name
		function validateFirstName($firstName,$x)
		{
			if (strlen($firstName) < $x || is_numeric($firstName))
			{
				return '- Your first name must have at least ' . $x . ' characters and be non-numeric<br>';
			}
			else
			{
				return "";
			}
		}
		
		// Validates the last name
		function validateLastName($lastName,$x)
		{
			if (strlen($lastName) < $x || is_numeric($lastName))
			{
				return '- Your last name must have at least ' . $x . ' characters and be non-numeric<br>';
			}
			else
			{
				return "";
			}
		}
		
		// Validates the address
		function validateAddress($address,$x)
		{
			if (strlen($address) < $x)
			{
				return '- Your address must be higher than ' . $x . ' characters<br>';
			}
			else
			{
				return "";
			}
		}
		
		// Validates the province code
		function validateProvinceCode($provinceCode)
		{
			if (strlen($provinceCode) != 2)
			{
				return '- Select your province from the list<br>';
			}
			else
			{
				return "";
			}
		}
		
		// Validates the city
		function validateCity($city,$x)
		{
			if (strlen($city) < $x || is_numeric($city))
			{
				return '- Your city must have more than ' . $x . ' characters<br>';
			}
			else
			{
				return "";
			}
		}
		
		// Validates the postal code
		function validatePostalCode($postalCode)
		{		
			if (preg_match("/^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$/i", $postalCode))
			{
				return "";
			}
			else
			{
				return '- You must have the correct format for your postal code. ie. N2J2J9';
			}
		}
	?>
</body>

</html>