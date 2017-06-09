using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Salon.Objects
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylistId;

    public Client(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _stylistId = StylistId;
    }

    public override bool Equals(System.Object otherClient)
    {
    if (!(otherClient is Client))
    {
      return false;
    }
    else
    {
      Client newClient = (Client) otherClient;
      bool idEquality = (this.GetId() == newClient.GetId());
      bool nameEquality = (this.GetName() == newClient.GetName());
      bool cuisineEquality = this.GetStylistId()== newClient.GetStylistId();
      return (idEquality && nameEquality && cuisineEquality);
    }
  }


    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetStylistId()
    {
      return _stylistId;
    }
    public void SetStylistId(int newStylistId)
    {
      _stylistId = newStylistId;
    }


  }
}
