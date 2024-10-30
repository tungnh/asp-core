namespace OM.Application.Utils
{
    public static class Messages
    {
    }

    public static class ErrorMessages
    {
        /// <summary>{0} is required.</summary>
        public const string ErrorValidationRequired = "{0} is required.";
        /// <summary>The {0} must be at max {1} characters long.</summary>
        public const string ErrorValidationStringLength = "The {0} must be at max {1} characters long.";
        /// <summary>The {0} must be at least {2} and at max {1} characters long.</summary>
        public const string ErrorValidationStringLengthWithMinimum = "The {0} must be at least {2} and at max {1} characters long.";
        /// <summary>The password and confirmation password do not match.</summary>
        public const string ErrorValidationConfirmPassword = "The password and confirmation password do not match.";
        /// <summary>Error confirming your email.</summary>
        public const string ErrorConfirmEmail = "Error confirming your email.";
    }

    public static class SuccessMessages
    {
        /// <summary>Thank you for confirming your email.</summary>
        public const string ThankConfirmEmail = "Thank you for confirming your email.";
    }

    public static class WarningMessages
    {
    }

    public static class InformationMessages
    {
    }
}
