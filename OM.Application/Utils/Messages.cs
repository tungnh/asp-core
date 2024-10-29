namespace OM.Application.Utils
{
    public static class Messages
    {
    }

    public static class ErrorMessage
    {
        /// <summary>{0} is required.</summary>
        public const string Required = "{0} is required.";
        /// <summary>The {0} must be at max {1} characters long.</summary>
        public const string StringLength = "The {0} must be at max {1} characters long.";
        /// <summary>The {0} must be at least {2} and at max {1} characters long.</summary>
        public const string StringLengthWithMinimum = "The {0} must be at least {2} and at max {1} characters long.";
        /// <summary>The password and confirmation password do not match.</summary>
        public const string ConfirmPassword = "The password and confirmation password do not match.";
    }
}
