using System;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace CacheAside.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // キャッシュに存在するか確認する
            var date = _cache.Get("cachekey");

            if (date == null)
            {
                // キャッシュに無かったので新しく追加する
                date = DateTime.Now.ToString();

                _cache.Add("cachekey", date, DateTimeOffset.Now.AddSeconds(10));
            }

            ViewBag.Message = date;

            return View();
        }

        // InProc なキャッシュを使う
        private static readonly ObjectCache _cache = MemoryCache.Default;

        // Redis をキャッシュに使う場合はこっち
        //private static readonly ObjectCache _cache = new RedisCacheClient.RedisCache("CONNECTION_STRING");
    }
}