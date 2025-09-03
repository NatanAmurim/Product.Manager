using Ganss.Xss;

namespace ProductManager.Api.Presentation.Extensions
{
    public static class SanitizerExtensions
    {
        private static readonly HtmlSanitizer _sanitizer = new ();

        /// <summary>
        /// Remove tags HTML e scripts do input para prevenir ataques XSS.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Uma string limpa, sem tags HTML ou scripts maliciosos</returns>
        public static string Sanitize(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return input;
            return _sanitizer.Sanitize(input);
        }
    }
}
