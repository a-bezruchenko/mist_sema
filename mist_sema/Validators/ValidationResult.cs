using System.Text;

namespace mist_sema.Validators;

public class ValidationResult
{
    private ValidationResult(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public bool IsValid { get; set; }
    public string Message { get; set; }

    public static ValidationResult Success(string message = "")
    {
        return new ValidationResult(true, message);
    }

    public static ValidationResult Failure(string message)
    {
        return new ValidationResult(false, message);
    }

    public static ValidationResult Merge(IEnumerable<ValidationResult> validationResults)
    {
        var messageBuilder = new StringBuilder();
        foreach (var validationMessage in validationResults.Select(vr => vr.Message))
        {
            messageBuilder.Append(validationMessage);
            if (validationMessage != "")
                messageBuilder.Append('\n');
        }


        var isValid = validationResults.All(vr => vr.IsValid);

        return new ValidationResult(isValid, messageBuilder.ToString());
    }
}