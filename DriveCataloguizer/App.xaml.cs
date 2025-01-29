using System.Windows;
using DriveCataloguizer.DependencyInjections;
using Splat;

namespace DriveCataloguizer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() => Bootsrapper.Register(Locator.CurrentMutable, Locator.Current);
    }
}
