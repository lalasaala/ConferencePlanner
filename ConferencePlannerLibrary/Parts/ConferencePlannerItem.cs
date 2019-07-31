// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    public class ConferencePlannerItem : IConferencePlannerItem
    {
        public string ItemDescription
        {
            get; set; 
        }

        public int DurationTime { get; set; }


       // public string ItemType { get; set; }
    }
}
