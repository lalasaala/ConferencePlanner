using System.Windows;

namespace ConferencePlannerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BootStrapper _bootstrapper;

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper = new BootStrapper();
            _bootstrapper.Initialize();
            _bootstrapper.Run(e.Args);
        }
    }
}
