using FluentValidation;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Domain.Entities.ValueObjects.Address.Specifications.Interfaces;

public interface IAddressValueObjectSpecifications
{
    // Street
    public static readonly string AddressValueObjectShouldHaveStreetErrorCode = nameof(AddressValueObjectShouldHaveStreetErrorCode);
    public static readonly string AddressValueObjectShouldHaveStreetMessage = nameof(AddressValueObjectShouldHaveStreetMessage);
    public static readonly Severity AddressValueObjectShouldHaveStreetSeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveStreetMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveStreetMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveStreetMaximumLengthMessage = nameof(AddressValueObjectShouldHaveStreetMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveStreetMaximumLengthSeverity = Severity.Error;

    // Number
    public static readonly string AddressValueObjectShouldHaveNumberErrorCode = nameof(AddressValueObjectShouldHaveNumberErrorCode);
    public static readonly string AddressValueObjectShouldHaveNumberMessage = nameof(AddressValueObjectShouldHaveNumberMessage);
    public static readonly Severity AddressValueObjectShouldHaveNumberSeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveNumberMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveNumberMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveNumberMaximumLengthMessage = nameof(AddressValueObjectShouldHaveNumberMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveNumberMaximumLengthSeverity = Severity.Error;

    // City
    public static readonly string AddressValueObjectShouldHaveCityErrorCode = nameof(AddressValueObjectShouldHaveCityErrorCode);
    public static readonly string AddressValueObjectShouldHaveCityMessage = nameof(AddressValueObjectShouldHaveCityMessage);
    public static readonly Severity AddressValueObjectShouldHaveCitySeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveCityMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveCityMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveCityMaximumLengthMessage = nameof(AddressValueObjectShouldHaveCityMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveCityMaximumLengthSeverity = Severity.Error;

    // State
    public static readonly string AddressValueObjectShouldHaveStateErrorCode = nameof(AddressValueObjectShouldHaveStateErrorCode);
    public static readonly string AddressValueObjectShouldHaveStateMessage = nameof(AddressValueObjectShouldHaveStateMessage);
    public static readonly Severity AddressValueObjectShouldHaveStateSeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveStateMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveStateMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveStateMaximumLengthMessage = nameof(AddressValueObjectShouldHaveStateMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveStateMaximumLengthSeverity = Severity.Error;

    // Country
    public static readonly string AddressValueObjectShouldHaveCountryErrorCode = nameof(AddressValueObjectShouldHaveCountryErrorCode);
    public static readonly string AddressValueObjectShouldHaveCountryMessage = nameof(AddressValueObjectShouldHaveCountryMessage);
    public static readonly Severity AddressValueObjectShouldHaveCountrySeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveCountryMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveCountryMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveCountryMaximumLengthMessage = nameof(AddressValueObjectShouldHaveCountryMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveCountryMaximumLengthSeverity = Severity.Error;

    // ZipCode
    public static readonly string AddressValueObjectShouldHaveZipCodeErrorCode = nameof(AddressValueObjectShouldHaveZipCodeErrorCode);
    public static readonly string AddressValueObjectShouldHaveZipCodeMessage = nameof(AddressValueObjectShouldHaveZipCodeMessage);
    public static readonly Severity AddressValueObjectShouldHaveZipCodeSeverity = Severity.Error;

    public static readonly string AddressValueObjectShouldHaveZipCodeMaximumLengthErrorCode = nameof(AddressValueObjectShouldHaveZipCodeMaximumLengthErrorCode);
    public static readonly string AddressValueObjectShouldHaveZipCodeMaximumLengthMessage = nameof(AddressValueObjectShouldHaveZipCodeMaximumLengthMessage);
    public static readonly Severity AddressValueObjectShouldHaveZipCodeMaximumLengthSeverity = Severity.Error;

    // Methods
    bool AddressValueObjectShouldHaveStreet(string street);
    bool AddressValueObjectShouldHaveStreetMaximumLength(string street);

    bool AddressValueObjectShouldHaveNumber(string number);
    bool AddressValueObjectShouldHaveNumberMaximumLength(string number);

    bool AddressValueObjectShouldHaveCity(string city);
    bool AddressValueObjectShouldHaveCityMaximumLength(string city);

    bool AddressValueObjectShouldHaveState(string state);
    bool AddressValueObjectShouldHaveStateMaximumLength(string state);

    bool AddressValueObjectShouldHaveCountry(string country);
    bool AddressValueObjectShouldHaveCountryMaximumLength(string country);

    bool AddressValueObjectShouldHaveZipCode(string zipCode);
    bool AddressValueObjectShouldHaveZipCodeMaximumLength(string zipCode);
}