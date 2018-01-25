function validateVendor()
{
	message = "";
	
	var vendorNum1 = document.getElementById("vendorNum1").value;
	var vendorName = document.getElementById("vendorName").value;
	var address    = document.getElementById("address").value;
	var city       = document.getElementById("city").value;
	var provState  = document.getElementById("provState").value;
	var postalZip  = document.getElementById("postalZip").value;
	var country    = document.getElementById("country").value;
	var phone      = document.getElementById("phone").value;
	var fax        = document.getElementById("fax").value;
	
	validateVendorNum1(vendorNum1);
	validateVendorName(vendorName,3);
	validateAddress(address,5);
	validateCity(city,3);
	validateProvState(provState,2);
	validatePostalZip(postalZip);
	validateCountry(country,3);
	validatePhone(phone);
	validateFax(fax);
	
	if (message != "")
	{
		alert(message);
		return false;
	}
}

function validatePart()
{
	message = "";
	
	var vendorNum2  = document.getElementById("vendorNum2").value;
	var description = document.getElementById("description").value;
	var onHand      = document.getElementById("onHand").value;
	var onOrder     = document.getElementById("onOrder").value;
	var cost        = document.getElementById("cost").value;
	var listPrice   = document.getElementById("listPrice").value;

	validateVendorNum2(vendorNum2);
	validateDescription(description,5);
	validateOnHand(onHand);
	validateOnOrder(onOrder);
	validateCost(cost);
	validateListPrice(listPrice);
	
	if (cost > listPrice)
	{
		message += '**Your cost of $' + cost + ' must be greater than the list price of $' + listPrice;
	}
	
	if (message != "")
	{
		alert(message);
		return false;
	}
}

//
// All functional validations
//

// Validation for Vendor Number input (first)
function validateVendorNum1(vendorNum1)
{
	if (isNaN(vendorNum1) || vendorNum1 == "")
	{				
		if (message == "")
		{
			document.getElementById("vendorNum1").focus();    
		}
		message += '- You must enter in a valid vendor number\n';
	}
	else
	{
		return true;
	}
}

// Validation for Vendor Number input (second)
function validateVendorNum2(vendorNum2)
{
	if (vendorNum2 == "")
	{				
		if (message == "")
		{
			document.getElementById("vendorNum2").focus();    
		}
		message += '- You must enter in a valid vendor number\n';
	}
	else
	{
		return true;
	}
}

// Validation for Vendor Name input
function validateVendorName(vendorName,x)
{
	if (vendorName < x || vendorName == "")
	{				
		if (message == "")
		{
			document.getElementById("vendorName").focus();    
		}
		message += '- You must enter in an vendor name 3 characters minimum\n';
	}
	else
	{
		return true;
	}
}

// Validation for Address input
function validateAddress(address,x)
{
	if (address < x || address == "")
	{				
		if (message == "")
		{
			document.getElementById("address").focus();    
		}
		message += '- You must enter in an address 5 characters minimum\n';
	}
	else
	{
		return true;
	}
}

// Validation for City input
function validateCity(city,x)
{
	if (city < x || city == "")
	{				
		if (message == "")
		{
			document.getElementById("city").focus();    
		}
		message += '- You must enter in an city 3 characters minimum\n';
	}
	else
	{
		return true;
	}
}

// Validation for Province and State input
function validateProvState(provState,x)
	{
	if (provState.length != x)
	{				
		if (message == "")
		{
			document.getElementById("provState").focus();    
		}
		message += '- Your must enter the abbreviations for your province or state\n';
	}
	else
	{
		return true;
	}
}

// Validation for Postal Code and Zip Code input
function validatePostalZip(postalZip)
{
	var postalZipFormat = /^[0-9A-Z][0-9][0-9A-Z][0-9][0-9A-Z]?[0-9]$/i;

	if (postalZip.match(postalZipFormat))
	{
		return true;
	}
	else
	{
		if (message == "")
		{
			document.getElementById("postalZip").focus();    
		}
		message += '- Your zip code must be 5 characters long or your postal code must be 6 characters long\n';
	}
}

// Validation for Country input
function validateCountry(country,x)
	{
	if (country < x || country == "")
	{				
		if (message == "")
		{
			document.getElementById("country").focus();    
		}
		message += '- Your country must be 3 characters long\n';
	}
	else
	{
		return true;
	}
}

// Validation for Phone Number input
function validatePhone(phone)
{
	var phoneFormat = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;
	
	if (!phone.match(phoneFormat))
	{
		if (message == "")
		{
			document.getElementById("phone").focus();    
		}
		message += '- Your phone number must be 10 numbers long\n';
	}
	else
	{
		return true;
	}
}

// Validation for Fax input
function validateFax(fax)
{
	var faxFormat = /^[(]{0,1}[0-9]{3}[)]{0,1}[-\s\.]{0,1}[0-9]{3}[-\s\.]{0,1}[0-9]{4}$/;
	
	if (!fax.match(faxFormat))
	{
		if (message == "")
		{
			document.getElementById("fax").focus();    
		}
		message += '- Your fax number must be 10 numbers long\n';
	}
	else
	{
		return true;
	}
}

// Validation for Description input
function validateDescription(description)
{
	if (description < 5 || description == "")
	{
		if (message == "")
		{
			document.getElementById("description").focus();    
		}
		message += '- The description must be greater than 5 characters long\n';
	}
}

// Validation for On Hand input
function validateOnHand(onHand)
{
	if (isNaN(onHand) || onHand == "")
	{
		if (message == "")
		{
			document.getElementById("onHand").focus();    
		}
		message += '- You must enter in what you have onHand\n';
	}
}

// Validation for On Order input
function validateOnOrder(onOrder)
{
	if (isNaN(onOrder) || onOrder == "")
	{
		if (message == "")
		{
			document.getElementById("onOrder").focus();    
		}
		message += '- You must enter in what you have onOrder\n';
	}
}

// Validation for Cost input
function validateCost(cost)
{
	if (isNaN(cost) || cost == "")
	{
		if (message == "")
		{
			document.getElementById("cost").focus();    
		}
		message += '- You must enter a value for cost\n';
	}
}

// Validation for List Price input
function validateListPrice(listPrice)
{
	if (isNaN(listPrice) || listPrice == "")
	{
		if (message == "")
		{
			document.getElementById("listPrice").focus();    
		}
		message += '- You must enter a value for listPrice\n';
	}
}

function trimVendor()
{
	vendorNum1.value  = vendorNum1.value.trim();
	vendorName.value  = vendorName.value.trim();
	address.value     = address.value.trim();
	city.value        = city.value.trim();
	provState.value   = provState.value.trim();
	postalZip.value   = postalZip.value.trim();
	country.value     = country.value.trim();
	phone.value       = phone.value.trim();
	fax.value         = fax.value.trim();
	
	provState.value = provState.value.toUpperCase();
	postalZip.value = postalZip.value.toUpperCase();
}

function trimPart()
{
	description.value = description.value.trim();
	onHand.value      = onHand.value.trim();
	onOrder.value     = onOrder.value.trim();
	cost.value        = cost.value.trim();
	listPrice.value   = listPrice.value.trim();
}