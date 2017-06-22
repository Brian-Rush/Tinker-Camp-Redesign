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
var extraChildren = 1;
function childCount() {
    extraChildren += 1;
};


// FRONT END

// main body tabs for mobile

function switchTab(tabName) {
    var i;
    var x = document.getElementsByClassName("tab");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    document.getElementById(tabName).style.display = "block";
}

// Document Ready
$(function() {

  // hamburger menu animation

  $('#hamburger').click(function(){
    $(this).toggleClass('open');
    $('#mobile-nav').toggleClass('open');
  });

  // hamburger accordion menu
  $('.js-accordion-trigger').bind('click', function(e){
    $(this).parent().find('.submenu').slideToggle('fast');  // apply the toggle to the ul
    $(this).parent().toggleClass('is-expanded');
    e.preventDefault();
  });

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

  //Add Additional Child sub-form (doesn't add enough unique IDs to keep click counters functioning properly)

  // $("#additional-child").click(function() {
  //   $(".additional-child-target").before('<h3>Child '+ extraChildren + '</h3><label for="child-first-name">Child&apos;s First Name:</label><input type="text" name="child-first-name"><label for="child-last-name">Child&apos;s Last Name:</label><input type="text" name="child-last-name"><label for="child-age">Age:</label><select class="age" name="child-age"><option value="" disabled selected style="display: none;">Select</option><option value="8">8</option><option value="9">9</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option></select><label for="child-grade">Grade (in September)</label><select class="grade" name="child-grade"><option value="" disabled selected style="display: none;">Select</option><option value="3rd">3rd Grade</option><option value="4th">4th Grade</option><option value="5th">5th Grade</option><option value="6th">6th Grade</option><option value="7th">7th Grade</option><option value="8th">8th Grade</option><option value="9th">9th Grade</option></select><select class="gender-pronoun" name="child-gender-pronoun"><option value="no-answer" selected>No Answer</option><option value="she-her">She / Her</option><option value="he-him">He / Him</option><option value="they-them">They / Them</option></select><select class="race" name="child-race"><option value="no-answer" selected>No Answer</option><option value="african-american">African American</option><option value="anglo-white">Anglo / White</option><option value="asian">Asian</option><option value="hispanic">Hispanic</option><option value="other">Other</option></select><label for="child-street-address">Street Address:</label><input type="text" name="child-street-address"><label for="child-city">City:</label><input type="text" name="child-city"><label for="child-state">State:</label><input type="text" name="child-state"><label for="child-zip">Zip:</label><input type="text" name="child-zip"><label for="child-phone">Phone:</label><input class="phone" type="text" name="child-phone"><select class="session session-' + extraChildren + '" name="session"><option name="miniature-worlds" value="Miniature Worlds (7/10-7/14)" selected>Miniature Worlds (7/10-7/14)</option><option name="carnival" value="Carnival (7/17-7/21)">Carnival (7/17-7/21)</option><option name="flight" value="Flight (7/24-7/28)">Flight (7/24-7/28)</option><option name="urban-adventure" value="Urban Adventure (7/31-8/4)">Urban Adventure (7/31-8/4)</option></select><div class="hidden-div"></div><input value="+" onclick="onClick()" type="button" name="add-a-session" id="add-a-session' +  + '"></input><label for="notes">Notes:</label><input type="text" name="notes">')
  // });
});
