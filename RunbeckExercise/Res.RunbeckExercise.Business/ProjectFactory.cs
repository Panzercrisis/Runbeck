using Res.RunbeckExercise.Business.Surface.Interfaces;


namespace Res.RunbeckExercise.Business
{
    /// <summary>
    ///     Factory type for the <see cref="Business" /> project.
    /// </summary>
    public class ProjectFactory
    {
        /// <summary>
        ///     Creates a new instance of <see cref="IRecordSorter" />.
        /// </summary>
        /// <returns>
        ///     A newly built instance of <see cref="IRecordSorter" />.
        /// </returns>
        public IRecordSorter NewRecordSorter() => new RecordSorter(_dataAccessFactory.NewInputFileIoManager(), _dataAccessFactory.NewOutputFileIoManager());


        private readonly DataAccess.ProjectFactory _dataAccessFactory = new DataAccess.ProjectFactory();
    }
}