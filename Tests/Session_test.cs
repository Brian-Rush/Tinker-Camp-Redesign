using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class TestTest : IDisposable
  {
    public TestTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void FindTest_FindsTestInDataBase_True()
    {
      Test newTest = new Test("Miniature World");
      newTest.Save();

      Test testTest = Test.Find(newTest.GetId());

      Assert.Equal("Miniature World", testTest.GetName());
    }

    [Fact]
    public void AddTest_AddChildToTests_True()
    {
      Child newChild = new Child("Hunter", "Parks", 8, 5, "male" , "native american",  "thisisanaddress", "city", "State",  12345, "12345");
      newChild.Save();

      Test findTest = new Test("Miniature World", 1);
      findTest.Save();

      Test testTest = Test.Find(findTest.GetId());
      Console.WriteLine(testTest.GetName());

      testTest.AddChild(newChild);

      List<Child> allChildrenEnrolled = testTest.ListEnrolled();
      List<Child> controlChildren = new List<Child>{newChild};

      Assert.Equal(controlChildren[0].GetFirstName(), allChildrenEnrolled[0].GetFirstName());
    }

    public void Dispose()
    {
      Test.DeleteAll();
    }
  }

}
