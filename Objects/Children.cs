using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Children.Objects
{
  public class Children
  {
    private string _firstName;
    private string _lastName;
    private int _age;
    private string _genderPronoun;
    private string _race;
    private string _address;
    private string _city;
    private int _zip;
    private string _phone;

    public Children(string firstName, string lastName, int age, string genderPronoun, string race, string address, string city, int zip, string phone)
    {
       _firstName = firstName;
       _lastName = lastName;
       _age = age;
       _genderPronoun = genderPronoun;
       _race = race;
       _address = address;
       _city = city;
       _zip = zip;
       _phone = phone;
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
    private string GetGender()
    {
      return _genderPronoun;
    }
    private string GetRace()
    {
      return _race;
    }
    private int GetAge()
    {
      return _age;
    }
  }
}
