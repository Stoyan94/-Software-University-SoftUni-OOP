namespace PersonsInfo
{
    public static class ExceptionMessages
    {
        internal const int MinDigitsNames = 3;
        public const string FirstName = "First name cannot contain fewer than {0} symbols!";
        public const string LastName = "Last name cannot contain fewer than {0} symbols!";

        internal const int MinAge = 0;
        public const string AgeZero = "Age cannot be zero or a negative integer!";

        internal const decimal MinSalary = 650;
        public const string Salary = "Salary cannot be less than {0} leva!";
    }
}
