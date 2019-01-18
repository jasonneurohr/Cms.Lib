
namespace Cms.Lib
{
    /// <summary>
    /// A CmsServer instance for working with the CMS API.
    /// </summary>
    public interface ICmsServer
    {
        IMediaLoad MediaLoad { get; }
    }
}
