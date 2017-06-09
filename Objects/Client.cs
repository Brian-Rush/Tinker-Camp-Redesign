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

    public Restaurant(string Name, int StylistId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _cuisineId = StylistId;
    }

    public override bool Equals(System.Object otherRestaurant)
    {
    if (!(otherRestaurant is Restaurant))
    {
      return false;
    }
    else
    {
      Restaurant newRestaurant = (Restaurant) otherRestaurant;
      bool idEquality = (this.GetId() == newRestaurant.GetId());
      bool nameEquality = (this.GetName() == newRestaurant.GetName());
      bool cuisineEquality = this.GetStylistId()== newRestaurant.GetStylistId();
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
      return _cuisineId;
    }
    public void SetStylistId(int newStylistId)
    {
      _cuisineId = newStylistId;
    }


  }
}
