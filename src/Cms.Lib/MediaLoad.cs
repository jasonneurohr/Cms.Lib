using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cms.Lib
{
    public class MediaLoad : IMediaLoad
    {
        private readonly HttpClient _httpClient;
        private string _apiMediaLoad = "/api/v1/system/load";
        public string ApiUri { get; private set; }

        public MediaLoad(HttpClient client, string apiUri)
        {
            _httpClient = client;
            ApiUri = apiUri;
        }

        public async Task<int> Get()
        {
            var stringTask = await _httpClient.GetStringAsync(ApiUri + _apiMediaLoad);

            MediaLoadResponse mediaLoadResponse = new MediaLoadResponse();

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(stringTask)))
            {
                var serialiser = new XmlSerializer(typeof(MediaLoadResponse));
                mediaLoadResponse = (MediaLoadResponse)serialiser.Deserialize(stream);
            }
            
            return mediaLoadResponse.MediaProcessingLoad;
        }
    }
}
