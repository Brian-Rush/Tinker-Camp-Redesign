using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tinker
{
  public class Children
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private int _age;
    private int _grade;
    private string _genderPronoun;
    private string _race;
    private string _address;
    private string _city;
    private string _state;
    private int _zip;
    private string _phone;

    public Children(string firstName, string lastName, int age, int grade, string genderPronoun, string race, string address, string city, string state, int zip, string phone, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _age = age;
      _grade = grade;
      _genderPronoun = genderPronoun;
      _race = race;
      _address = address;
      _city = city;
      _state = state;
      _zip = zip;
      _phone = phone;
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
    public string GetGender()
    {
      return _genderPronoun;
    }
    public string GetRace()
    {
      return _race;
    }
    public int GetAge()
    {
      return _age;
    }
    public int GetGrade()
    {
      return _grade;
    }

    public static List<Children> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Children_Object", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Children> allChildren = new List<Children>{};

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
        Children newChild = new Children(first, last, age, grade, gender, race, address, city, state, zip, phone, id);
        allChildren.Add(newChild);
      }

      if(conn != null)
      {
        conn.Close();
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return allChildren;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Children_Object (First, Last, Age, Grade, Gender, Race, Address, City, State, Zip, Phone) OUTPUT INSERTED.id VALUES (@first, @second, @age, @grade, @gender, @race, @address, @city, @state, @zip, @phone);", conn);

      SqlParameter firstNameParameters = new SqlParameter("@first", this.GetFirstName());
      cmd.Parameters.Add(firstNameParameters);

      SqlParameter lastNameParameters = new SqlParameter("@second", this.GetLastName());
      cmd.Parameters.Add(lastNameParameters);

      SqlParameter ageParameters = new SqlParameter("@age", this.GetAge());
      cmd.Parameters.Add(ageParameters);

      SqlParameter gradeParameters = new SqlParameter("@grade", this.GetGrade());
      cmd.Parameters.Add(gradeParameters);

      SqlParameter genderParameters = new SqlParameter("@gender", this.GetGender());
      cmd.Parameters.Add(genderParameters);

      SqlParameter raceParameters = new SqlParameter("@race", this.GetRace());
      cmd.Parameters.Add(raceParameters);

      SqlParameter addressParameters = new SqlParameter("@address", this.GetAddress());
      cmd.Parameters.Add(addressParameters);

      SqlParameter cityParameters = new SqlParameter("@city", this.GetCity());
      cmd.Parameters.Add(cityParameters);

      SqlParameter stateParameters = new SqlParameter("@state", this.GetState());
      cmd.Parameters.Add(stateParameters);

      SqlParameter zipParameters = new SqlParameter("@zip", this.GetZip());
      cmd.Parameters.Add(zipParameters);

      SqlParameter phoneParameters = new SqlParameter("@phone", this.GetPhone());
      cmd.Parameters.Add(phoneParameters);

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

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM Children_Object", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
