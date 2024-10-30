namespace OM.Application.Utils
{
    public static class Constants
    {
        // Default constants
        public const int DefaultPageSize = 20;

        // Punctuation marks
        public const char Period = '.';
        public const char Comma = ',';
        public const char ExclamationMark = '!';
        public const char QuestionMark = '?';
        public const char Colon = ':';
        public const char Semicolon = ';';
        public const char Apostrophe = '\'';
        public const char QuotationMark = '\"';
        public const char Dash = '-';
        public const char Underscore = '_';

        // Punctuation symbols
        public const string Ampersand = "&";
        public const string AtSymbol = "@";
        public const string NumberSign = "#";
        public const string DollarSign = "$";
        public const string PercentSign = "%";
        public const string Caret = "^";
        public const string Tilde = "~";
        public const string Backslash = "\\";
        public const string ForwardSlash = "/";
        public const string Pipe = "|";

        // Punctuation groups
        public const string PunctuationMarks = ".!?,:;";
        public const string PunctuationSymbols = "&@#$%^~\\|";
    }

    public static class DateTimePatterns
    {
        // Standard date patterns
        public const string ShortDatePattern = "yyyy-MM-dd";
        public const string LongDatePattern = "yyyy-MM-dd HH:mm:ss";
        public const string DateTimePattern = "yyyy-MM-dd HH:mm:ss.fff";
        public const string DateOnlyPattern = "yyyy-MM-dd";
        public const string TimeOnlyPattern = "HH:mm:ss";

        // Custom date patterns
        public const string MonthDayYearPattern = "MM/dd/yyyy";
        public const string DayMonthYearPattern = "dd/MM/yyyy";
        public const string YearMonthDayPattern = "yyyy/MM/dd";
        public const string ShortTimePattern = "HH:mm";
        public const string LongTimePattern = "HH:mm:ss.fff";

        // ISO date patterns
        public const string IsoShortDatePattern = "yyyy-MM-dd";
        public const string IsoLongDatePattern = "yyyy-MM-ddTHH:mm:ssZ";
        public const string IsoDateTimePattern = "yyyy-MM-ddTHH:mm:ss.fffZ";

        // Date separator patterns
        public const string SlashDateSeparator = "/";
        public const string DashDateSeparator = "-";
        public const string DotDateSeparator = ".";
    }

    public static class Roles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
    }

    public static class EntityStateResult
    {
        public const int Success = 1;
        public const int Error = 0;
        public const int DbUpdateConcurrencyException = -1;
        public const int Unknown = -99;
    }

    public static class OrderDirection
    {
        public const string Asc = "asc";
        public const string Desc = "desc";
    }
}
