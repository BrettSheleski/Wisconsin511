using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wisconsin511
{
    public interface IWisconsinService
    {
        Task<Event[]> GetEventsAsync();
        Task<Event[]> GetEventsAsync(CancellationToken cancellationToken);

        Task<Roadway[]> GetRoadwaysAsync();
        Task<Roadway[]> GetRoadwaysAsync(CancellationToken cancellationToken);

        Task<Camera[]> GetCamerasAsync();
        Task<Camera[]> GetCamerasAsync(CancellationToken cancellationToken);

        Task<MessageSign[]> GetMessageSignsAsync();
        Task<MessageSign[]> GetMessageSignsAsync(CancellationToken cancellationToken);

        Task<Alert[]> GetAlertsAsync();
        Task<Alert[]> GetAlertsAsync(CancellationToken cancellationToken);

        Task<WinterRoadCondition[]> GetWinterRoadConditionsAsync();
        Task<WinterRoadCondition[]> GetWinterRoadConditionsAsync(CancellationToken cancellationToken);
    }
}
