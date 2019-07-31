// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
namespace ConferencePlannerLibrary.Contracts
{
    public interface IFactory
    {
        IConferencePlannerItem CreateBreakItem();
        IConferencePlannerItem CreateEodItem();
        IConferencePlannerHomeExpert CreateConferencePlannerHomeExpert(string description, int durationTime);
        IConferencePlannerVingette CreateConferencePlannerVingette(string description);
        IConferencePlannerItem CreateNoonLunchItem();
    }
}