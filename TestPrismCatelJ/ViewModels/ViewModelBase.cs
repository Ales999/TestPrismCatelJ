using System;
using Prism.Logging;
using Prism.Mvvm;

namespace TestPrismCatelJ.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        public event Action RequestClose = delegate { };

        protected ILoggerFacade logger;

        private string header;
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }

        public ViewModelBase(ILoggerFacade logger)
        {
            this.logger = logger;
        }

        public void OnRequestClose()
        {
            RequestClose();
        }

        #region IDisposable Members

        /// <summary>
        /// Invoked when this object is being removed from the application
        /// and will be subject to garbage collection.
        /// </summary>
        public void Dispose()
        {
            OnDispose();
        }

        /// <summary>
        /// Child classes can override this method to perform 
        /// clean-up logic, such as removing event handlers.
        /// </summary>
        protected virtual void OnDispose()
        {
        }

#if DEBUG
        /// <summary>
        /// Useful for ensuring that ViewModel objects are properly garbage collected.
        /// </summary>
        ~ViewModelBase()
        {
            string msg = string.Format("{0} ({1}) Finalized", GetType().Name, GetHashCode());
            logger.Log(msg, Category.Debug, Priority.None);
        }
#endif

        #endregion // IDisposable Members
    }
}
