﻿namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects
{
    public struct AddressValueObject
    {
        public string Street { get; }
        public string Number { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }

        public AddressValueObject(
            string street,
            string number,
            string city,
            string state,
            string country,
            string zipCode
        )
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
