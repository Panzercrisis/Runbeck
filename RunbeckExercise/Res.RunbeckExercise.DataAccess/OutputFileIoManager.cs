using Res.RunbeckExercise.DataAccess.Surface.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Res.RunbeckExercise.DataAccess
{
    /// <summary>
    ///     Class implementing <see cref="IOutputFileIoManager" />.  This type is not visible outside of the
    ///     project.
    /// </summary>
    internal class OutputFileIoManager : IOutputFileIoManager
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
        public void WriteRecords(string pPath, char pDelimiter, IEnumerable<IEnumerable<string>> pRecords)
        {
            if (File.Exists(pPath))
            {
                File.Delete(pPath);
            }

            string delimiter = pDelimiter.ToString();
            File.WriteAllLines(pPath, pRecords.Select(x => string.Join(delimiter, x)));
        }


        /// <summary>
        ///     Deletes the specified output file.
        /// </summary>
        /// <param name="pPath">
        ///     The path of the file be deleted.
        /// </param>
        public void DeleteFile(string pPath) => File.Delete(pPath);
    }
}