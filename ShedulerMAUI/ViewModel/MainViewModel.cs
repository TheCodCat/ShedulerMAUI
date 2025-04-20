using ClientSamgk;
using CommunityToolkit.Mvvm.ComponentModel;
using ShedulerMAUI.Services;
using ClientSamgk.Models.Api.Interfaces.Groups;
using CommunityToolkit.Mvvm.Input;
using ClientSamgk.Models;

namespace ShedulerMAUI.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private SamgkApiService samgkApiService;

        [ObservableProperty]
        private DateTime data;

        [ObservableProperty]
        private string numGroup;

        [ObservableProperty]
        private List<string> groups = new List<string>();

        private IList<IResultOutGroup> resultOutGroups = new List<IResultOutGroup>();

        public MainViewModel(SamgkApiService samgkApiService)
        {
            this.samgkApiService = samgkApiService;
            Init();
        }
        private async void Init()
        {
            resultOutGroups = await samgkApiService.GetGroups();

            foreach (var item in resultOutGroups)
            {
                Groups.Add(item.Name);
            }
        }

        [RelayCommand]
        public async void SheduleDataGroup()
        {
            IResultOutGroup group = resultOutGroups.FirstOrDefault(x => x.Name == NumGroup);
            var query = new ScheduleQuery().WithDate(DateOnly.FromDateTime(Data)).WithGroup(group);

            var result = await samgkApiService.GetSchedule(query);
        }
    }
}
