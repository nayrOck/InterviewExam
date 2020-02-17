
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using opg_201910_interview.Controllers;
using opg_201910_interview.Models;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{

    public class UnitTest1
    {

        [Fact]
        public void IndexAction()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void IndexAction_ReturnViewWithList()
        {
            var hostingMock = new Mock<IHostingEnvironment>();
            hostingMock.Object.ApplicationName = "opg-201910-interview";
            //hostingMock.Object.ContentRootFileProvider = {Microsoft.Extensions.FileProviders.PhysicalFileProvider};
            hostingMock.Object.ContentRootPath = @"C:\Users\rb\Documents\Ryan\ASP.NetCore\FlexisourceIT_DotnetCoreExam\opg-201910Base-master\opg-201910Base-master\";
            hostingMock.Object.EnvironmentName = "Development";
            hostingMock.Object.WebRootPath = @"C:\Users\rb\Documents\Ryan\ASP.NetCore\FlexisourceIT_DotnetCoreExam\opg-201910Base-master\opg-201910Base-master\wwwroot\";

            // Arrange
            var controller = new HomeController(hostingMock.Object);

            // Act
            var result = controller.Index(new Client { ClientList = ClientList.ClientA }) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestJsonConverter()
        {
            var client = new Client();
            var iFile = new ImportUtility();
            var test = new { Client = "ClientA", Id = "1001", FileName = "blaze-2018-05-01", FileDirectoryPath = "C:\\Users\\rb\\Desktop\\FlexisourceIT_DotnetCoreExam\\opg-201910Base-master\\opg-201910Base-master\\UploadFiles\\ClientA", FileDate = "2018-05-01" };
            string expected = Resource1.JsonText;

            string result = iFile.ConvertToJSON(test);
            Assert.True(result == expected);
        }

        [Fact]
        public void ReadXMLFile()
        {
            // Arrange
            string contentRootPath = @"C:\Users\rb\Documents\Ryan\ASP.NetCore\FlexisourceIT_DotnetCoreExam\opg-201910Base-master\opg-201910Base-master\";
            var iFile = new ImportUtility();

            // Act
            var clientFiles = iFile.ReadXMLFile(contentRootPath, ClientList.ClientA.ToString());

            int filesCount = clientFiles.Count();

            // Assert
            Assert.True(filesCount == 6);
        }

      

    }



}
