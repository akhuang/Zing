namespace Zing.Mvc
{
    using System.Web.Mvc;
    using JetBrains.Annotations;

    /// <summary>
    /// Splits DisplayName attribute by cammel cases
    /// </summary>
    public class DisplayNameTransformer : TransformerCore
    {
        /// <summary>
        /// If true, upper case property name won't be splitted
        /// </summary>
        public static bool DisableNameProcessing { get; set; }

        /// <summary>
        /// Process display attibute
        /// </summary>
        /// <param name="metadata"></param>
        public void Transform([NotNull] ModelMetadata metadata)
        {
            Invariant.IsNotNull(metadata, "metadata");

            if (!DisableNameProcessing && (metadata.DisplayName == null || metadata.DisplayName == metadata.PropertyName))
            {
                metadata.DisplayName = metadata.PropertyName.SplitUpperCaseToString();
            }
        }

    }
}
