using System;

namespace MtB.Plugins
{
    public interface IScheduleTask
    {
        IScheduleTask Do(Action task);
        IScheduleTask In(TimeSpan timespan );
        void StartCounting();
    }
}