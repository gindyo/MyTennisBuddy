using System;
using Core.Communication.Plugins;

namespace Core.Tests.Communication.TestDoubles
{
    public class TaskSchedulerDouble : ScheduleTask
    {
        private Action _task;

        public override IScheduleTask Do(Action task)
        {
            _task = task;
            return this;
        }

        public override void StartCounting()
        {
            //instead of scheduling call task right away
            _task();
        }
    }
}