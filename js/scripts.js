// BACK END

//ChildInfo Object Constructor
function ChildInfo(childFirstName, childLastName) {
  this.childName = childFirstName + " " + childLastName;
  this.sessionNames = [];
  // this.date = date;
  this.cost = "$300";
}

//Prototype to push sessions to ChildInfo.sessionsNames array
ChildInfo.prototype.pushToSessionNames = function() {
  var getDropdownValue = document.getElementsByClassName('session');
  this.sessionNames = [];

  for (i = 0; i < (getDropdownValue.length); i++) {
    this.sessionNames.push(getDropdownValue[i].value);
  }
}

// click counter on input#add-a-session in html
var clicks = 0;
function onClick() {
    clicks += 1;
};

// click counter on input.additional-child in html
var extraChildren = 0;
function childCount() {
    extraChildren += 1;
};


// FRONT END

// Document Ready
$(function() {

// Section 1 button click listener
  $(".parent-continue").click(function(event) {
    event.preventDefault();

    // Form validation
    // $(".reg-form").valid();


    // Toggle accordion panels from step 1 to 2
    $(".step-1").toggleClass("inactive")
    $(".step-2").toggleClass("active")

    // Get inputted values for guardian
    var gFirstName = $("input[name=guardian-first-name]").val();
    var gLastName = $("input[name=guardian-last-name]").val();
    var gStreetAddress = $("input[name=guardian-street-address]").val();
    var gCity = $("input[name=guardian-city]").val();
    var gState = $("input[name=guardian-state]").val();
    var gZip = $("input[name=guardian-zip]").val();
    var gPhone = $("input[name=guardian-phone]").val();
    var gEmail = $("input[name=guardian-email]").val();
    var purchaseCode = $("input[name=purchase-code]").val();

    // Send inputted guardian info to step 3 table
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

  // Go back to edit section 2 child info
  $(".child-back").click(function(event) {
    $(".step-1").toggleClass("inactive")
    $(".step-2").toggleClass("active")
  });

  // Go back to edit section 1 parent info
  $(".edit-parent").click(function(event) {
    $(".step-1").toggleClass("inactive")
    $(".step-3").toggleClass("active")
  });

  //Go back to edit section 2 child info, FROM section 3
  $(".edit-child").click(function(event) {
    $(".step-2").toggleClass("active")
    $(".step-3").toggleClass("active")
  });

  var preclick = clicks - 1;

  //Adds additional dropdown(s) for sessions
  $("#add-a-session").click(function(event) {
    event.preventDefault();

    if ($('.session').length <= 3) {
      $(".hidden-div").before('<select class="session session-' + clicks + '"   name="session"><option name="no-extra-session" value="" selected>-</option><option name="miniature-worlds" value="Miniature Worlds (7/10-7/14)">Miniature Worlds (7/10-7/14)</option><option name="carnival" value="Carnival (7/17-7/21)">Carnival (7/17-7/21)</option><option name="flight" value="Flight (7/24-7/28)">Flight (7/24-7/28)</option><option name="urban-adventure" value="Urban Adventure (7/31-8/4)">Urban Adventure (7/31-8/4)</option></select>')
    }
  });

  // Continue to step 3 from step 2 and send child info to step 3 table
  $(".child-continue").click(function(event) {
    event.preventDefault();

    // Toggle accordion panels from step 2 to 3
    $(".step-2").toggleClass("active")
    $(".step-3").toggleClass("active")


    var childFirstName = $("input[name=child-first-name]").val();
    var childLastName = $("input[name=child-last-name]").val();

    //create new ChildInfo Object
    var newChildInfo = new ChildInfo(childFirstName, childLastName);

    //Call on prototype to push sessions to ChildInfo Object session array
    newChildInfo.pushToSessionNames();

    console.log(newChildInfo);
    console.log(newChildInfo.sessionNames);

    // Clear step 3 table so we don't get duplicate sessions
    $(".target-row").empty();

    // Display info to step 3 table
    for (i = 0; i < newChildInfo.sessionNames.length; i++ ) {
      $("#target-row0").before("<tr class='target-row'><td>" + newChildInfo.childName + "</td><td>" + newChildInfo.sessionNames[i] + "</td><td>" + newChildInfo.cost + "</td></tr>");
    }
  });

  //Add phone number notation to phone field in form
  $(".phone").mask("(999) 999-9999");

});
