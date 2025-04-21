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
        public IList<IResultOutIdentity> Identity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IResultOutGroup? EducationGroup { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IResultOutSubjectItem SubjectDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<IResultOutCab> Cabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long NumPair { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long NumLesson { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IList<DurationLessonDetails> Durations { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
