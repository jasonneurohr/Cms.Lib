using System;
using System.Net.Http;

namespace Cms.Lib
{
    public class CmsServer : ICmsServer
    {
        private string _apiUri;
        public string ApiPort { private get; set; }
        public string ApiUser { private get; set; }
        public string ApiPass { private get; set; }
        public string CmsAddress { private get; set; }
        public IMediaLoad MediaLoad { get; private set; }

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public CmsServer(string address, string apiPort, string apiUser, string apiPass)
        {
            ApiPort = apiPort ?? throw new ArgumentNullException(nameof(apiPass));
            ApiUser = apiUser ?? throw new ArgumentNullException(nameof(apiUser));
            ApiPass = apiPass ?? throw new ArgumentNullException(nameof(apiPass));
            CmsAddress = address ?? throw new ArgumentNullException(nameof(address));

            _apiUri = $"https://{CmsAddress}:{ApiPort}";

            _httpClientFactory = new HttpClientFactory();
            _httpClient = _httpClientFactory.NewClient(ApiUser, ApiPass);

            MediaLoad = new MediaLoad(_httpClient, _apiUri);
        }
    }
}
