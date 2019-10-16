using Res.RunbeckExercise.DataAccess.Surface.Interfaces;


namespace Res.RunbeckExercise.DataAccess
{
    /// <summary>
    ///     Factory type for the <see cref="DataAccess" /> project.
    /// </summary>
    public class ProjectFactory
    {
        /// <summary>
        ///     Creates a new instance of <see cref="IInputFileIoManager" />.
        /// </summary>
        /// <returns>
        ///     A newly built instance of <see cref="IInputFileIoManager" />.
        /// </returns>
        public IInputFileIoManager NewInputFileIoManager() => new InputFileIoManager();


        /// <summary>
        ///     Creates a new instance of <see cref="IOutputFileIoManager" />.
        /// </summary>
        /// <returns>
        ///     A newly built instance of <see cref="IOutputFileIoManager" />.
        /// </returns>
        public IOutputFileIoManager NewOutputFileIoManager() => new OutputFileIoManager();
    }
}