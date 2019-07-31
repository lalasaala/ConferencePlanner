// --------------------------------------------------------------------------------------------------------------------
// Created by - Lalasa Ala
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using ConferencePlannerLibrary.Contracts;
using ConferencePlannerLibrary.Parts;

namespace ConferencePlannerConsole
{
    public class Program
    {
        //[Import]
        //private IConferencePlannerEvent _klaEvent;

        [Import]
        private IScheduleCreator _scheduleCreator;

        [Import]
        private IInputReader _inputReader;

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Run(args);
        }

        private void Run(string[] args)
        {
            Compose();
            var input = _inputReader.ReadInputFromFile(args.Length >= 1 ? args[0] : @"Input\Input.txt");

            var output = _scheduleCreator.CreateSchedule(input);

            Console.Write(output);

            Console.ReadLine();
        }

        private void Compose()
        {
            var catalog = CreateComposableCatalog();
            var container = CreateCompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }

        private ComposablePartCatalog CreateComposableCatalog()
        {
            ComposablePartCatalog catalog = new AggregateCatalog(
                new AssemblyCatalog(typeof(ScheduleCreator).Assembly));
            return catalog;

        }
        private CompositionContainer CreateCompositionContainer(ComposablePartCatalog catalog)
        {
            var container = new CompositionContainer(catalog, true);
            return container;
        }
    }
}
