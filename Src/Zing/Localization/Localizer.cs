using System.Linq;
using Zing.Localization;

namespace Zing.Localization {
    public delegate LocalizedString Localizer(string text, params object[] args);
}

namespace Zing.Mvc.Html {
    public static class LocalizerExtensions {
        public static LocalizedString Plural(this Localizer T, string textSingular, string textPlural, int count, params object[] args) {
            return T(count == 1 ? textSingular : textPlural, new object[] { count }.Concat(args).ToArray());
        }
    }
}