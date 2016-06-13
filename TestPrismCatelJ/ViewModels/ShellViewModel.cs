using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;

namespace TestPrismCatelJ.ViewModels
{
    public class ShellViewModel : Catel.MVVM.ViewModelBase
    {

//        public ShellViewModel() { }

        public ShellViewModel(IRegionManager regionManager)
        {
        }

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Shell View Model"; }
        }
        #endregion

    }
}
