using System.Globalization;

namespace GestorAvaliacao.Api.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var cultureInfo = new CultureInfo("en");

            if ( string.IsNullOrWhiteSpace(requestCulture) == false &&
                supportedLanguages.Any(c => c.Name.Equals(requestCulture.ToString().Split(";")[0].Split(",")[0])))
            {
                cultureInfo = new CultureInfo(requestCulture.ToString().Split(";")[0].Split(",")[0]);
            }
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
