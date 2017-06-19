using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Account.Objects
{
  public class Account
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

    public Account(string FirstName, string LastName, string Address, string City, string State, string Zip, string Phone, string email, string code, int id = 0)
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
    private string GetCode()
    {
      return _code;
    }
  }
}
