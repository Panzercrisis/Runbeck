using System.Collections.Generic;


namespace Res.RunbeckExercise.DataAccess.Surface.Interfaces
{
    /// <summary>
    ///     I/O type for output files.
    /// </summary>
    public interface IOutputFileIoManager
    {
        /// <summary>
        ///     Writes records to a specified file.  If such a file already exists, it will be overwritten.  If it
        ///     doesn't already exist, it will be created.
        /// </summary>
        /// <param name="pPath">
        ///     The path of the file to write to.
        /// </param>
        /// <param name="pDelimiter">
        ///     The delimiter to be used to separate individual fields within a record.
        /// </param>
        /// <param name="pRecords">
        ///     The records to be written to the file.  Each field of each record should be stored as a separate
        ///     string.
        ///     
        ///     Each member of this collection should represent a different record.  Each member of a specific
        ///     record should represent a different field of that record.
        /// </param>
        void WriteRecords(string pPath, char pDelimiter, IEnumerable<IEnumerable<string>> pRecords);


        /// <summary>
        ///     Deletes the specified output file.
        /// </summary>
        /// <param name="pPath">
        ///     The path of the file be deleted.
        /// </param>
        void DeleteFile(string pPath);
    }
}