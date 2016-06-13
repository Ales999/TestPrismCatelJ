using System.Runtime.CompilerServices;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;
using TestPrismCatelJ.ViewModels;

namespace TestPrismCatelJ
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {

        public Shell( ShellViewModel viewModel)
        {
            this.DataContext = viewModel;
            InitializeComponent();
        }


        private void MainRegion_OnDockStateChanged(FrameworkElement sender, DockStateEventArgs e)
        {

            //  https://www.syncfusion.com/kb/2735/how-to-release-memory-in-dockingmanager-after-closing-the-tab
            //  Выгружать из памяти если потомок закрыт
            if (e.NewState == DockState.Hidden)
            {
                MainRegion.Children.Remove(sender);
                
            }
        }


    }
}
