using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tinker
{
  public class Parent
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _address;
    private string _city;
    private string _state;
    private int _zip;
    private string _phone;
    private string _email;
    private string _code;

    public Parent(string FirstName, string LastName, string Address, string City, string State, int Zip, string Phone, string Email, string Code, int id = 0)
    {
      _id = id;
      _firstName = FirstName;
      _lastName = LastName;
      _address = Address;
      _city = City;
      _state = State;
      _zip = Zip;
      _phone = Phone;
      _email = Email;
      _code = Code;
    }

    public int  d()
    {
      return _id;
    }
    public string GetFirstName()
    {
      return _firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public string GetAddress()
    {
      return _address;
    }
    public string GetCity()
    {
      return _city;
    }
    public string GetState()
    {
      return _state;
    }
    public int GetZip()
    {
      return _zip;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public string GetEmail()
    {
      return _email;
    }
    public string GetCode()
    {
      return _code;
    }

    public override bool Equals(System.Object otherParent)
    {
      if(!(otherParent is Parent))
      {
        return false;
      }
      else
      {
        Parent newParent = (Parent) otherParent;
        bool firstNameEquality = this.GetFirstName() == newParent.GetFirstName();
        bool lastNameEquality = this.GetLastName() == newParent.GetLastName();
        bool idEquality = this.GetId() == newParent.GetId();
        bool addressEquality = this.GetAddress() == newParent.GetAddress();
        bool cityEquality = this.GetCity() == newParent.GetCity();
        bool stateEqualty = this.GetState() == newParent.GetState();
        bool zipEquality = this.GetZip() == newParent.GetZip();
        bool emailEquality = this.GetEmail() == newParent.GetEmail();
        bool codeEquality = this.GetCode() == newParent.GetCode();
        bool phoneEquality = this.GetPhone() == newParent.GetPhone();
        return (firstNameEquality && lastNameEquality && idEquality && addressEquality && cityEquality && stateEqualty && zipEquality && phoneEquality && codeEquality && phoneEquality);
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Parent_Object (First, Last, Address, City, State, Zip, Phone, Email, Code) OUTPUT INSERTED.id VALUES (@firstName, @lastName, @address, @city, @state, @zip, @phone, @email, @code);", conn);

      SqlParameter firstNameParameter = new SqlParameter("@firstName", this.GetFirstName());
      cmd.Parameters.Add(firstNameParameter);

      SqlParameter lastNameParameter = new SqlParameter("@lastName", this.GetLastName());
      cmd.Parameters.Add(lastNameParameter);

      SqlParameter addressParameter = new SqlParameter("@address", this.GetAddress());
      cmd.Parameters.Add(addressParameter);

      SqlParameter cityParameter = new SqlParameter("@city", this.GetCity());
      cmd.Parameters.Add(cityParameter);

      SqlParameter stateParameter = new SqlParameter("@state", this.GetState());
      cmd.Parameters.Add(stateParameter);

      SqlParameter zipParameter = new SqlParameter("@zip", this.GetZip());
      cmd.Parameters.Add(zipParameter);

      SqlParameter phoneParameter = new SqlParameter("@phone", this.GetPhone());
      cmd.Parameters.Add(phoneParameter);

      SqlParameter emailParameter = new SqlParameter("@email", this.GetEmail());
      cmd.Parameters.Add(emailParameter);

      SqlParameter codeParameter = new SqlParameter("@code", this.GetCode());
      cmd.Parameters.Add(codeParameter);

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

    public static List<Parent> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Parent_Object", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Parent> listOfParents = new List<Parent>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string firstName = rdr.GetString(1);
        string lastName = rdr.GetString(2);
        string address = rdr.GetString(3);
        string city = rdr.GetString(4);
        string state = rdr.GetString(5);
        int zip = rdr.GetInt32(6);
        string phone = rdr.GetString(7);
        string email = rdr.GetString(8);
        string code = rdr.GetString(9);
        Parent newParent = new Parent(firstName, lastName, address, city, state, zip, phone, email, code, id);
        listOfParents.Add(newParent);
      }

      if(conn != null)
      {
        conn.Close();
      }
      return listOfParents;
    }

    public static Parent Find(int findId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Parent_Object WHERE id = @id", conn);
      SqlParameter idParam = new SqlParameter("@id", findId);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string firstName = null;
      string lastName = null;
      string address = null;
      string city = null;
      string state = null;
      int zip = 0;
      string phone = null;
      string email = null;
      string code = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        address = rdr.GetString(3);
        city = rdr.GetString(4);
        state = rdr.GetString(5);
        zip = rdr.GetInt32(6);
        phone = rdr.GetString(7);
        email = rdr.GetString(8);
        code = rdr.GetString(9);
      }

      Parent newParent = new Parent(firstName, lastName, address, city, state, zip, phone, email, code, id);

      if(conn != null)
      {
        conn.Close();

      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return newParent;

    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM Parent_Object", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }

    }
  }
}
