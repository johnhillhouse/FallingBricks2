using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FallingBricks2.Controller;
using FallingBricks2.View.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FallingBricks2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //base.OnStartup(e);
            var bootstrapper = new Bootstrapper();
            bootstrapper.Bootstrap();
        }



    }

    public class Bootstrapper
    {
        private IWindsorContainer _container;
        internal void Bootstrap()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<GameGridController>());
            _container.Register(Component.For<IGameGrid>().ImplementedBy<GameGrid>());


            //TODO this goes in the test
            //_container.Resolve<IGameGrid>();
            //_container.Resolve<GameGridController>();
        }
    }
}
