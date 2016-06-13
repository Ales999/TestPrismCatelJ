using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Regions;

namespace TestPrismCatelJ
{
    public class ClearChildViewsRegionBehavior : RegionBehavior
    {
        protected override void OnAttach()
        {
            this.Region.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Region_PropertyChanged);
            this.Region.Views.CollectionChanged += Views_CollectionChanged;
            this.Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
            //throw new NotImplementedException();
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            
            if(e.Action != NotifyCollectionChangedAction.Remove)
                return;
            

            throw new NotImplementedException();
        }

        private void Views_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Remove)
                return;

        }

        private void Region_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RegionManager")
            {
                if (this.Region.RegionManager == null)
                {
                    foreach (object view in this.Region.Views)
                    {
                        DependencyObject dependencyObject = view as DependencyObject;
                        if (dependencyObject != null)
                        {
                            dependencyObject.ClearValue(RegionManager.RegionManagerProperty);
                        }
                    }
                }
                
            } 
        }
    }
}
