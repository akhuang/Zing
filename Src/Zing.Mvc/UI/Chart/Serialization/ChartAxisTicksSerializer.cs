namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Extensions;

    internal class ChartAxisTicksSerializer : IChartSerializer
    {
        private readonly ChartAxisTicks ticks;

        public ChartAxisTicksSerializer(ChartAxisTicks ticks)
        {
            this.ticks = ticks;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("size", ticks.Size, () => ticks.Size.HasValue)
                .Add("visible", ticks.Visible, () => ticks.Visible.HasValue)
                .Add("step", ticks.Step, () => ticks.Step.HasValue)
                .Add("skip", ticks.Skip, () => ticks.Skip.HasValue)
                .Add("color", ticks.Color, () => ticks.Color.HasValue());

            return result;
        }
    }
}