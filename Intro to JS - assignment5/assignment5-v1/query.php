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
			$sql = "SELECT * FROM vendor ORDER BY vendorNo";
			$rs = $conn->Execute($sql);
			
			<table border="1">
				<tr>
					<th>Vendor Number</th>
					<th>Vendor Name</th>
					<th>Address</th>
					<th>City</th>
					<th>Province</th>
					<th>Postal Code</th>
					<th>Country</th>
					<th>Phone</th>
					<th>FAX</th>
				</tr>
			
			while (!$rs->EOF):
			
				<tr>
					<td align = "center"><?= $rs->Fields['vendorNo']->Value ?></td>
					<td align = "center"><?= $rs->Fields['vendorName']->Value ?></td>
					<td align = "center"><?= $rs->Fields['address1']->Value ?></td>
					<td align = "center"><?= $rs->Fields['city']->Value ?></td>
					<td align = "center"><?= $rs->Fields['provState']->Value ?></td>
					<td align = "center"><?= $rs->Fields['postalZip']->Value ?></td>
					<td align = "center"><?= $rs->Fields['country']->Value ?></td>
					<td align = "center"><?= $rs->Fields['phone']->Value ?></td>
					<td align = "center"><?= $rs->Fields['FAX']->Value ?></td>
				</tr>
			
				$rs->MoveNext()
			
			endwhile
			
			</table>
			
				$rs->Close();
				$conn->Close();
		}
		else
		{
			$sql = "SELECT * FROM part ORDER BY description";
			$rs = $conn->Execute($sql);
		
			<table border="1">
				<tr>
					<th>Part ID</th>
					<th>Vendor Number</th>
					<th>Description</th>
					<th>On Hand</th>
					<th>On Order</th>
					<th>Cost</th>
					<th>List Price</th>
				</tr>
			
			while (!$rs->EOF):
			
				<tr>
					<td align = "center"><?= $rs->Fields['partID']->Value ?></td>
					<td align = "center"><?= $rs->Fields['vendorNo']->Value ?></td>
					<td align = "center"><?= $rs->Fields['description']->Value ?></td>
					<td align = "right"><?= $rs->Fields['onHand']->Value ?></td>
					<td align = "right"><?= number_format(round($rs->Fields['onOrder']->Value,2), 2, '.', ',') ?></td>
					<td align = "right"><?= number_format(round($rs->Fields['cost']->Value,2), 2, '.', ',') ?></td>
					<td align = "right"><?= number_format(round($rs->Fields['listPrice']->Value,2), 2, '.', ',') ?></td>
				</tr>
			
				$rs->MoveNext()
			
			endwhile
			
			</table>
		
			$rs->Close();
			$conn->Close();
		}
	?>
<center><input type="button" value="Go to Main Page" onClick="javascript:location.href='assignment5.html'"></center>
</body>
</html>
