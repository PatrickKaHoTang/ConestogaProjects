jQuery( document ).ready(function( $ ) {
  $("#country").change(function(){
    $("#state, #postalCode").val("");
      
    if(this.value == "Canada")
	{
		$(".province").show();
        $(".state").hide();
        $("#postalZip").mask("S0S0S0");
    }
	else
	{
        $(".province").hide();
        $(".state").show();
        $("#postalZip").mask("00000");
    }
  });
});