namespace ParkBuddy.Domain.ValueObjects;

public class Address
{
    public string StreetName { get; private set; }
    public string Number { get; private set; }
    public string PostalCode { get; private set; }

    public Address(string streetName, string number, string postalCode)
    {
        if (string.IsNullOrWhiteSpace(streetName))
            throw new ArgumentException("Street is required");
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Street is required");
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Street is required");

        StreetName = streetName;
        Number = number;
        PostalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{StreetName} {Number}, {PostalCode}";
    }
}
