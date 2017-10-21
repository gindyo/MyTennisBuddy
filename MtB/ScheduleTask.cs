using System;
using Hangfire;

namespace MtB
{
    public class ScheduleTask : IScheduleTask
    {

        private Action _task = () => { };
        private DateTime _time = DateTime.Now;


        public virtual IScheduleTask Do(Action task)
        {
            _task = task;
            return this;
        }

        public IScheduleTask In(TimeSpan timespan)
        {
            _time = DateTime.Now + timespan;
            return this;
        }

        public virtual void StartCounting()
        {
            BackgroundJob.Schedule(()=>_task(), _time);
        }
    }
}