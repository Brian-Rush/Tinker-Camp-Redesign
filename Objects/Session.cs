using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tinker
{
  public class Workshop
  {
    private int _id;
    private string _name;

    public Workshop(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }

    public static List<Workshop> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Session_Object", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Workshop> allWorkshop = new List<Workshop>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        Workshop newWorkshop = new Workshop(name, id);
        allWorkshop.Add(newWorkshop);
      }

      if(conn != null)
      {
        conn.Close();
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return allWorkshop;
    }


    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Session_Object (name) OUTPUT INSERTED.id VALUES (@name);", conn);

      SqlParameter firstNameParameters = new SqlParameter("@name", this.GetName());
      cmd.Parameters.Add(firstNameParameters);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static Workshop Find(string findName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Session_Object WHERE name = @name", conn);
      SqlParameter idParam = new SqlParameter("@name", findName);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string name = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }

      Workshop newWorkshop = new Workshop(name, id);

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return newWorkshop;
    }

    public void AddChild(Child newChild)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Child_Sessions (child_id, session_id) VALUES (@child_id, @session_id); ", conn);

      SqlParameter childParameter = new SqlParameter("@child_id", newChild.GetId());
      cmd.Parameters.Add(childParameter);

      SqlParameter sessionParameter = new SqlParameter("@session_id", this.GetId());
      cmd.Parameters.Add(sessionParameter);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

    public List<Child> ListEnrolled()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT Child_Object.* FROM Session_Object JOIN Child_Sessions ON (Session_Object.id = Child_Sessions.session_id) JOIN Child_Object ON (Child_Object.id = Child_Sessions.child_id) WHERE Session_Object.id = @session_id", conn);
      SqlParameter joinTableParameter = new SqlParameter("@session_id", this.GetId());
      cmd.Parameters.Add(joinTableParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Child> allChildren = new List<Child>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string first = rdr.GetString(1);
        string last = rdr.GetString(2);
        string age = rdr.GetString(3);
        string grade = rdr.GetString(4);
        string gender = rdr.GetString(5);
        string race = rdr.GetString(6);
        string address = rdr.GetString(7);
        string city = rdr.GetString(8);
        string state = rdr.GetString(9);
        string zip = rdr.GetString(10);
        string phone = rdr.GetString(11);
        Child newChild = new Child(first, last, age, grade, gender, race, address, city, state, zip, phone, id);
        allChildren.Add(newChild);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allChildren;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM Session_Object", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
