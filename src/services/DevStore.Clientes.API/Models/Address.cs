using DevStore.Core.DomainObjects;
using System;

namespace DevStore.Clients.API.Models
{
    public class Address : Entity
    {
        public string StreetAddress { get; private set; }
        public string BuildingNumber { get; private set; }
        public string SecondaryAddress { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid ClientId { get; private set; }

        // EF Relation
        public Client Client { get; protected set; }

        public Address(string streetAddress, string buildingNumber, string secondaryAddress, string neighborhood, string zipCode, string city, string state, Guid clientId)
        {
            StreetAddress = streetAddress;
            BuildingNumber = buildingNumber;
            SecondaryAddress = secondaryAddress;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
            City = city;
            State = state;
            ClientId = clientId;
        }

        // EF Constructor
        protected Address() { }
    }
}