using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using ConferencePlannerLibrary.Constants;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    [Export(typeof(ISchedulerAlgorithm))]
    public class SchedulerAlgorithm:ISchedulerAlgorithm
    {
        private readonly IFactory _factory;
        private readonly IConferencePlannerEvent _klaEvent;

        [ImportingConstructor]
        public SchedulerAlgorithm(IConferencePlannerEvent klaEvent, IFactory factory)
        {
            _klaEvent = klaEvent;
            _factory = factory;
        }
        /// <summary>
        /// Create Schedule and return schedule
        /// </summary>
        /// <returns>string</returns>
        public string RunAlgorithm()
        {
            List<List<IConferencePlannerItem>> returnTracksList = new List<List<IConferencePlannerItem>>();

            var itemsCopy = _klaEvent.Items.ToList();
            while (itemsCopy.Count > 0)
            {
                List<IConferencePlannerTalk> itemsScheduleMorningBeforeBreak = new List<IConferencePlannerTalk>(); // 165 mins slot
                List<IConferencePlannerTalk> itemsScehduleAfterBreakBeforeLunch = new List<IConferencePlannerTalk>(); // 60 mins slot
                List<IConferencePlannerTalk> itemsScehduleAfterLunchBeforeBreak = new List<IConferencePlannerTalk>(); // 90 mins slot
                List<IConferencePlannerTalk> itemsScheduleAfternoonAfterBreak = new List<IConferencePlannerTalk>(); // 75 mins slot
                BestFitAlg(itemsCopy, itemsScehduleAfterBreakBeforeLunch, itemsScehduleAfterLunchBeforeBreak,
                    itemsScheduleAfternoonAfterBreak, itemsScheduleMorningBeforeBreak);
                List<IConferencePlannerItem> track = new List<IConferencePlannerItem>();
                track.AddRange(itemsScheduleMorningBeforeBreak);
                track.Add(_factory.CreateBreakItem());
                track.AddRange(itemsScehduleAfterBreakBeforeLunch);
                track.Add(_factory.CreateNoonLunchItem());
                track.AddRange(itemsScehduleAfterLunchBeforeBreak);
                track.Add(_factory.CreateBreakItem());
                track.AddRange(itemsScheduleAfternoonAfterBreak);
                track.Add(_factory.CreateEodItem());
                returnTracksList.Add(track);
            }

            return GetOutputInStringFormat(returnTracksList);
        }

        private string GetOutputInStringFormat(List<List<IConferencePlannerItem>> tracks)
        {
            int i = 1;
            StringBuilder outputString = new StringBuilder();
            foreach (var track in tracks)
            {
                TimeSpan timespan = new TimeSpan(8, 0, 0);
                DateTime time = DateTime.Today.Add(timespan);
                outputString.AppendLine($"Track {i++}:");
                Console.WriteLine();
                foreach (var item in track)
                {
                    string startTime = time.ToString("hh:mm tt");

                    outputString.AppendLine($"{startTime:hh:mm} {item.ItemDescription}");

                    time = time.Add(new TimeSpan(0, item.DurationTime, 0));
                }

                outputString.AppendLine();
            }

            return outputString.ToString();
        }
        private static void BestFitAlg(List<IConferencePlannerTalk> itemsCopy, List<IConferencePlannerTalk> itemsScehduleAfterBreakBeforeLunch,
            List<IConferencePlannerTalk> itemsScehduleAfterLunchBeforeBreak, List<IConferencePlannerTalk> itemsScheduleAfternoonAfterBreak,
            List<IConferencePlannerTalk> itemsScheduleMorningBeforeBreak)
        {
            AlgAction(itemsCopy, itemsScehduleAfterBreakBeforeLunch, ConferencePlannerConstants.MorningTimeAfterBreak);
            AlgAction(itemsCopy, itemsScehduleAfterLunchBeforeBreak, ConferencePlannerConstants.AfternoonTimeBeforeBreak);
            AlgAction(itemsCopy, itemsScheduleAfternoonAfterBreak, ConferencePlannerConstants.AfternoonTimeAfterBreak);
            AlgAction(itemsCopy, itemsScheduleMorningBeforeBreak, ConferencePlannerConstants.MorningTimeBeforeBreak);
        }

        private static void AlgAction(List<IConferencePlannerTalk> itemsCopy, List<IConferencePlannerTalk> itemsScehduleAfterBreakBeforeLunch, int time)
        {
            var item = itemsCopy.FirstOrDefault(i => i.DurationTime == time);
            if (item != null)
            {
                AddRemoveItem(itemsScehduleAfterBreakBeforeLunch, item, itemsCopy);
            }
            else
            {
                LookForMatch(itemsCopy, time, itemsScehduleAfterBreakBeforeLunch);
            }
        }

        private static void LookForMatch(List<IConferencePlannerTalk> itemsCopy, int time, List<IConferencePlannerTalk> items)
        {
            var item = itemsCopy.OrderByDescending(o => o.DurationTime).FirstOrDefault(i => i.DurationTime < time);
            if (item != null)
            {
                RecursiveLoopForMatch(items, item, itemsCopy, time);
            }
        }

        private static void RecursiveLoopForMatch(List<IConferencePlannerTalk> items, IConferencePlannerTalk item, List<IConferencePlannerTalk> itemsCopy,
            int time)
        {
            AddRemoveItem(items, item, itemsCopy);
            var leftTime = time - items.Sum(i => i.DurationTime);
            if (leftTime > 0)
            {
                item = itemsCopy.OrderByDescending(o => o.DurationTime).FirstOrDefault(i => i.DurationTime <= leftTime);
                if (item != null)
                    RecursiveLoopForMatch(items, item, itemsCopy, time);
            }
        }

        private static void AddRemoveItem(List<IConferencePlannerTalk> items, IConferencePlannerTalk item, List<IConferencePlannerTalk> itemsCopy)
        {
            items.Add(item);
            itemsCopy.Remove(item);
        }
    }
}
