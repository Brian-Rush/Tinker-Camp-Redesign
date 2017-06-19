using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class ChildrenTest : IDisposable
  {
    public ChildrenTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void CheckForDouble_Children_Children()
    {
      Children controlChildren = new Children("Hunter", "Parks", 8, 5, "male" , "native american",  "thisisanaddress", "city", "State",  12345, "12345");
      controlChildren.Save();

      List<Children> testChildren = Children.GetAll();
      testChildren[0].Save();

      Assert.Equal(controlChildren.GetFirstName(), testChildren[0].GetFirstName());
    }
    // [Fact]
    // public void FindChildren_FindsChildrenInDataBase_True()
    // {
    //   Children testChildren = new Children("Hunter", "Parks", 8, "male","native american" "thisisanaddress", "city" ,"State",  12345, "12345");
    //   testChildren.Save();
    //   Children newChildren = new Children("Hunter", "Parks", 8, "male","native american" "thisisanaddress", "city" ,"State",  12345, "12345");
    //   newChildren.Save();
    //
    //   Children allChildren = Children.Find(testChildren.GetId());
    //   Assert.Equal(testChildren, allChildren);
    // }

    public void Dispose()
    {
      Children.DeleteAll();
    }
  }
}
