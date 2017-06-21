// BACK END

// click counter on input#add-a-session in html

function ChildInfo(childFirstName, childLastName) {
  this.childName = childFirstName + " " + childLastName;
  this.sessionNames = [];
  // this.date = date;
  this.cost = "$300";
}

//Prototype to push sessions to Child.sessionsNames array
ChildInfo.prototype.pushToSessionNames = function() {
  var getDropdownValue = document.getElementsByClassName('session');
  this.sessionNames = [];

  for (i = 0; i < (getDropdownValue.length); i++) {
    this.sessionNames.push(getDropdownValue[i].value);
  }
}

//Prototype to display each child's sessions registered for
// ChildInfo.prototype.displayChildSessions = function() {

  // for (i = 0; i < newChildInfo.sessionNames.length; i++ ) {
  //   var tableRow = "<tr><td>" + this.childName + "</td><td>" + this.sessionNames[i] + "</td><td>" + this.cost + "</td></tr>";

    // return tableRow;
    // }
// }

// var arrayOfChildSessions = [];

var clicks = 0;
function onClick() {
    clicks += 1;
};


// FRONT END


$(function() {

  // // Get the modal
  // var modal = $('#additional-child-modal');
  //
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

  var preclick = clicks - 1;

  $("#add-a-session").click(function(event) {
    event.preventDefault();

    if ($('.session').length <= 3) {
      $(".hidden-div").before('<select class="session session-' + clicks + '"   name="session"><option name="no-extra-session" value="" selected>-</option><option name="miniature-worlds" value="Miniature Worlds (7/10-7/14)">Miniature Worlds (7/10-7/14)</option><option name="carnival" value="Carnival (7/17-7/21)">Carnival (7/17-7/21)</option><option name="flight" value="Flight (7/24-7/28)">Flight (7/24-7/28)</option><option name="urban-adventure" value="Urban Adventure (7/31-8/4)">Urban Adventure (7/31-8/4)</option></select>')
    }
  });

  $(".child-continue").click(function(event) {
    event.preventDefault();

    $(".step-2").toggleClass("active");
    $(".step-3").toggleClass("active");

    var childFirstName = $("input[name=child-first-name]").val();
    var childLastName = $("input[name=child-last-name]").val();

    var newChildInfo = new ChildInfo(childFirstName, childLastName);

    //Call on prototype to push sessions to ChildInfo Object session array
    newChildInfo.pushToSessionNames();

    console.log(newChildInfo);
    console.log(newChildInfo.sessionNames);

    $(".target-row").empty();

    for (i = 0; i < newChildInfo.sessionNames.length; i++ ) {
      $("#target-row0").before("<tr class='target-row'><td>" + newChildInfo.childName + "</td><td>" + newChildInfo.sessionNames[i] + "</td><td>" + newChildInfo.cost + "</td></tr>");
    }

    // pop up additional child modal

    $("#additional-child-modal").css("display", "block");

    $("#total-cost").each(function() {

      // $("#confirm-header").after("<tr><td>" + childFirstName + " " + childLastName + "</td>" + "<td>" + sessionName + "</td><td> $300 </td></tr>")

    });

  });


  $(".phone").mask("(999) 999-9999");

});