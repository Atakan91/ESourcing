using ESourcing.Persons.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Persons.Data
{
    public class PersonContextSeed
    {
        public static void SeedData (IMongoCollection<Person> personCollection)
        {
            bool exitsPerson = personCollection.Find(p => true).Any();

            if (!exitsPerson)
            {
                personCollection.InsertManyAsync(GetConfigurePersons());
            }
        }

        private static IEnumerable<Person> GetConfigurePersons()
        {
            return new List<Person>()
            {
                new Person
                {
                     Name="Ahmet",
                     Surname="Yılmaz",
                     Company ="A Firması",
                     Contacts = new List<Contact>
                     { 
                            new Contact
                            {
                              PhoneNumber="0555 147 11 58",
                              Email ="ayilmaz@example.com",
                              Location ="Ankara"
                            },
                            new Contact
                            {
                              PhoneNumber="0555 147 12 59",
                              Email ="ayilmaz@example.com",
                              Location ="İstanbul"
                            },
                    }
                },
                new Person
                {
                     Name="Mehmet",
                     Surname="Karaca",
                     Company ="B Firması",
                     Contacts = new List<Contact>
                     { 
                            new Contact
                            {
                              PhoneNumber="0554 132 90 45",
                              Email ="mkaraca@example.com",
                              Location ="İzmir"
                            },
                            new Contact
                            {
                              PhoneNumber="0555 133 91 46",
                              Email ="mkaraca@example.com",
                              Location ="Eskişehir"
                            }

                     }
                },
                new Person
                {
                     Name="Gökhan",
                     Surname="Demir",
                     Company ="C Firması",
                     Contacts =new List<Contact>
                     {                      
                         new Contact
                            {
                              PhoneNumber="0543 157 66 21",
                              Email ="gdemir@example.com",
                              Location ="Adana"
                            }
                     }
                },
                new Person
                {
                     Name="Mustafa",
                     Surname="Uygur",
                     Company ="D Firması",
                     Contacts =new List<Contact>
                     {
                         new Contact
                            {
                              PhoneNumber="0543 185 74 33",
                              Email ="muygur@example.com",
                              Location ="Konya"
                            }
                     }
                },
                new Person
                {
                     Name="Yusuf",
                     Surname="Kozan",
                     Company ="F Firması",
                     Contacts =new List<Contact>
                     {
                         new Contact
                            {
                              PhoneNumber="0543 133 41 26",
                              Email ="ykozan@example.com",
                              Location ="Adana"
                            }
                     }
                }
            };
        }
    }
}
