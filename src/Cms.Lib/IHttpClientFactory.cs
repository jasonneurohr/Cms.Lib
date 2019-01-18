using System.Net.Http;

namespace Cms.Lib
{
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Returns a HttpClient object configured with the Basic Authentication Header.
        /// </summary>
        /// <param name="apiUser"></param>
        /// <param name="apiPass"></param>
        /// <returns>HttpClient</returns>
        HttpClient NewClient(string apiUser, string apiPass);
    }
}
