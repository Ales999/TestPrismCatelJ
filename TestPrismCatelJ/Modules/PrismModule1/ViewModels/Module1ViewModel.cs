namespace PrismModule1.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;

    public class Module1ViewModel : ViewModelBase
    {
        public Module1ViewModel()
        {
            _title = "New Module1 View model title";
        }

        private readonly string _title;

        public override string Title { get { return _title; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
