using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorManager.Core.Domain
{
    public class Store : Entity
    {
        public string Name { get; protected set; }
        public string City { get; protected set; }
        public string Street { get; protected set; }
        public string SID { get; protected set; }
        public string PostalCode { get; protected set; }
        public string ResponsiblePerson { get; protected set; }
        public float Latitude { get; protected set; }
        public float Longitude { get; protected set; }

        protected Store()
        {
        }
        public Store(Guid id, string name, string city, string street, string sid, string postalCode, string responsiblePerson, float latitude, float longitude)
        {
            Id = id;
            SetName(name);
            City = city;
            Street = street;
            SID = sid;
            PostalCode = postalCode;
            ResponsiblePerson = responsiblePerson;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"Store with id: '{Id}' can not have empty name.");
            }
            Name = name;
        }

    }

}

