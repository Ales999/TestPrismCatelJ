using Prism.Modularity;
using Prism.Regions;
using System;
using PrismModule1.Views;

namespace PrismModule1
{
    public class PrismModule1Module : IModule
    {
        IRegionManager _regionManager;

        public PrismModule1Module(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Module1View));
            //throw new NotImplementedException();
        }
    }
}