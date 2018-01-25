jQuery( document ).ready(function( $ ) {
  $("#country").change(function(){
    $("#provState, #postalZip").val("");
      
    if(this.value == "Canada")
	{
		$(".Canada").show();
        $(".USA").hide();
        $("#postalZip").mask("S0S0S0");
    }
	else
	{
        $(".Canada").hide();
        $(".USA").show();
        $("#postalZip").mask("00000");
    }
  });
});