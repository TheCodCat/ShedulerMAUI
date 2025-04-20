using ClientSamgk.Interfaces.Client;
using ClientSamgk;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models;
using ClientSamgk.Models.Api.Interfaces.Schedule;

namespace ShedulerMAUI.Services
{
    public class SamgkApiService
    {
        IClientSamgkApi api = new ClientSamgkApi();

        public async Task<IList<IResultOutGroup>> GetGroups()
        {
            return await api.Groups.GetGroupsAsync();
        }
        public async Task<IList<IResultOutScheduleFromDate>> GetSchedule(ScheduleQuery sheduleQuery)
        {
            return await api.Schedule.GetScheduleAsync(sheduleQuery);
        }
    }
}
