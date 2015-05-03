using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Memcached.ClientLibrary;
namespace CZBK.HeiMaOA.COMMON
{
    public class MemcacheHelper
    {
        private static MemcachedClient ServerList { get; set; }
        static MemcacheHelper()
        {
            string ip = ConfigurationManager.AppSettings["IPAddressPort"];
            //string[] serverlist = { "192.168.255.250:11211", "101.0.0.1:11211" };

            string[] serverlist = ip.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);

            pool.InitConnections = 3;
            pool.MinConnections = 3;
            pool.MaxConnections = 5;

            pool.SocketConnectTimeout = 1000;
            pool.SocketTimeout = 3000;

            pool.MaintenanceSleep = 30;
            pool.Failover = true;

            pool.Nagle = false;
            pool.Initialize();

            // 获得客户端实例
            ServerList = new MemcachedClient();
            ServerList.EnableCompression = false;
        }

        public static bool Set(string key, object value)
        {
            return ServerList.Set(key, value);
        }
        public static bool Set(string key, object value, DateTime expiry)
        {
            return ServerList.Set(key, value, expiry);
        }
        public static object Get(string key)
        {
            return ServerList.Get(key);
        }
        public static bool Add(string key, object value)
        {
            return ServerList.Add(key, value);
        }
        public static bool Add(string key, object value, DateTime expiry)
        {
            return ServerList.Add(key, value, expiry);
        }
        public static bool Delete(string key)
        {
            return ServerList.Delete(key);
        }

    }
}
