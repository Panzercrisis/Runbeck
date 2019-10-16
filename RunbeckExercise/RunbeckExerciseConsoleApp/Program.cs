using Res.RunbeckExercise.Business;
using Res.RunbeckExercise.Business.Surface.Definitions;
using Res.RunbeckExercise.Surface.Data;
using System;


namespace RunbeckExerciseConsoleApp
{
    /// <summary>
    ///     Entry point class for the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Entry point method for the program.
        /// </summary>
        /// <param name="pArgs">
        ///     Any command line arguments passed in to the program.  This is not currently used and is basically
        ///     here as a formality.
        /// </param>
        public static void Main(string[] pArgs)
        {
            try
            {
                new ProjectFactory().NewRecordSorter().SortRecords(
                    new RecordSortingOptions(GetLocation(), GetDelimiter(), GetNumFields())
                );

                Console.WriteLine($"Operation completed successfully!  Any valid records will be stored in \"{OutputFileNames.VALID}\", and any invalid records " +
                        $"will be stored in \"{OutputFileNames.INVALID}\".  If there are no records in either category, no such file will exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem performing the operation:");
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        ///     Gets the path of the input file from the user.
        /// </summary>
        /// <returns>
        ///     The user-specified path of the input file.
        /// </returns>
        private static string GetLocation()
        {
            Console.WriteLine("Where is the input file located?");
            while (true)
            {
                string location = Console.ReadLine().Trim().Trim('"');
                if ((location ?? "") != "")
                {
                    Console.WriteLine("");
                    return location;
                }
                Console.WriteLine("Please enter a file location:");
            }
        }


        /// <summary>
        ///     Gets the field delimiter from the user.
        /// </summary>
        /// <returns>
        ///     The user-specified field delimiter.
        /// </returns>
        private static char GetDelimiter()
        {
            const string comma = "C";
            const string tab = "T";

            Console.WriteLine($"Is the file comma-delimited ({comma}) or tab-delimited ({tab})?");
            while (true)
            {
                switch (Console.ReadLine().ToUpper())
                {
                    case comma:
                        Console.WriteLine("");
                        return ',';

                    case tab:
                        Console.WriteLine("");
                        return '\t';

                    default:
                        Console.WriteLine($"Please enter \"{comma}\" or \"{tab}\":");
                        break;
                }
            }
        }


        /// <summary>
        ///     Gets from the user the number of fields that a given input record should have to be considered
        ///     valid.
        /// </summary>
        /// <returns>
        ///     The user-specified number of fields that a given input record should have.  This will be an integer
        ///     between 1 and <see cref="int.MaxValue" /> inclusively.
        /// </returns>
        private static int GetNumFields()
        {
            Console.WriteLine("How many fields should each record have?");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numFields) && numFields > 0)
                {
                    Console.WriteLine("");
                    return numFields;
                }
                Console.WriteLine($"Please enter a valid integer between 1 and {int.MaxValue}:");
            }
        }
    }
}