using System.Collections.Generic;


namespace Res.RunbeckExercise.Surface.Data
{
    /// <summary>
    ///     Represents a list of records from an input file.  This includes column headers from the header row.
    /// </summary>
    public class InputRecordList
    {
        /// <summary>
        ///     The constructor.
        /// </summary>
        /// <param name="pHeaderRow">
        ///     That which <see cref="HeaderRow" /> is set to.
        /// </param>
        /// <param name="pRecords">
        ///     That which <see cref="Records" /> is set to.
        /// </param>
        public InputRecordList(IEnumerable<string> pHeaderRow, IEnumerable<IReadOnlyCollection<string>> pRecords)
        {
            HeaderRow = pHeaderRow;
            Records = pRecords;
        }


        /// <summary>
        ///     The contents of the header row.  Each field is stored in a separate string.
        /// </summary>
        public IEnumerable<string> HeaderRow { get; }


        /// <summary>
        ///     The records in the input file.  Each field of each record is stored in a separate string.
        ///     
        ///     Each member of this collection is an individual record.  Each of those records is stored as an <see
        ///     cref="IReadOnlyCollection{string}" /> containing each of its fields.
        /// </summary>
        public IEnumerable<IReadOnlyCollection<string>> Records { get; }
    }
}