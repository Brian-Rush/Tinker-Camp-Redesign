using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class ParentTest : IDisposable
  {
    public ParentTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void CheckForDouble_Parent_Parent()
    {
      Parent controlParent = new Parent("Hunter", "Parks", "thisisanaddress", "city" ,"State",  12345, "12345", "email@email.com", "ActivationCODE");
      controlParent.Save();

      List<Parent> testParent = Parent.GetAll();
      testParent[0].Save();

      Assert.Equal(controlParent.GetFirstName(), testParent[0].GetFirstName());
    }
    [Fact]
    public void FindParent_FindsParentInDataBase_True()
    {
      Parent testParent = new Parent("Hunter", "Parks", "thisisanaddress", "city" ,"State",  12345, "12345", "email@email.com", "ActivationCODE");
      testParent.Save();
      Parent newParent = new Parent("James", "Parks", "thisisanaddress", "city" ,"State",  12345, "12345", "email@email.com", "ActivationCODE");
      newParent.Save();

      Parent allParent = Parent.Find(testParent.GetId());
      Assert.Equal(testParent, allParent);
    }

    [Fact]
    public void UpdateParent_UpdatesParentFirstName_True()
    {
      Parent testParent = new Parent("Hunter", "Parks", "thisisanaddress", "city" ,"State",  12345, "12345", "email@email.com", "ActivationCODE");
      testParent.Save();

      testParent.Update("James", "Parks", "thisisanaddress", "city" ,"State",  12345, "12345", "email@email.com", "ActivationCODE");

      Parent whatParent = Parent.GetAll()[0];

      Assert.Equal("James", whatParent.GetFirstName());
    }

    public void Dispose()
    {
      Parent.DeleteAll();
    }
  }
}
