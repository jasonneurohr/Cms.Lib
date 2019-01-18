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
    public class MediaLoadTests
    {
        /// <summary>
        /// Test the Get() method in the MediaLoad class with a mocked API response.
        /// </summary>
        /// <remarks>
        /// Example XML response from the CMS API:
        /// <?xml version="1.0"?><load><mediaProcessingLoad>151975</mediaProcessingLoad></load>
        /// </remarks>
        [Fact]
        public void GetMediaLoadTest()
        {
            // Arrange

            // The URI for the test
            var requestUri = new Uri("https://localhost:445/api/v1/system/load");

            // Setup the dummy response
            MediaLoadResponse mediaLoadResponse = new MediaLoadResponse
            {
                MediaProcessingLoad = 10
            };

            // Setup serializer
            XmlSerializer serializer = new XmlSerializer(typeof(MediaLoadResponse));

            // Setup stringbuilder
            StringBuilder sb = new StringBuilder();

            // Setup xmlwriter settings
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            // removes the - encoding="utf-16"
            writerSettings.OmitXmlDeclaration = true;

            // Setup xmlwriter
            XmlWriter writer = XmlWriter.Create(sb, writerSettings);

            // Remove the namespace
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            // Serialise
            serializer.Serialize(writer, mediaLoadResponse, ns);

            // Set up the mock with the expected response
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(sb.ToString()) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            // Set up the HttpClient using the mock handler object
            HttpClient client = new HttpClient(mockHandler.Object);

            // Initialise an instance of the MediaLoad class for testing using the HttpClient
            MediaLoad mediaLoad = new MediaLoad(client, "https://localhost:445");

            // Act

            var mediaLoadResult = mediaLoad.Get().Result;

            // Assert

            Assert.True(mediaLoadResult == 10);
        }
    }
}
