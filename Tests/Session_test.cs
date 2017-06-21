using Xunit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tinker
{
  [Collection("Tinker")]
  public class WorkshopTest : IDisposable
  {
    public WorkshopTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=tinker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void FindWorkshop_FindsWorkshopInDataBase_True()
    {
      Workshop newWorkshop = new Workshop("Miniature World");
      newWorkshop.Save();

      Workshop testWorkshop = Workshop.Find(newWorkshop.GetId());

      Assert.Equal("Miniature World", testWorkshop.GetName());
    }

    [Fact]
    public void AddWorkshop_AddChildToWorkshops_True()
    {
      Child newChild = new Child("Hunter", "Parks", 8, 5, "male" , "native american",  "thisisanaddress", "city", "State",  12345, "12345");
      newChild.Save();

      Workshop findWorkshop = new Workshop("Miniature World", 1);
      findWorkshop.Save();

      Workshop testWorkshop = Workshop.Find(findWorkshop.GetId());
      Console.WriteLine(testWorkshop.GetName());

      testWorkshop.AddChild(newChild);

      List<Child> allChildrenEnrolled = testWorkshop.ListEnrolled();
      List<Child> controlChildren = new List<Child>{newChild};

      Assert.Equal(controlChildren[0].GetFirstName(), allChildrenEnrolled[0].GetFirstName());
    }

    public void Dispose()
    {
      Workshop.DeleteAll();
    }
  }

}
