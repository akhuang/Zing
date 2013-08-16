namespace Zing.Mvc
{
    using System;
    using System.Diagnostics;
    using JetBrains.Annotations;

    internal static class Maybe
    {
        [DebuggerStepThrough]
        public static TResult With<TInput, TResult>(this TInput o, [NotNull] Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : class
        {
            return o == null ? null : evaluator(o);
        }
    }
}
