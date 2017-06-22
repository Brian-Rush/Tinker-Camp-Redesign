using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class ChildTest : IDisposable
  {
    public ChildTest()
    {
      DBConfiguration.ConnectionString  = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void CheckForDouble_Child_Child()
    {
      Child controlChild = new Child("Hunter", "Parks", "8", "5", "male" , "native american",  "thisisanaddress", "city", "State",  "12345", "12345");
      controlChild.Save();

      List<Child> testChild = Child.GetAll();
      testChild[0].Save();

      Assert.Equal(controlChild.GetFirstName(), testChild[0].GetFirstName());
    }
    [Fact]
    public void FindChild_FindsChildInDataBase_True()
    {
      Child testChild = new Child("Hunter", "Parks", "8", "5", "male", "native american", "thisisanaddress", "city" ,"State",  "12345", "12345");
      testChild.Save();
      Child newChild = new Child("Hunter", "Parks", "8", "5", "male", "native american", "thisisanaddress", "city" ,"State",  "12345", "12345");
      newChild.Save();

      Child allChild = Child.Find(testChild.GetId());
      Assert.Equal(testChild.GetFirstName(), allChild.GetFirstName());
    }

    [Fact]
    public void UpdateChild_UpdatesChildFirstName_True()
    {
      Child testChild = new Child("Hunter", "Parks", "8", "5", "male", "native american", "thisisanaddress", "city" ,"State", "12345", "12345");
      testChild.Save();

      testChild.Update("James", "Parks", "8", "5", "male", "native american", "thisisanaddress", "city" ,"State",  "12345", "12345");

      Child whatChild = Child.GetAll()[0];

      Assert.Equal("James", whatChild.GetFirstName());
    }

    public void Dispose()
    {
      Child.DeleteAll();
    }
  }
}
