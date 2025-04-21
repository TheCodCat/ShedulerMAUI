using CommunityToolkit.Mvvm.ComponentModel;
using ShedulerMAUI.Services;
using ClientSamgk.Models.Api.Interfaces.Groups;
using CommunityToolkit.Mvvm.Input;
using ClientSamgk.Models;
using ShedulerMAUI.Dto;
using ClientSamgk.Models.Api.Interfaces.Schedule;

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

        [ObservableProperty]
        private List<Lesson> scheduleFromDates = new List<Lesson>();

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
            ScheduleFromDates = result.ToList()[0].Lessons.Select(x => new Lesson() {
                NumLesson = x.NumLesson,
                Durations = x.Durations,
                NumPair = x.NumPair
            }).ToList();
        }
    }
}
