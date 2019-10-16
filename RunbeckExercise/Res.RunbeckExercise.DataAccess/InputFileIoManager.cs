using Res.RunbeckExercise.DataAccess.Surface.Exceptions;
using Res.RunbeckExercise.DataAccess.Surface.Interfaces;
using Res.RunbeckExercise.Surface.Data;
using System.Collections.Generic;
using System.IO;


namespace Res.RunbeckExercise.DataAccess
{
    /// <summary>
    ///     Class implementing <see cref="IInputFileIoManager" />.  This type is not visible outside of the
    ///     project.
    /// </summary>
    internal class InputFileIoManager : IInputFileIoManager
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
        /// <exception cref="InvalidFileFormatException">
        ///     Thrown when the file's internal contents are determined to be in an invalid format.
        /// </exception>
        public InputRecordList ReadFile(RecordSortingOptions pOptions)
        {
            File.ReadAllLines(pOptions.Location);
            using (StreamReader sr = new StreamReader(pOptions.Location))
            {
                string line = sr.ReadLine();

                // The requirements specify that the file must begin with a header row.
                if (line == null)
                {
                    throw new InvalidFileFormatException();
                }

                string[] headerRow = line.Split(pOptions.Delimiter);
                var records = new List<IReadOnlyCollection<string>>();

                while ((line = sr.ReadLine()) != null)
                {
                    records.Add(line.Split(pOptions.Delimiter));
                }
                return new InputRecordList(headerRow, records);
            }
        }
    }
}