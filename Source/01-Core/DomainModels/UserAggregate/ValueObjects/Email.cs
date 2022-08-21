using Framework.Exceptions;
using System.Text.RegularExpressions;

namespace DomainModels.UserAggregate.ValueObjects;

public sealed record Email
{
    public Email(string value)
    {
        Validate(value);
        Value = value;
    }

    public static string Default => "default@default.com";

    public string Value { get; private set; }

    private static void Validate(string value)
    {
        Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(value);
        if (!match.Success)
        {
            throw new EShopException("Email is invalid", ExceptionStatus.InvalidArgument);
        }
    }

    public static implicit operator Email(string value)
    {
        return new Email(value);
    }

    public static implicit operator string(Email email)
    {
        return email.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}
