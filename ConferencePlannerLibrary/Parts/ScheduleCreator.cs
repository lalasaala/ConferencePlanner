// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.Composition;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    [Export(typeof(IScheduleCreator))]
    public class ScheduleCreator : IScheduleCreator
    {
        private readonly IConferencePlannerEvent _klaEvent;
        private readonly ISchedulerAlgorithm _algorithm;

        [ImportingConstructor]
        public ScheduleCreator(IConferencePlannerEvent klaEvent, ISchedulerAlgorithm algorithm)
        {
            _klaEvent = klaEvent;
            _algorithm = algorithm;
        }

        public string CreateSchedule(string[] input)
        {
            _klaEvent.CreateEvent(input);
            return _algorithm.RunAlgorithm();
        }
    }
}
