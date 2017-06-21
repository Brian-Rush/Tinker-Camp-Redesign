// BACK END






// FRONT END
var clicks = 0;



$(function() {
//
//   $(".reg-form").validate({
//     rules: {
//       guardianFirstName: "required"
//     },
//     message: {
//       guardianFirstName: "required"
//     }
//   });

  $(".parent-continue").click(function(event) {
    event.preventDefault();

    // $(".reg-form").valid();

    $(".step-1").toggleClass("inactive")
    $(".step-2").toggleClass("active")

    var gFirstName = $("input[name=guardian-first-name]").val();
    var gLastName = $("input[name=guardian-last-name]").val();
    var gStreetAddress = $("input[name=guardian-street-address]").val();
    var gCity = $("input[name=guardian-city]").val();
    var gState = $("input[name=guardian-state]").val();
    var gZip = $("input[name=guardian-zip]").val();
    var gPhone = $("input[name=guardian-phone]").val();
    var gEmail = $("input[name=guardian-email]").val();
    var purchaseCode = $("input[name=purchase-code]").val();

    $("#guardian-first-name").text(gFirstName);
    $("#guardian-last-name").text(gLastName);
    $("#guardian-street-address").text(gStreetAddress);
    $("#guardian-city").text(gCity);
    $("#guardian-state").text(gState);
    $("#guardian-zip").text(gZip);
    $("#guardian-phone").text(gPhone);
    $("#guardian-email").text(gEmail);
    $("#purchase-code").text(purchaseCode);
  });


  $(".child-continue").click(function(event) {
    event.preventDefault();

    $(".step-2").toggleClass("active");
    $(".step-3").toggleClass("active");

    var childFirstName = $("input[name=child-first-name]").val();
    var childLastName = $("input[name=child-last-name]").val();
    var sessionName = $(".session option:selected").val();

    $("#confirm-header").html("<tr><td>" + childFirstName + " " + childLastName + "</td>" + "<td>" + sessionName + "</td><td> $300 </td></tr>")
  });

  $(".child-back").click(function(event) {
    $(".step-1").toggleClass("inactive")
    $(".step-2").toggleClass("active")
  });

  $(".edit-parent").click(function(event) {
    $(".step-1").toggleClass("inactive")
    $(".step-3").toggleClass("active")
  });

  $(".edit-child").click(function(event) {
    $(".step-2").toggleClass("active")
    $(".step-3").toggleClass("active")
  });



  $("#add-a-session").click(function(event) {
    event.preventDefault();



    $(".session").after('<select class="session-' + clicks + '" name="session"><option name="no-extra-session" value="" selected>-</option><option name="miniature-worlds" value="Miniature Worlds">Miniature Worlds (7/10-7/14)</option><option name="carnival" value="Carnival">Carnival (7/17-7/21)</option><option name="flight" value="Flight">Flight (7/24-7/28)</option><option name="urban-adventure" value="Urban Adventure">Urban Adventure (7/31-8/4)</option></select>')
  });

  $(".phone").mask("(999) 999-9999");

});
