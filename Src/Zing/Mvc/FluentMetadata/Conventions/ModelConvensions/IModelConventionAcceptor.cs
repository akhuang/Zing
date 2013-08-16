namespace Zing.Mvc
{
    /// <summary>
    /// Default interface that has to be implemented to accept conventions for metadata
    /// </summary>
    public interface IModelConventionAcceptor
    {
        /// <summary>
        /// Checks whether metadata for class can be accepted
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        bool CanAcceptConventions(AcceptorContext context);
    }
}
