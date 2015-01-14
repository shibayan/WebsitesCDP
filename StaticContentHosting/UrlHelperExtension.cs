using System.Configuration;
using System.Web.Mvc;

namespace StaticContentHosting
{
    public static class UrlHelperExtension
    {
        public static string StaticContent(this UrlHelper urlHelper, string contentPath)
        {
            return ConfigurationManager.AppSettings["StaticContentBaseUrl"] + urlHelper.Content(contentPath);
        }
    }
}