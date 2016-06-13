using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catel.Data;
using Catel.Runtime.Serialization;

namespace PrismModule1.Models
{
    class Persons : ModelBase
    {

        public Persons()
        {
            var pers1 = new Person
            {
                FirstName = "Ivan",
                MiddleName = "Vladimirovich",
                LastName = "Ivanov"
            };

            var pers2 = new Person()
            {
                FirstName = "Alexey",
                MiddleName = "Ivanovich",
                LastName = "Uragano"

            };

            var perscol = new ObservableCollection<Person> {pers1, pers2};
            PersonCollection = perscol;

        }


        public ObservableCollection<Person> PersonCollection { get; set; }

    }
}
