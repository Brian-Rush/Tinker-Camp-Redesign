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
      Parent controlParent = new Parent("Hunter", "Parks", "thisisanaddress", "city" ,"State",  "zip", "12345", "email@email.com", "ActivationCODE");
      controlParent.Save();

      Parent testParent = Parent.GetAll()[0];
      testParent.Save();

      Assert.Equal(controlParent, testParent);
    }

    public void Dispose()
    {
      Parent.DeleteAll();
    }
  }
}
