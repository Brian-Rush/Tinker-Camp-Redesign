using System.Collections.Generic;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Tinker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/register"] = _ => {
        return View["reg.cshtml"];
      };

      Post["/"] = _ => {
        var firstName = Request.Form["guardian-first-name"];
        var secondName = Request.Form["guardian-last-name"];
        var address = Request.Form["guardian-street-address"];
        var city = Request.Form["guardian-city"];
        var state = Request.Form["guardian-state"];
        int zip = 0;
        int.TryParse(Request.Form["guardian-zip"], out zip);
        var phone = Request.Form["guardian-phone"];
        var email = Request.Form["guardian-email"];
        var code = Request.Form["purchase-code"];
        Parent newParent = new Parent(firstName, secondName, address, city, state, zip, phone, email, code);
        newParent.Save();

        var childFirstName = Request.Form["child-first-name"];
        var childLastName = Request.Form["child-last-name"];
        int childAge = 0;
        int.TryParse(Request.Form["child-age"], out childAge);
        int childGrade = 0;
        int.TryParse(Request.Form["child-grade"], out childGrade);
        var childGender = Request.Form["child-gender-pronoun"];
        var childRace = Request.Form["child-race"];
        var childStreetAddress = Request.Form["child-street-address"];
        var childCity = Request.Form["child-city"];
        var childState = Request.Form["child-state"];
        int childZip = 0;
        int.TryParse(Request.Form["child-zip"], out childZip);
        var childPhone = Request.Form["child-phone"];
        Child newChild = new Child(childFirstName, childLastName, childAge, childGrade, childGender, childRace, childStreetAddress, childCity, childState, childZip, childPhone);
        newChild.Save();

        int number = 0;
        int.TryParse(Request.Form["session"], out number);
        Session controlSession = Session.Find(number);
        // Session findSession = Session.Find(session);
        // findSession.AddChild(newChild);

        return View["index.cshtml"];
      };
    }
  }
}
