using System;
using System.Globalization;
using System.Windows;
using Catel.IoC;
using Catel.Services;
using Microsoft.Practices.ServiceLocation;
//using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Syncfusion.Windows.Tools.Controls;
using TestPrismCatelJ.ViewModels;



namespace TestPrismCatelJ
{

    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return Container.Resolve<Shell>();
            return InitCtorShellViewModel();
        }

        private DependencyObject InitCtorShellViewModel()
        {
            var view = Container.Resolve<Shell>();
            var viewModel = Container.Resolve<ShellViewModel>();
            view.DataContext = viewModel;
            view.Show();
            return view;
        }

        protected override void InitializeShell()
        {
            // Application.Current.MainWindow.Show();
            base.InitializeShell();
            App.Current.MainWindow = (Window) this.Shell;
            App.Current.MainWindow.Show();
            

        }


        //protected override DepencyObject 
        //base.InitializeShell();
        //return this.Container.Resolve<Shell>();

        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();

            catalog.AddModule(typeof(PrismModule1.PrismModule1Module));
            catalog.AddModule(typeof(PrismModule2.PrismModule2Module));

            return catalog;
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            //            return base.ConfigureRegionAdapterMappings();
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

            mappings?.RegisterMapping(typeof(DockingManager), this.Container.TryResolve<DockingAdapter>());

            return mappings;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //windows
            Container.RegisterType<Shell>(new ContainerControlledLifetimeManager());

            //services
            //Container.RegisterType<IEventMessager, EventMessager>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDispatcherService, DispatcherService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISchedulerService, SchedulerService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IMessageBoxService, MessageBoxService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ShellViewModel>(new ContainerControlledLifetimeManager());

            //custom region stuff to support child container navigation
            //Container.RegisterType<IRegionNavigationContentLoader, CustomRegionNavigationContentLoader>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IRegionNavigationService, CustomRegionNavigationService>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IRegionNavigationCapacityChecker, RegionNavigationCapacityChecker>(new ContainerControlledLifetimeManager());
            //Container.RegisterType<IRegionNavigationCallbackHandler, RegionNavigationCallbackHandler>(new ContainerControlledLifetimeManager());

        }


        // Add Dispose support behavior
        protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory =  base.ConfigureDefaultRegionBehaviors();

            //factory.AddIfMissing(DisposeClosedViewsBehavior.BehaviorKey, typeof(DisposeClosedViewsBehavior));

            return factory;
        }
    }
}
