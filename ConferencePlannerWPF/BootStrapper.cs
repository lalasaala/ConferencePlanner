using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConferencePlannerLibrary.Parts;
using ConferencePlannerWPF.ViewModels;
using ConferencePlannerWPF.Views;

namespace ConferencePlannerWPF
{
    internal class BootStrapper
    {
        private CompositionContainer _container;

        public void Initialize()
        {
            Compose();
        }
        private void Compose()
        {
            var catalog = CreateComposableCatalog();
            _container = CreateCompositionContainer(catalog);
        }

        private ComposablePartCatalog CreateComposableCatalog()
        {
            ComposablePartCatalog catalog = new AggregateCatalog(
                new AssemblyCatalog(typeof(ScheduleCreator).Assembly),
                new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            return catalog;

        }
        private CompositionContainer CreateCompositionContainer(ComposablePartCatalog catalog)
        {
            var container = new CompositionContainer(catalog, true);
            return container;
        }

        public void Run(string[] eArgs)
        {
            var viewModel = _container.GetExportedValue<MainViewModel>();
            var mainWindow = new ConferencePlannerMainView { DataContext = viewModel };
            System.Windows.Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
