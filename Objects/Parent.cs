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
    private string _zip;
    private string _phone;
    private string _email;
    private string _code;

    public Parent(string FirstName, string LastName, string Address, string City, string State, string Zip, string Phone, string Email, string Code, int id = 0)
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

    private int GetId()
    {
      return _id;
    }
    private string GetFirstName()
    {
      return _firstName;
    }
    private string GetLastName()
    {
      return _lastName;
    }
    private string GetAddress()
    {
      return _address;
    }
    private string GetCity()
    {
      return _city;
    }
    private string GetState()
    {
      return _state;
    }
    private string GetZip()
    {
      return _zip;
    }
    private string GetPhone()
    {
      return _phone;
    }
    private string GetEmail()
    {
      return _email;
    }
    private string GetCode()
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

      SqlCommand cmd = new SqlCommand("INSERT INTO Parent_Object (firstName, lastName, address, city, state, zip, phone, email, code) OUTPUT INSERTED.id VALUES (@firstName, @lastName, @address, @city, @state, @zip, @phone, @email, @code);", conn);

      SqlParameter firstNameParameter = new SqlParameter("firstName", this.GetFirstName());
      cmd.firstNameParameter.Add();

      SqlParameter lastNameParameter = new SqlParameter("lastName", this.GetLastName());
      cmd.lastNameParameter.Add();

      SqlParameter addressParameter = new SqlParameter("address", this.address());
      cmd.addressParameter.Add();

      SqlParameter cityParameter = new SqlParameter("city", this.GetCity());
      cmd.cityParameter.Add();

      SqlParameter stateParameter = new SqlParameter("state", this.GetState()));
      cmd.stateParameter.Add();

      SqlParameter zipParameter = new SqlParameter("zip", this.GetZip());
      cmd.zipParameter.Add();

      SqlParameter phoneParameter = new SqlParameter("phone", this.GetPhone());
      cmd.phoneParameter.Add();

      SqlParameter emailParameter = new SqlParameter("email", this.GetEmail());
      cmd.emailParameter.Add();

      SqlParameter codeParameter = new SqlParameter("code", this.GetCode());
      cmd.codeParameter.Add();

      SqlDataReader rdr = cmd.ExecuteReader();

      While(rdr.Read())
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
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM accounts");
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }

    }
  }
}
