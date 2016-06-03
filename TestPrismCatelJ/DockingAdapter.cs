#region Copyright Syncfusion Inc. 2001 - 2011
// Copyright Syncfusion Inc. 2001 - 2011. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Linq;
using System.Windows;
using Prism.Regions;
using Syncfusion.Windows.Tools.Controls;

namespace TestPrismCatelJ
{
    public class DockingAdapter : RegionAdapterBase<DockingManager>
    {
        public DockingAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {
            region.Views.CollectionChanged += delegate
            {
                foreach (var child in region.Views.Cast<FrameworkElement>())
                {
                    if (!regionTarget.Children.Contains(child))
                    {
                        regionTarget.BeginInit();
                        regionTarget.Children.Add(child);
                        regionTarget.EndInit();
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
    
}
