// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using ConferencePlannerLibrary.Constants;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    public class ConferencePlannerVingette: IConferencePlannerVingette
    {

        public string TalkType { get; set; } = ConferencePlannerConstants.Vignette;
        public string ItemDescription
        {
            get; set;
        }

        public int DurationTime { get; set; } = 5;
    }
}
