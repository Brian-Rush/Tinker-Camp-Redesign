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

    public int GetId()
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
    public string GetZip()
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
        string zip = rdr.GetString(6);
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
      string zip = null;
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
        zip = rdr.GetString(6);
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

    public static Parent GetParent(string last, string first)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Parent_Object WHERE (Last = @LastName, First = @firstName); ", conn);
      SqlParameter idParam = new SqlParameter("@LastName", last);
      cmd.Parameters.Add(idParam);
      SqlParameter firstParam = new SqlParameter("@firstName", last);
      cmd.Parameters.Add(firstParam);
      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string firstName = null;
      string lastName = null;
      string address = null;
      string city = null;
      string state = null;
      string zip = null;
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
        zip = rdr.GetString(6);
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

    // PLEASE READ BEFORE USING UPDATE!!!!!!!!!!!!!!!!!!!
    //
    //  ORIGINAL VARIABLE !!!WILL NOT CHANGE!!!! YOU WILL NEED
    //  TO PULL THE ORIGINAL CHILD INFORMATION BACK OUT OF
    //  THE DATABASE IN ORDER TO UPDATE CURRENT INFORMATION
    //
    public void Update(string FirstName, string LastName, string Address, string City, string State, string Zip, string Phone, string Email, string Code)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE Parent_Object SET First = @newFirstName, Last = @newLastName, Address = @newAddress, City = @newCity, State = @newState, Zip = @newZip, Phone = @newPhone, Email = @newEmail, Code = @newCode WHERE id = @id", conn);

      SqlParameter newFirstName = new SqlParameter("@newFirstName", FirstName);
      cmd.Parameters.Add(newFirstName);

      SqlParameter newLastName = new SqlParameter("@newLastName", LastName);
      cmd.Parameters.Add(newLastName);

      SqlParameter newAddress = new SqlParameter("@newAddress", Address);
      cmd.Parameters.Add(newAddress);

      SqlParameter newCity = new SqlParameter("@newCity", City);
      cmd.Parameters.Add(newCity);

      SqlParameter newState = new SqlParameter("@newState", State);
      cmd.Parameters.Add(newState);

      SqlParameter newZip = new SqlParameter("@newZip", Zip);
      cmd.Parameters.Add(newZip);

      SqlParameter newPhone = new SqlParameter("@newPhone", Phone);
      cmd.Parameters.Add(newPhone);

      SqlParameter newEmail = new SqlParameter("@newEmail", Email);
      cmd.Parameters.Add(newEmail);

      SqlParameter newCode = new SqlParameter("@newCode", Code);
      cmd.Parameters.Add(newCode);

      SqlParameter oldId = new SqlParameter("@id", this.GetId());
      cmd.Parameters.Add(oldId);


      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
        this._firstName = rdr.GetString(1);
        this._lastName = rdr.GetString(2);
        this._address = rdr.GetString(3);
        this._city = rdr.GetString(4);
        this._state = rdr.GetString(5);
        this._zip = rdr.GetString(6);
        this._phone = rdr.GetString(7);
        this._email = rdr.GetString(8);
        this._code = rdr.GetString(9);
      }

      if(rdr != null)
      {
        rdr.Close();
      }

      if (conn != null)
      {
        conn.Close();
      }
    }

    public void AddChildToParent(Child newChild)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Parent_Child (parent_id, child_id) VALUES (@parent_id, @child_id); ", conn);

      SqlParameter ParentParameter = new SqlParameter("@parent_id", this.GetId());
      cmd.Parameters.Add(ParentParameter);

      SqlParameter childParameter = new SqlParameter("@child_id", newChild.GetId());
      cmd.Parameters.Add(childParameter);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
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

    public void Delete(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM Parent_Object WHERE id = @id; DELETE FROM Parent_Child WHERE parent_id = @id", conn);

      SqlParameter idParam = new SqlParameter("@Id", this.GetId());
      cmd.Parameters.Add(idParam);

      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }

    }
  }
}
