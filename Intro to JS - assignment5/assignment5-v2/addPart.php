<!--
Purpose: Using Javascript/HTML to pass data to a database using PHP

File Name: addPart.php

Created by Patrick Tang

Revision History:
		April 5, 2016  - Created
		April 13, 2016 - Separated page from a consolidated page
						 ** From assignment5.html to addPart.php **
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Adding Part</title>
	<link rel="stylesheet" type="text/css" href="styles/main.css">
	<script src="validate.js"></script>
</head>

<body>
	<h2>Adding Part</h2>
	
	<fieldset>
		<legend><h2>Parts</h2></legend>
		<form name="part" method="post" action="part.php" onsubmit="return validatePart()">
			<div id="formPart">
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

				<label for="vendorNum2">Vendor</label>
					<select name="vendorNum2" id="vendorNum2">
					<option value="">-- select --</option>
				<?php echo $html;?>
					</select><br>
				
				<label for="description">Description:</label>
				<input type="text" id="description" name="description" onblur="trimPart()"><br>
				
				<label for="onHand">onHand:</label>
				<input type="text" id="onHand" name="onHand" onblur="trimPart()"><br>
				
				<label for="onOrder">onOrder:</label>
				<input type="text" id="onOrder" name="onOrder" onblur="trimPart()"><br>
				
				<label for="cost">Cost:</label>
				<input type="text" id="cost" name="cost" onblur="trimPart()"><br>
				
				<label for="listPrice">List Price:</label>
				<input type="text" id="listPrice" name="listPrice" onblur="trimPart()">
			</div>
			
			<div id="buttons">
				<button type="submit">Submit</button>
				<button type="reset">Reset</button>
			</div>
		</form>
	</fieldset>
</body>

</html>