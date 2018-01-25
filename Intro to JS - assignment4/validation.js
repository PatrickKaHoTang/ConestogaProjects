/*
Purpose:   Assignment 4 with JavaScript validations before it goes to the PHP.

File Name: validation.js

Created by Patrick Tang

Revision History:
	March 10, 2016 - Created
	March 13, 2016 - Added JavaScript validations
	March 17, 2016 - Changed the way I've been finding data with a different command
					 ie. document.form -> document.getElementById("")
	March 29, 2016 - Added jQuery function and a non-numeric validation for names
					 *Note: See spinner
*/

// Validates the form
function validateForm()
{
	message = "";
	
	var firstName    = document.getElementById("firstName").value;
	var lastName     = document.getElementById("lastName").value;
	var address      = document.getElementById("address").value;
	var city         = document.getElementById("city").value;
	var provinceCode = document.getElementById("provinceCode").value;
	var postalCode   = document.getElementById("postalCode").value;
	
	validateFirstName(firstName,2);
	validateLastName(lastName,2);
	validateAddress(address,5);
	validateCity(city,3);
	validateProvinceCode(provinceCode);
	validatePostalCode(postalCode);
	
	if (message != "")
	{
		alert(message);
		return false;
	}
}

// Validates the first name
function validateFirstName(firstName,x)
{
	if (firstName.length < x || !isNaN(firstName))
	{
		if (message == "")
		{
			document.getElementById("firstName").focus();
		}
		message += '- Your first name must have at least ' + x + ' characters and be non-numeric\n';
	}
	else
	{
		return true;
	}
}

// Validates the last name
function validateLastName(lastName,x)
{
	if (lastName.length < x || !isNaN(lastName))
	{
		if (message == "")
		{
			document.getElementById("lastName").focus();
		}
		message += '- Your last name must have at least ' + x + ' characters and be non-numeric\n';
	}
	else
	{
		return true;
	}
}

// Validates the address
function validateAddress(address,x)
{
		if (address.length < x)
		{
			if (message == "")
			{
				document.getElementById("address").focus();
			}
			message += '- Your address must be higher than ' + x + ' characters\n';
		}
		else
		{
			return true;
		}
	}

// Validates the province code
function validateProvinceCode(provinceCode)
{
	if (provinceCode == "Default")
	{
		if (message == "")
		{
			document.getElementById("provinceCode").focus();    
		}
		message += '- Select your province from the list\n';
	}
	else
	{
		return true;
	}
}

// Validates the city
function validateCity(city,x)
{
	if (city.length < x || !isNaN(city))
	{
		if (message == "")
		{
			document.getElementById("city").focus();    
		}
		message += '- Your city must have more than ' + x + ' characters\n';
	}
	else
	{
		return true;
	}
}

// Validates the postal code
function validatePostalCode(postalCode)
{
	var postalCodeFormat = /^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$/i;
	
	if (postalCode.match(postalCodeFormat))
	{
		return true;
	}
	else
	{
		if (message == "")
		{
			document.getElementById("postalCode").focus();    
		}
		message += '- You must have the correct format for your postal code. ie. N2J2J9';
	}
}

// onblur - Trimming white spaces for the receipt and capitalizes certain characters
function trim()
{
	firstName.value  = firstName.value.trim();
	lastName.value   = lastName.value.trim();
	address.value    = address.value.trim();
	city.value       = city.value.trim();
	postalCode.value = postalCode.value.trim();
	
	postalCode.value = postalCode.value.toUpperCase();
}

// jQuery - Spinner for the quantity counter
$(function()
{
    var spinner = $("#spinner").spinner();
});