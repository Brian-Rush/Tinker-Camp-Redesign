using System.Collections.Generic;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;


namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"]= _ =>{
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["index.cshtml", AllStylist];
      };
      Get["/clients"]= _ =>{
        List<Client> AllClient = Client.GetAll();
        return View["clients.cshtml", AllClient];
      };
      Get["/stylists"]= _ =>{
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["stylists.cshtml", AllStylist];
      };
      Get["/stylists/new"] = _ => {
        return View["stylists_form.cshtml"];
      };
      Post["stylists/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        return View["success.cshtml"];
      };
      Get["/clients/new"] = _ => {
        List<Client> AllClient = Client.GetAll();
        return View["clients_form.cshtml", AllClient];
      };
      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml"];
       };
       Post["/clients/delete"] = _ => {
         Client.DeleteAll();
         return View["cleared.cshtml"];
       };
       Get["/stylists/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         var SelectedStylist = Stylist.Find(parameters.id);
         var StylistClients = SelectedStylist.GetClients();
         model.Add("stylist", SelectedStylist);
         model.Add("clients", StylistClients);

         return View["stylist.cshtml", model];
       };
       Get["/stylist/edit/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         Stylist SelectedStylist = Stylist.Find(parameters.id);
         List<Client> StylistClients = SelectedStylist.GetClients();
         model.Add("stylist", SelectedStylist);
         model.Add("clients", StylistClients);
         return View["stylist_edit.cshtml", model];
       };
       Patch["/stylist/edit/{id}"] = parameters => {
         Stylist SelectedStylist = Stylist.Find(parameters.id);
         SelectedStylist.Update(Request.Form["stylist-name"]);

         return View["success.cshtml"];
       };
       Get["/stylist/delete/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         Stylist SelectedStylist = Stylist.Find(parameters.id);
         List<Client> StylistClients = SelectedStylist.GetClients();
         model.Add("stylist", SelectedStylist);
         model.Add("clients", StylistClients);
         return View["stylist_delete.cshtml", model];
       };
       Delete["/stylist/delete/{id}"] = parameters => {
         Stylist SelectedStylist = Stylist.Find(parameters.id);
         SelectedStylist.Delete();
         return View["success.cshtml"];
      };
    }
  }
}
