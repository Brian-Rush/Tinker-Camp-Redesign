using System.Collections.Generic;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;
using Salon.Objects;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ =>
      {
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["index.cshtml", AllStylist];
      };
      Get["/stylists"]= _ =>
      {
        List<Client> AllClient = Client.GetAll();
        return View["clients.cshtml", AllClient];
      };
    }
  }
}
