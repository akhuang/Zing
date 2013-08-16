namespace Zing.Mvc
{
    using JetBrains.Annotations;

    /// <summary>
    /// Default model convention acceptor. All models with metadata configurations can accept 
    /// </summary>
    public class DefaultModelConventionAcceptor : IModelConventionAcceptor
    {
        /// <summary>
        /// Checks whether metadata for class can be accepted
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool CanAcceptConventions([NotNull] AcceptorContext context)
        {
            return context.HasMetadataConfiguration;
        }
    }
}
