using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using PrismModule1.Views;

namespace PrismModule1
{
    public class PrismModule1Module : IModule, IDisposable
    {
        private readonly IUnityContainer _unityContainer;
        IRegionManager _regionManager;

        public PrismModule1Module(IUnityContainer unityContainer, RegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        public void Initialize()
        {

            //_unityContainer.RegisterViewForNavigation<Module1View>();
            //_regionManager.RequestNavigateUsingContainer<Module1View>("MainRegion", _unityContainer, new NavigationParameters());


            _regionManager.RegisterViewWithRegion("MainRegion", typeof(Module1View));
            //throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~PrismModule1Module() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}