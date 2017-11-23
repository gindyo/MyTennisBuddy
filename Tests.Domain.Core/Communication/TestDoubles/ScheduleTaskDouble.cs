using System;
using Core.Communication.Plugins;

namespace Core.Tests.Communication.TestDoubles
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
        }
    }
}