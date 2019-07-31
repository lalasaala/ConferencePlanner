// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel.Composition;
using ConferencePlannerLibrary.Contracts;

namespace ConferencePlannerLibrary.Parts
{
    [Export(typeof(IFactory))]
    public class Factory : IFactory
    {
        /// <summary>
        /// Creates and returns a new instance of ConferencePlannerVingette
        /// </summary>
        /// <param name="description">setter value for ItemDescription property of ConferencePlannerVingette instance</param>
        /// <returns>instance of type IConferencePlannerVingette</returns>
        public IConferencePlannerVingette CreateConferencePlannerVingette(string description)
        {
            return new ConferencePlannerVingette {ItemDescription =description};
        }

        /// <summary>
        /// Creates and returns a new instance of ConferencePlannerHomeExpert
        /// </summary>
        /// <param name="description">setter value for ItemDescription property of ConferencePlannerHomeExpert instance</param>
        /// <param name="durationTime">setter value for DuratinTime property of ConferencePlannerHomeExpert instance</param>
        /// <returns>instance of type IConferencePlannerHomeExpert</returns>
        public IConferencePlannerHomeExpert CreateConferencePlannerHomeExpert(string description, int durationTime)
        {
            return new ConferencePlannerHomeExpert { DurationTime = durationTime, ItemDescription = description};
        }

        /// <summary>
        /// Creates and returns a new instance of ConferencePlannerBreak
        /// </summary>
        /// <returns>instance of type IConferencePlannerItem</returns>
        public IConferencePlannerItem CreateBreakItem()
        {
            return new ConferencePlannerBreak();
        }

        /// <summary>
        /// Creates and returns a new instance of ConferencePlannerNoonLunch
        /// </summary>
        /// <returns>instance of type IConferencePlannerItem</returns>
        public IConferencePlannerItem CreateNoonLunchItem()
        {
            return new ConferencePlannerNoonLunch();
        }

        /// <summary>
        /// Creates and returns a new instance of ConferencePlannerEodEvent
        /// </summary>
        /// <returns>instance of type IConferencePlannerItem</returns>
        public IConferencePlannerItem CreateEodItem()
        {
            return new ConferencePlannerEodEvent();
        }
    }
}
