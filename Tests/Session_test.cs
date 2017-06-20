using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class SessionTest : IDisposable
  {
    public SessionTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void FindSession_FindsSessionInDataBase_True()
    {
      Session newSession = Session.Find(6);

      Assert.Equal("Miniature World", newSession.GetName());
    }

    [Fact]
    public void AddSession_AddsSessionToChild_True()
    {
      Child newChild = new Child("Hunter", "Parks", 8, 5, "male" , "native american",  "thisisanaddress", "city", "State",  12345, "12345");
      newChild.Save();

      Session findSession = Session.Find(5);
      Console.WriteLine(findSession.GetName());
      Console.WriteLine("TEST");

      findSession.AddChild(Child.Find(newChild.GetId()));

      List<Child> allChildrenEnrolled = findSession.ListEnrolled();
      List<Child> controlChildren = new List<Child>{newChild};

      Assert.Equal(controlChildren, allChildrenEnrolled);
    }

    public void Dispose()
    {
      Session.DeleteAll();
    }
  }

}
