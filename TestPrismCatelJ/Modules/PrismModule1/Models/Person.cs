using System.Collections.Generic;
using Catel.Data;
using Catel.Runtime.Serialization;

namespace PrismModule1.Models
{
    public class Person : ModelBase
    {

        #region FirstName property

        /// <summary>
        /// Gets or sets the FirstName value.
        /// </summary>
        public string FirstName { get; set; }

        #endregion

        #region MiddleName property

        /// <summary>
        /// Gets or sets the MiddleName value.
        /// </summary>
        public string MiddleName { get; set; }


        #endregion

        #region LastName property

        /// <summary>
        /// Gets or sets the LastName value.
        /// </summary>
        public string LastName { get; set; }


        #endregion

        [ExcludeFromSerialization]
        public string FullName => $"{FirstName} {LastName}";
    }

}
