<!--
Purpose: Using Javascript/HTML to pass data to a database using PHP

File Name: selectQuery.php

Created by Patrick Tang

Revision History:
		April 5, 2016  - Created
		April 14, 2016 - Made 2 different queries
		               - Had Rubens help me fix some small issues querying a database
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Adding Part</title>
	<link rel="stylesheet" type="text/css" href="styles/main.css">
</head>

<body>
	<h2>Select a Database to Query</h2>
	<fieldset>
		<legend><h2>Vendor</h2></legend>
		<p>Enter a Vendor Name:</p>
		<form action="query.php">
			<label for="vendorQuery" name="vendorQuery">Vendor Name</label>
			<input type="text" name="vendorQuery">
			<input type="submit" value="Start">
			<input type="hidden" name="query" value="vendor">
		</form>
	</fieldset>
	<fieldset>
		<legend><h2>Part</h2></legend>
		<p>Select a Vendor Name:</p>
		<?php
			$db = 'C:\\xampp\\htdocs\\db\\as4.accdb';
			$conn = new COM('ADODB.Connection');
			$conn->Open("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=$db");
			
			$sql = "SELECT vendorNo, vendorName FROM vendor ORDER BY vendorName";
			$rs = $conn->Execute($sql);
					
			$html = "";
			while (!$rs->EOF)
			{
				$html .= '<option value="'.$rs->Fields['vendorNo']->Value.'">'.$rs->Fields['vendorName']->Value.'</option>';
				$rs->MoveNext();
			}
		?>
		<form action="query.php">
			<select name="partQuery" id="partQuery">
			<option value="">(Select)</option>
		<?php echo $html;?>
			</select>
		
			<input type="submit" value="Start">
			<input type="hidden" name="query" value="">
		</form>
	</fieldset>
</body>



</html>