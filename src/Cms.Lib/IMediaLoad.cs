using System.Threading.Tasks;

namespace Cms.Lib
{
    public interface IMediaLoad
    {
        /// <summary>
        /// Returns the current CmsServer mediaProcessingLoad value.
        /// </summary>
        /// <returns>int</returns>
        Task<int> Get();
    }
}
