namespace Res.RunbeckExercise.Surface.Data
{
    /// <summary>
    ///     Represents the list of user-specified options used when sorting records from a given input file.
    /// </summary>
    public class RecordSortingOptions
    {
        /// <summary>
        ///     The constructor.
        /// </summary>
        /// <param name="pLocation">
        ///     That which <see cref="Location" /> is set to.
        /// </param>
        /// <param name="pDelimiter">
        ///     That which <see cref="Delimiter" /> is set to.
        /// </param>
        /// <param name="pNumFields">
        ///     That which <see cref="NumFields" /> is set to.
        /// </param>
        public RecordSortingOptions(string pLocation, char pDelimiter, int pNumFields)
        {
            Location = pLocation;
            Delimiter = pDelimiter;
            NumFields = pNumFields;
        }


        /// <summary>
        ///     The path of the input file.
        /// </summary>
        public string Location { get; }


        /// <summary>
        ///     The delimiter used to separate individual fields within the input and output files.
        /// </summary>
        public char Delimiter { get; }


        /// <summary>
        ///     The number of fields each record should contain to be considered valid.
        /// </summary>
        public int NumFields { get; }
    }
}