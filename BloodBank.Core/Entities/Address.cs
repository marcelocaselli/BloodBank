﻿namespace BloodBank.Core.Entities
{
    public class Address 
    {
        public Address(string street, string city, string state, string zipCode)
            : base()
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }        

        public void Update(string street, string city, string state, string zipCode)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}




