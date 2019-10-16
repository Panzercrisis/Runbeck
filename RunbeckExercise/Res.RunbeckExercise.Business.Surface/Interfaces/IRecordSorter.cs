using Res.RunbeckExercise.Surface.Data;


namespace Res.RunbeckExercise.Business.Surface.Interfaces
{
    /// <summary>
    ///     Type for sorting records from input files.
    /// </summary>
    public interface IRecordSorter
    {
        /// <summary>
        ///     Takes records from a specified input file, sorts them as being either valid or invalid, and writes
        ///     them to corresponding output files.  To be valid, a given record must have the same number of fields
        ///     as was specified by the user.
        ///     
        ///     If a record is valid, it is written to "<see cref="OutputFileNames.VALID" />".  If it is invalid, it
        ///     is written to "<see cref="OutputFileNames.INVALID" />".  This will overwrite any previous contents
        ///     in either file, if it already exists, or create a new file if necessary.
        ///     
        ///     If either category does not include any records, its corresponding file will not be created.  In
        ///     that case, if such a file previously exists, it will be deleted.
        /// </summary>
        /// <param name="pOptions">
        ///     The user-specified options to use while performing this operation.
        /// </param>
        void SortRecords(RecordSortingOptions pOptions);
    }
}