// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
namespace ConferencePlannerLibrary.Contracts
{
    public interface IConferencePlannerItem
    {
        int DurationTime { get; set; }
        string ItemDescription { get; set; }
      //  string ItemType { get; set; }
    }
}