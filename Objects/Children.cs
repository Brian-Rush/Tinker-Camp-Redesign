using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tinker
{
  public class Child
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private int _age;
    private int _grade;
    private string _gender;
    private string _race;
    private string _address;
    private string _city;
    private string _state;
    private int _zip;
    private string _phone;

    public Child(string firstName, string lastName, int age, int grade, string genderPronoun, string race, string address, string city, string state, int zip, string phone, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;
      _age = age;
      _grade = grade;
      _gender = genderPronoun;
      _race = race;
      _address = address;
      _city = city;
      _state = state;
      _zip = zip;
      _phone = phone;
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
      return _gender;
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

    public static List<Child> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Child_Object", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Child> allChild = new List<Child>{};

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
        allChild.Add(newChild);
      }

      if(conn != null)
      {
        conn.Close();
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return allChild;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO Child_Object (First, Last, Age, Grade, Gender, Race, Address, City, State, Zip, Phone) OUTPUT INSERTED.id VALUES (@first, @second, @age, @grade, @gender, @race, @address, @city, @state, @zip, @phone);", conn);

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

    // PLEASE READ BEFORE USING UPDATE!!!!!!!!!!!!!!!!!!!
    //
    //  ORIGINAL VARIABLE !!!WILL NOT CHANGE!!!! YOU WILL NEED
    //  TO PULL THE ORIGINAL CHILD INFORMATION BACK OUT OF
    //  THE DATABASE IN ORDER TO UPDATE CURRENT INFORMATION
    //
    public void Update(string FirstName, string LastName, int Age, int Grade, string Gender, string Race, string Address, string City, string State, int Zip, string Phone)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE Child_Object SET First = @newFirstName, Last = @newLastName, Age = @newAge, Grade = @newGrade, Gender = @newGender, Race = @newRace, Address = @newAddress, City = @newCity, State = @newState, Zip = @newZip, Phone = @newPhone WHERE id = @id", conn);

      SqlParameter newFirstName = new SqlParameter("@newFirstName", FirstName);
      cmd.Parameters.Add(newFirstName);

      SqlParameter newLastName = new SqlParameter("@newLastName", LastName);
      cmd.Parameters.Add(newLastName);

      SqlParameter newAge = new SqlParameter("@newAge", Age);
      cmd.Parameters.Add(newAge);

      SqlParameter newGrade = new SqlParameter("@newGrade", Grade);
      cmd.Parameters.Add(newGrade);

      SqlParameter newGender = new SqlParameter("@newGender", Gender);
      cmd.Parameters.Add(newGender);

      SqlParameter newRace = new SqlParameter("@newRace", Race);
      cmd.Parameters.Add(newRace);

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

      SqlParameter oldId = new SqlParameter("@id", this.GetId());
      cmd.Parameters.Add(oldId);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
        this._firstName = rdr.GetString(1);
        this._lastName = rdr.GetString(2);
        this._age = rdr.GetInt32(3);
        this._grade = rdr.GetInt32(4);
        this._gender = rdr.GetString(5);
        this._race = rdr.GetString(6);
        this._address = rdr.GetString(7);
        this._city = rdr.GetString(8);
        this._state = rdr.GetString(9);
        this._zip = rdr.GetInt32(10);
        this._phone = rdr.GetString(11);
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

    public static Child Find(int findId)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM Child_Object WHERE id = @id", conn);
      SqlParameter idParam = new SqlParameter("@id", findId);
      cmd.Parameters.Add(idParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string firstName = null;
      string lastName = null;
      int age = 0;
      int grade = 0;
      string gender = null;
      string race = null;
      string address = null;
      string city = null;
      string state = null;
      int zip = 0;
      string phone = null;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
        age = rdr.GetInt32(3);
        grade = rdr.GetInt32(4);
        gender = rdr.GetString(5);
        race = rdr.GetString(6);
        address = rdr.GetString(7);
        city = rdr.GetString(8);
        state = rdr.GetString(9);
        zip = rdr.GetInt32(10);
        phone = rdr.GetString(11);
      }

      Child newChild = new Child(firstName, lastName, age, grade, gender, race, address, city, state, zip, phone);

      if(conn != null)
      {
        conn.Close();

      }
      if(rdr != null)
      {
        rdr.Close();
      }
      return newChild;
    }

    public void Delete(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM Child_Object WHERE id = @id; DELETE FROM Parent_Child WHERE child_id = @id", conn);

      SqlParameter idParam = new SqlParameter("@id", this.GetId());
      cmd.Parameters.Add(idParam);

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

      SqlCommand cmd = new SqlCommand("DELETE FROM Child_Object", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
