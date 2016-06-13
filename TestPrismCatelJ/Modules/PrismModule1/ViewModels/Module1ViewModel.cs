using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Catel.Data;
using Catel.Fody;
using Catel.Runtime.Serialization;
using PrismModule1.Models;
//using PiranhasJ.Shared.ViewModels;


namespace PrismModule1.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    using Prism.Regions;

    public class Module1ViewModel : ViewModelBase, IDisposable
    {
        private readonly IRegionManager _regionManager;
        private Persons _persons = null;

        public Module1ViewModel()
        {
            _title = "New Module1 View model title";

            LoadDataXml();
            if(_persons == null)
                _persons = new Models.Persons();
            
            this.Persons = _persons.PersonCollection;

        }



//        ~Module1ViewModel()
//        {
//            SaveDataXml();
//        }


        private void SaveDataXml()
        {
            var xmlSerializer = SerializationFactory.GetXmlSerializer();
            xmlSerializer.Warmup();

            using (var fileStream = File.OpenWrite(@"PersonsData.xml"))
            {
                // If _persons is Not null -> SaveXml
                _persons?.SaveAsXml(fileStream);
            }
        }

        private bool LoadDataXml()
        {
            bool result = false;
            try
            {
                using (var fileStream = File.Open(@"PersonsData.xml", FileMode.Open))
                {
                    _persons = ModelBase.Load<Persons>(fileStream, SerializationMode.Xml);
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }


        public ObservableCollection<Person> Persons { get; set; }


        #region Person property

        /// <summary>
        /// Gets or sets the Person value.
        /// </summary>
        [Model]
        [Expose("FirstName")]
        [Expose("MiddleName")]
        [Expose("LastName")]
        [Expose("FullName")]
        private Person Person
        {
            get { return GetValue<Person>(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }

        /// <summary>
        /// Person property data.
        /// </summary>
        public static readonly PropertyData PersonProperty = RegisterProperty("Person", typeof(Person));

        #endregion

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

        #region IDisposable Support
        private bool _disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.
                SaveDataXml();
                _disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        ~Module1ViewModel() {
          // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
           Dispose(false);
        }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
