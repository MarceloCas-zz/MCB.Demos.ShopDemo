using MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications.Interfaces;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications;

public sealed class AddressValueObjectSpecifications
    : IAddressValueObjectSpecifications
{
    // Street
    public bool AddressValueObjectShouldHaveStreet(string street)
    {
        return !string.IsNullOrWhiteSpace(street);
    }
    public bool AddressValueObjectShouldHaveStreetMaximumLength(string street)
    {
        return street.Length <= 150;
    }

    // Number
    public bool AddressValueObjectShouldHaveNumber(string number)
    {
        return !string.IsNullOrWhiteSpace(number);
    }
    public bool AddressValueObjectShouldHaveNumberMaximumLength(string number)
    {
        return number.Length <= 150;
    }

    // City
    public bool AddressValueObjectShouldHaveCity(string city)
    {
        return !string.IsNullOrWhiteSpace(city);
    }
    public bool AddressValueObjectShouldHaveCityMaximumLength(string city)
    {
        return city.Length <= 150;
    }

    // State
    public bool AddressValueObjectShouldHaveState(string state)
    {
        return !string.IsNullOrWhiteSpace(state);
    }
    public bool AddressValueObjectShouldHaveStateMaximumLength(string state)
    {
        return state.Length <= 150;
    }

    // Country
    public bool AddressValueObjectShouldHaveCountry(string country)
    {
        return !string.IsNullOrWhiteSpace(country);
    }
    public bool AddressValueObjectShouldHaveCountryMaximumLength(string country)
    {
        return country.Length <= 150;
    }

    // Zip Code
    public bool AddressValueObjectShouldHaveZipCode(string zipCode)
    {
        return !string.IsNullOrWhiteSpace(zipCode);
    }
    public bool AddressValueObjectShouldHaveZipCodeMaximumLength(string zipCode)
    {
        return zipCode.Length <= 150;
    }
}