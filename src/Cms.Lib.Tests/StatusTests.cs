using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xunit;

namespace Cms.Lib.Tests
{
    public class StatusTests
    {
        [Fact]
        public void GetSystemStatusTest()
        {
            // Arrange

            var requestUri = new Uri("https://localhost:445/api/v1/system/status");

            SystemStatusResponse response = new SystemStatusResponse
            {
                SoftwareVersion = "2.5.1"
            };

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(SystemStatusResponse));

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(sb, writerSettings);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, response, ns);


            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(sb.ToString()) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            HttpClient client = new HttpClient(mockHandler.Object);
            SystemStatus systemStatus = new SystemStatus(client, "https://localhost:445");

            // Act

            var systemStatusResult = systemStatus.Get().Result;

            // Assert

            Assert.True(systemStatusResult.SoftwareVersion == "2.5.1");
        }

        [Fact]
        public void GetSystemAlarmsTest()
        {
            // Arrange

            var requestUri = new Uri("https://localhost:445/api/v1/system/alarms");

            SystemAlarStatusResponse response = new SystemAlarStatusResponse
            {
                Total = "0"
            };

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(SystemAlarStatusResponse));

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(sb, writerSettings);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, response, ns);


            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(sb.ToString()) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            HttpClient client = new HttpClient(mockHandler.Object);
            SystemStatus systemStatus = new SystemStatus(client, "https://localhost:445");

            // Act

            var systemAlarmStatus = systemStatus.GetAlarmStatus().Result;

            // Assert

            Assert.True(systemAlarmStatus.Total == "0");
        }

        [Fact]
        public void GetSystemDatabaseStatusTest()
        {
            // Arrange

            var requestUri = new Uri("https://localhost:445/api/v1/system/database");

            SystemDatabaseStatusResponse response = new SystemDatabaseStatusResponse
            {
                Clustered ="enabled"
            };

            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(SystemDatabaseStatusResponse));

            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(sb, writerSettings);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, response, ns);


            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(sb.ToString()) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            HttpClient client = new HttpClient(mockHandler.Object);
            SystemStatus systemStatus = new SystemStatus(client, "https://localhost:445");

            // Act

            var systemDatabaseStatus = systemStatus.GetDatabaseStatus().Result;

            // Assert

            Assert.True(systemDatabaseStatus.Clustered == "enabled");
        }
    }
}
