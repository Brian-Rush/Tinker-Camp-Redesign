using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tinker
{
  public class Session
  {
    private int _id;
    private string _name;

    public Session(string name, int id = 0)
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

    public static Session Find(int findId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Session_Object WHERE id = @id", conn);
      SqlParameter idParam = new SqlParameter("@id", findId);
      cmd.Parameters.Add(idParam);


      int id = 0;
      string name = null;

      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
      }

      Session newSession = new Session(name, id);

      if(conn != null)
      {
        conn.Close();

      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return newSession;
    }

    public void AddChild(Child newChild)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Child_Sessions (child_id, session_id) VALUES (@child_id, @session_id);", conn);

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
        int age = rdr.GetInt32(3);
        int grade = rdr.GetInt32(4);
        string gender = rdr.GetString(5);
        string race = rdr.GetString(6);
        string address = rdr.GetString(7);
        string city = rdr.GetString(8);
        string state = rdr.GetString(9);
        int zip = rdr.GetInt32(10);
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
