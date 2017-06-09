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
      bool stylistEquality = this.GetStylistId()== newClient.GetStylistId();
      return (idEquality && nameEquality && stylistEquality);
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

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client>{};

      SqlConnection conn =DB.Connection();
      conn.Open();

      SqlCommand cmd =new SqlCommand("SELECT * FROM client;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        int clientStylistId = rdr. GetInt32(2);
        Client newClient = new Client(clientName,clientStylistId, clientId);
        allClients.Add(newClient);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allClients;

    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO client (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName,@ClientStylistId);", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@ClientName";
      nameParameter.Value = this.GetName();

      SqlParameter stylistIdParameter = new SqlParameter();
      stylistIdParameter.ParameterName = "@ClientStylistId";
      stylistIdParameter.Value = this.GetStylistId();

      cmd.Parameters.Add(nameParameter);
      cmd.Parameters.Add(stylistIdParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static void DeleteAll()
      {
        SqlConnection conn = DB.Connection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM client;", conn);
        cmd.ExecuteNonQuery();
        conn.Close();
      }
    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM client WHERE id = @ClientId;", conn);
      SqlParameter clientIdParameter = new SqlParameter();
      clientIdParameter.ParameterName = "@ClientId";
      clientIdParameter.Value = id.ToString();
      cmd.Parameters.Add(clientIdParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundClientlientId = 0;
      string foundClientlientName = null;
      int foundClientlientCuisineId = 0;

      while(rdr.Read())
      {
        foundClientlientId = rdr.GetInt32(0);
        foundClientlientName = rdr.GetString(1);
        foundClientlientCuisineId = rdr.GetInt32(2);
      }
      Client foundClientlient = new Client(foundClientlientName,foundClientlientCuisineId, foundClientlientId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return foundClientlient;
    }
  }
}
