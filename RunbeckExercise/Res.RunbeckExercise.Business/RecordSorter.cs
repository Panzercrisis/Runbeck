using Res.RunbeckExercise.Business.Surface.Definitions;
using Res.RunbeckExercise.Business.Surface.Interfaces;
using Res.RunbeckExercise.DataAccess.Surface.Interfaces;
using Res.RunbeckExercise.Surface.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Res.RunbeckExercise.Business
{
    /// <summary>
    ///     Class implementing <see cref="IRecordSorter" />.  This type is not visible outside of the project.
    /// </summary>
    internal class RecordSorter : IRecordSorter
    {
        /// <summary>
        ///     The constructor.
        /// </summary>
        /// <param name="pInputFileIoManager">
        ///     The instance of <see cref="IInputFileIoManager" /> to be used.
        /// </param>
        /// <param name="pOutputFileIoManager">
        ///     The instance of <see cref="IOutputFileIoManager" /> to be used.
        /// </param>
        internal RecordSorter(IInputFileIoManager pInputFileIoManager, IOutputFileIoManager pOutputFileIoManager)
        {
            _inputFileIoManager = pInputFileIoManager;
            _outputFileIoManager = pOutputFileIoManager;
        }


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
        public void SortRecords(RecordSortingOptions pOptions)
        {
            InputRecordList input = _inputFileIoManager.ReadFile(pOptions);

            // Per the requirements, the header row's contents are irrelevant in determining a record's validity.
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ProduceOutput(Path.Combine(baseDirectory, OutputFileNames.VALID), pOptions.Delimiter, input.Records.Where(x => x.Count == pOptions.NumFields));
            ProduceOutput(Path.Combine(baseDirectory, OutputFileNames.INVALID), pOptions.Delimiter, input.Records.Where(x => x.Count != pOptions.NumFields));
        }


        /// <summary>
        ///     Produces output for a specific category (valid or invalid).  This entails writing the records to the
        ///     specified file if there are any records, or if not, deleting any such file if it exists.
        /// </summary>
        /// <param name="pPath">
        ///     The path of the output file.
        /// </param>
        /// <param name="pDelimiter">
        ///     The delimiter to use inside the file to separate individual fields within a record.
        /// </param>
        /// <param name="pRecords">
        ///     The records, if any, to be written to the file.
        /// </param>
        private void ProduceOutput(string pPath, char pDelimiter, IEnumerable<IEnumerable<string>> pRecords)
        {
            if (pRecords.Any())
            {
                _outputFileIoManager.WriteRecords(pPath, pDelimiter, pRecords);
            }
            else
            {
                _outputFileIoManager.DeleteFile(pPath);
            }
        }


        private readonly IInputFileIoManager _inputFileIoManager;
        private readonly IOutputFileIoManager _outputFileIoManager;
    }
}