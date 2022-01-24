using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Settings
{
    public class PersonDatabaseSettings : IPersonDatabaseSettings
    {
        public string ConnectionString { get; set ; }
        public string DatabaseName { get ; set; }
        public string CollectionName { get  ; set ; }
    }
}
