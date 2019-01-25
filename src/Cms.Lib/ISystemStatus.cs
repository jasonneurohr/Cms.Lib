using System.Threading.Tasks;

namespace Cms.Lib
{
    public interface ISystemStatus
    {
        Task<SystemStatusResponse> Get();
        Task<SystemAlarStatusResponse> GetAlarmStatus();
        Task<SystemDatabaseStatusResponse> GetDatabaseStatus();
    }
}