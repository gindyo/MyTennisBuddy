using System;

namespace MtB
{
    public interface IScheduleTask
    {
        IScheduleTask Do(Action task);
        IScheduleTask In(TimeSpan timespan );
        void StartCounting();
    }
}