using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Entities
{
    public class Contact
    {

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

    }
}
