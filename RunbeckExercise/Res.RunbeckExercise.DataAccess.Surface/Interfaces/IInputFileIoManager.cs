using Res.RunbeckExercise.Surface.Data;


namespace Res.RunbeckExercise.DataAccess.Surface.Interfaces
{
    /// <summary>
    ///     I/O type for input files.
    /// </summary>
    public interface IInputFileIoManager
    {
        /// <summary>
        ///     Reads the contents of an input file and returns them in an instance of <see cref="InputRecordList"
        ///     />.
        /// </summary>
        /// <param name="pOptions">
        ///     The user-specified options to be used when reading the file.
        /// </param>
        /// <returns>
        ///     An instance of <see cref="InputRecordList" /> representing the contents of the input file.
        /// </returns>
        InputRecordList ReadFile(RecordSortingOptions pOptions);
    }
}