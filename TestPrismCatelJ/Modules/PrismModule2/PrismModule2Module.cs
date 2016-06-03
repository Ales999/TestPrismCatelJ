using Prism.Modularity;
using Prism.Regions;
using System;
using PrismModule2.Views;

namespace PrismModule2
{
    public class PrismModule2Module : IModule
    {
        IRegionManager _regionManager;

        public PrismModule2Module(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Module2View));
            //throw new NotImplementedException();
        }
    }
}