using System;


namespace Res.RunbeckExercise.DataAccess.Surface.Exceptions
{
    /// <summary>
    ///     Exception type indicating that the internal contents of the input file were invalid.
    /// </summary>
    public class InvalidFileFormatException : Exception
    {
        /// <summary>
        ///     The constructor.  This supplies a basic error message to the base class's (<see cref="Exception" />)
        ///     constructor.
        /// </summary>
        public InvalidFileFormatException() : base("The file was in an invalid format.") { }
    }
}