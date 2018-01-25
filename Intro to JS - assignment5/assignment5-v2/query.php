<!--
Purpose: PHP query from the connected database

File Name: query.php

Created by Patrick Tang

Revision History:
		April 11, 2016 - Created
		April 13, 2016 - Made the connection between PHP and the database
		April 14, 2016 - Fixed and separated the queries to reflect on what they type or selected
						 from the list
-->

<!DOCTYPE html>

<html lang="en">

<head>
	<title>Parts Query</title>
</head>

<body>
	<?php
		$db = 'C:\\xampp\\htdocs\\db\\as4.accdb';
		$conn = new COM('ADODB.Connection');
		$conn->Open("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=$db");
		
		$data = isset($_GET["query"]) ? $_GET["query"] : "";

		if ($data == "vendor")
		{
			$vendorQuery = isset($_GET["vendorQuery"]) ? $_GET["vendorQuery"] : "";
			
			$sql = "SELECT * FROM vendor WHERE vendorName LIKE '%$vendorQuery%' ORDER BY vendorName";
			$rs = $conn->Execute($sql);
			
			echo "<table border=\"1\">";
			echo "<tr>";
			echo "<th>Vendor Number</th>";
			echo "<th>Vendor Name</th>";
			echo "<th>Address</th>";
			echo "<th>City</th>";
			echo "<th>Province</th>";
			echo "<th>Postal Code</th>";
			echo "<th>Country</th>";
			echo "<th>Phone</th>";
			echo "<th>FAX</th>";
			echo "</tr>";
			
			while (!$rs->EOF)
			{
				echo "<tr>";
				echo "<td align=\"center\">".$rs->Fields['vendorNo']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['vendorName']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['address1']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['city']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['provState']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['postalZip']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['country']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['phone']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['FAX']->Value."</td>";
				echo "</tr>";
			
				$rs->MoveNext();
			}
			
			echo "</table>";
			
			$rs->Close();
			$conn->Close();
		}
		else
		{
			$partQuery = isset($_GET["partQuery"]) ? $_GET["partQuery"] : "";
			
			$sql = "SELECT * FROM part WHERE vendorNo LIKE '%$partQuery%' ORDER BY description";
			$rs = $conn->Execute($sql);
		
			echo "<table border=\"1\">";
			echo "<tr>";
			echo "<th>Part ID</th>";
			echo "<th>Vendor Number</th>";
			echo "<th>Description</th>";
			echo "<th>On Hand</th>";
			echo "<th>On Order</th>";
			echo "<th>Cost</th>";
			echo "<th>List Price</th>";
			echo "</tr>";
			
			while (!$rs->EOF)
			{
				echo "<tr>";
				echo "<td align=\"center\">".$rs->Fields['partID']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['vendorNo']->Value."</td>";
				echo "<td align=\"center\">".$rs->Fields['description']->Value."</td>";
				echo "<td align=\"right\">".$rs->Fields['onHand']->Value."</td>";
				echo "<td align=\"right\">".number_format(round($rs->Fields['onOrder']->Value,2), 2, '.', ',')."</td>";
				echo "<td align=\"right\">".number_format(round($rs->Fields['cost']->Value,2), 2, '.', ',')."</td>";
				echo "<td align=\"right\">".number_format(round($rs->Fields['listPrice']->Value,2), 2, '.', ',')."</td>";
				echo "</tr>";
			
				$rs->MoveNext();
			}
			
			echo "</table>";
		
			$rs->Close();
			$conn->Close();
		}
	?>
<center><input type="button" value="Go to Main Page" onClick="javascript:location.href='assignment5.html'"></center>
</body>
</html>
