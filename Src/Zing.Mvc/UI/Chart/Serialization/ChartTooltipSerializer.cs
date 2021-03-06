namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Extensions;

    internal class ChartTooltipSerializer : ChartTooltipBaseSerializer
    {
        private readonly ChartTooltip chartTooltip;

        public ChartTooltipSerializer(ChartTooltip chartTooltip)
            : base(chartTooltip)
        {
            this.chartTooltip = chartTooltip;
        }

        public override IDictionary<string, object> Serialize()
        {
            var result = base.Serialize();

            FluentDictionary.For(result)
                .Add("shared", chartTooltip.Shared, () => chartTooltip.Shared.HasValue)
                .Add("sharedTemplate", chartTooltip.SharedTemplate, () => chartTooltip.SharedTemplate.HasValue());

            return result;
        }
    }
}