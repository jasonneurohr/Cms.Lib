using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cms.Lib
{
    public class SystemStatus : ISystemStatus
    {
        private readonly HttpClient _httpClient;
        private string _apiStatus = "/api/v1/system/status";
        private string _apiAlarmStatus = "/api/v1/system/alarms";
        private string _apiDatabaseStatus = "/api/v1/system/database";
        public string ApiUri { get; private set; }

        public SystemStatus(HttpClient client, string apiUri)
        {
            _httpClient = client;
            ApiUri = apiUri;
        }

        public async Task<SystemStatusResponse> Get()
        {
            var stringTask = await _httpClient.GetStringAsync(ApiUri + _apiStatus);

            SystemStatusResponse response = new SystemStatusResponse();

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(stringTask)))
            {
                var serialiser = new XmlSerializer(typeof(SystemStatusResponse));
                response = (SystemStatusResponse)serialiser.Deserialize(stream);
            }

            return response;
        }

        public async Task<SystemAlarStatusResponse> GetAlarmStatus()
        {
            var stringTask = await _httpClient.GetStringAsync(ApiUri + _apiAlarmStatus);

            SystemAlarStatusResponse response = new SystemAlarStatusResponse();

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(stringTask)))
            {
                var serialiser = new XmlSerializer(typeof(SystemAlarStatusResponse));
                response = (SystemAlarStatusResponse)serialiser.Deserialize(stream);
            }

            return response;
        }

        public async Task<SystemDatabaseStatusResponse> GetDatabaseStatus()
        {
            var stringTask = await _httpClient.GetStringAsync(ApiUri + _apiDatabaseStatus);

            SystemDatabaseStatusResponse response = new SystemDatabaseStatusResponse();

            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(stringTask)))
            {
                var serialiser = new XmlSerializer(typeof(SystemDatabaseStatusResponse));
                response = (SystemDatabaseStatusResponse)serialiser.Deserialize(stream);
            }

            return response;
        }
    }
}