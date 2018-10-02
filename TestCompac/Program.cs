using System;
using System.Linq;

/// <summary>
/// The exercise here is to return a list of 1000 unique pin numbers
/// which meets the criteria set out below:
///     • Pin numbers must:
///         o Be 4 Digits
///         o Cannot have incremental digits, e.g. 1234, or 1248
///         o Cannot have repeated digits, e.g. 8888, or 8863
///     • In the list of 1000, we cannot have repeated pin numbers
/// </summary>

class Program
{
    /// <summary>
    /// Method executed at the beginning.
    /// </summary>
    static void Main(string[] args)
    {
        Console.WriteLine($"Author:\tCarlos Manosalva\n");
        Console.WriteLine($"The exercise here is to return a list of 1000 unique pin numbers\nwhich meets the criteria set out below:\n\t• Pin numbers must:\n\t\to Be 4 Digits\n\t\to Cannot have incremental digits, e.g. 1234, or 1248\n\t\to Cannot have repeated digits, e.g. 8888, or 8863\n\t• In the list of 1000, we cannot have repeated pin numbers.\n");
        Console.WriteLine($"Index\tNumber");

        // Flag used to approve the criterias.
        bool approved = true;

        // Number used to know how many numbers have been found, it can't be mayor to 1000.
        int iteratedNumber = 0;

        // Number used to be analyzed.
        int sampleNumber = 0;

        // Array which shows when a sample has been already analyzed.
        bool[] sampleRepeated = new bool[10000];

        // Array used to keep separate the digits.
        int[] digits = new int[] { 0, 0, 0, 0 };

        while (iteratedNumber < 1000)
        {
            approved = true;
            sampleNumber = new Random().Next(0, 9999);
            string numberApproved;

            // Has been the sample already analyzed?
            if (!sampleRepeated[sampleNumber])
            {
                sampleRepeated[sampleNumber] = true;

                // Separate the digits
                digits[3] = sampleNumber % 10;
                digits[2] = sampleNumber / 10 % 10;
                digits[1] = sampleNumber / 100 % 10;
                digits[0] = sampleNumber / 1000 % 10;

                //  How many digits are there
                int result = digits.Distinct().Count();

                //  Validation for repeated digits
                if (result != 4)
                {
                    approved = false;
                }

                //  Validation for incremental digits
                if (digits[0] < digits[1] && digits[1] < digits[2] && digits[2] < digits[3])
                {
                    approved = false;
                }

                //  If everything is ok, the sample will be printed
                if (approved)
                {
                    iteratedNumber = iteratedNumber + 1;
                    numberApproved = string.Join("", digits);
                    Console.WriteLine($"{iteratedNumber}\t{numberApproved}");
                }
                sampleNumber = sampleNumber + 1;
            }
        }
        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}