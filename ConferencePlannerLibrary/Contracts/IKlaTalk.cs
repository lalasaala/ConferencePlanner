// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
namespace ConferencePlannerLibrary.Contracts
{
    public interface IConferencePlannerTalk : IConferencePlannerItem
    {
        string TalkType { get; set; }
    }
}
