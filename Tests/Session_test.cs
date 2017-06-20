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
      Session newSession = new Session("Miniature World");
      newSession.Save();

      Session testSession = Session.Find(newSession.GetId());

      Assert.Equal("Miniature World", testSession.GetName());
    }

    [Fact]
    public void AddSession_AddChildToSessions_True()
    {
      Child newChild = new Child("Hunter", "Parks", 8, 5, "male" , "native american",  "thisisanaddress", "city", "State",  12345, "12345");
      newChild.Save();

      Session findSession = new Session("Miniature World", 1);
      findSession.Save();

      Session testSession = Session.Find(findSession.GetId());
      Console.WriteLine(testSession.GetName());

      testSession.AddChild(newChild);

      List<Child> allChildrenEnrolled = testSession.ListEnrolled();
      List<Child> controlChildren = new List<Child>{newChild};

      Assert.Equal(controlChildren[0].GetFirstName(), allChildrenEnrolled[0].GetFirstName());
    }

    public void Dispose()
    {
      Session.DeleteAll();
    }
  }

}
