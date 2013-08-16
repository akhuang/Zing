namespace Zing.Mvc
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Responsible for creating of <see cref="IModelMetadataConfiguration"/> implementations
    /// </summary>
    public interface IMetadataConstruction
    {
        /// <summary>
        /// Allows to define custom factory to contruct model metadata configuration classes
        /// </summary>
        /// <param name="configurationFactory">A factory to instantiate <see cref="IModelMetadataConfiguration"/> classes</param>
        /// <returns>Fluent</returns>
        IRegistrar ConstructMetadataUsing(Func<IEnumerable<IModelMetadataConfiguration>> configurationFactory);
    }
}
