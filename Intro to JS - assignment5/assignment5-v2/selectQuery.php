<!--
Purpose: Using Javascript/HTML to pass data to a database using PHP

File Name: selectQuery.html

Created by Patrick Tang

Revision History:
		April 5, 2016 - Created
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Adding Part</title>
	<link rel="stylesheet" type="text/css" href="styles/main.css">
	<script src="validate.js"></script>
</head>

<body>
	<h2>Select a Query</h2>
	
	<p>Please select a query:</p>
	<fieldset>
		<legend><h2>Vendor</h2></legend>
		<p>Enter a Vendor Name:</p>
		<label for="vendorQuery" name="vendorQuery">Vendor Name</label>
		<input type="text" name="vendorQuery">
		<input type="button" name="vendorQuery" value="Start" onClick="javascript:location.href='query.php?query=vendor'">
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
			<select name="partQuery" id="partQuery">
			<option value="">(Select)</option>
		<?php echo $html;?>
		</select>
		
		<input type="button" name="partQuery" value="Start" onClick="javascript:location.href='query.php'">
	</fieldset>
</body>



</html>