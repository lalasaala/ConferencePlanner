// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using ConferencePlannerLibrary.Constants;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    class ConferencePlannerHomeExpert: IConferencePlannerHomeExpert
    {
        public string TalkType { get; set; } = ConferencePlannerConstants.Homeexpert;
        public string ItemDescription
        {
            get; set;
        }

        public int DurationTime { get; set; }
    }
}
