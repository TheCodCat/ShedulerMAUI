using ClientSamgk.Models.Api.Implementation.Schedule;
using ClientSamgk.Models.Api.Interfaces.Cabs;
using ClientSamgk.Models.Api.Interfaces.Education;
using ClientSamgk.Models.Api.Interfaces.Groups;
using ClientSamgk.Models.Api.Interfaces.Identity;
using ClientSamgk.Models.Api.Interfaces.Schedule;

namespace ShedulerMAUI.Dto
{
    public class Lesson : IResultOutLesson
    {
        public IList<IResultOutIdentity> Identity { get; set; }
        public IResultOutGroup? EducationGroup { get; set; }
        public IResultOutSubjectItem SubjectDetails { get; set; }
        public IList<IResultOutCab> Cabs { get; set; }
        public long NumPair { get; set; }
        public long NumLesson { get; set; }
        public IList<DurationLessonDetails> Durations { get; set; }
    }
}
