// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using ConferencePlannerLibrary.Constants;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    [Export(typeof(IConferencePlannerEvent))]
    public class ConferencePlannerEvent : IConferencePlannerEvent
    {
        private readonly IFactory _factory;
        public List<IConferencePlannerTalk> Items { get; set; }

        [ImportingConstructor]
        public ConferencePlannerEvent(IFactory factory)
        {
            _factory = factory;
        }
        private void AddItem(IConferencePlannerTalk klaTalk)
        {
            Items.Add(klaTalk);
        }

        public void CreateEvent(string[] inputitems)
        {
            Items = new List<IConferencePlannerTalk>();

            foreach (var inputitem in inputitems)
            {
                var line = Regex.Replace(inputitem, @"\t|\n|\r", "");
                if (!string.IsNullOrWhiteSpace(line))
                {
                 //   IConferencePlannerTalk klaTalk;
                    bool isVingette;
                    bool isHomeExpert;
                    int time;
                    ParseInputItem(inputitem, out isVingette, out isHomeExpert, out time);

                    if (isVingette)
                    {
                        AddItem(_factory.CreateConferencePlannerVingette(line));
                    }
                    else if(isHomeExpert)
                    {
                        AddItem(_factory.CreateConferencePlannerHomeExpert(line, time));
                    }
                    else
                    {
                        if (Convert.ToInt32(time) == 5)
                        {
                            AddItem(_factory.CreateConferencePlannerVingette(line));
                        }
                        else
                        {
                            AddItem(_factory.CreateConferencePlannerHomeExpert(line, time));
                        }
                    }

                }
            }
        }

        private void ParseInputItem(string line, out bool isVingette, out bool isHomeExpert, out int time)
        {
            var durationmin = Regex.Match(line, @"\d+ min").Value;
            var duration = Regex.Match(durationmin, @"\d+").Value;
            // string topic;
            isVingette = Regex.IsMatch(line, ConferencePlannerConstants.Vignette);
            isHomeExpert = Regex.IsMatch(line, ConferencePlannerConstants.Homeexpert);
            int.TryParse(duration, out time);
        }
    }
}
