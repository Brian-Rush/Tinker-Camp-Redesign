using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Session.Objects
{
  public class Session
  {
    private int _id;
    private string _name;

    public Session(int id, string name)
    {
      _id = id;
      _name = name;
    }

    private int GetId()
    {
      return _id;
    }

    private string GetName()
    {
      return _name;
    }
  }
}
