namespace Zing.Mvc
{
    /// <summary>
    /// Responsible for <see cref="IModelMetadataConfiguration"/> registration
    /// </summary>
    public interface IRegistrar
    {
        /// <summary>
        /// Registers metadata provider and model metadata configuration classes
        /// </summary>
        void Register();
    }
}
