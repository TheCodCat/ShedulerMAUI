using CommunityToolkit.Mvvm.ComponentModel;
using ShedulerMAUI.Services;
using ClientSamgk.Models.Api.Interfaces.Groups;
using CommunityToolkit.Mvvm.Input;
using ClientSamgk.Models;
using ClientSamgk.Models.Api.Interfaces.Schedule;
using System.Collections.ObjectModel;

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
        private ObservableCollection<IResultOutLesson> scheduleFromDates = new ObservableCollection<IResultOutLesson>();

        public MainViewModel(SamgkApiService samgkApiService)
        {
            this.samgkApiService = samgkApiService;
            Init();
        }
        private async void Init()
        {
            Data = DateTime.Now;
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
            ScheduleFromDates.Clear();
            ScheduleFromDates = new ObservableCollection<IResultOutLesson>(result[0].Lessons);

            //ScheduleFromDates = result.ToList()[0].Lessons.Select(x => new Lesson() {
            //    NumLesson = x.NumLesson,
            //    NumPair = x.NumPair
            //}).ToList();
        }
    }
}
