using System;
using MtB.Communication.Plugins;

namespace MtB.Tests.TestDoubles
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