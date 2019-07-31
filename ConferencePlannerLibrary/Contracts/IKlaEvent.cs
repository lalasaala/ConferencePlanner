// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;

namespace ConferencePlannerLibrary.Contracts
{
    public interface IConferencePlannerEvent
    {
        List<IConferencePlannerTalk> Items { get; set; }

        void CreateEvent(string[] inputitems);
    }
}