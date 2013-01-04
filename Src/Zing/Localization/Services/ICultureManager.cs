using System.Collections.Generic;
using System.Web;
using Zing.Localization.Records;

namespace Zing.Localization.Services {
    public interface ICultureManager : IDependency {
        IEnumerable<string> ListCultures();
        void AddCulture(string cultureName);
        void DeleteCulture(string cultureName);
        string GetCurrentCulture(HttpContextBase requestContext);
        CultureRecord GetCultureById(int id);
        CultureRecord GetCultureByName(string cultureName);
        string GetSiteCulture();
        bool IsValidCulture(string cultureName);
    }
}
