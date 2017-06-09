using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using Salong.Objects;

namespace Salon
{
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
        DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=client_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueIfNameAreTheSame()
    {
      //Arrange, Act
      Client firstClient = new Client("Manny", 1);
      Client secondClient = new Client("Manny", 1);

      //Assert
      Assert.Equal(firstClient, secondClient);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      //Arrange
      Client testClient = new Client("Manny",1);

      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToObject()
    {
      //Arrange
      Client testClient = new Client("James",1);

      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsClientInDatabase()
    {
      //Arrange
      Client testClient = new Client("Manny",1);
      testClient.Save();

      //Act
      Client foundClient = Client.Find(testClient.GetId());

      //Assert
      Assert.Equal(testClient, foundClient);
    }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
