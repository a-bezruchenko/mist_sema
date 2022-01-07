using System.Text;

namespace mist_sema.Validators
{
    public class ValidationResult
    {
        public readonly bool IsValid;
        public readonly string Message;

        private ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

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
            StringBuilder messageBuilder = new StringBuilder();
            foreach (string validationMessage in validationResults.Select(vr => vr.Message))
            {
                messageBuilder.Append(validationMessage);
                if (validationMessage != "")
                    messageBuilder.Append("\n");
            }
                

            bool isValid = validationResults.All((ValidationResult vr) => vr.IsValid);

            return new ValidationResult(isValid, messageBuilder.ToString());
        }
    }
}