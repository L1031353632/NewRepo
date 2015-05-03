using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CZBK.HeiMaOA.IDAO;

namespace CZBK.HeiMaOA.DAOFACTORY
{
    public partial class DAOAbstractFactory
    {
        public static IWorkerDAO CreateWorkerDAO()
        {
            string classFulleName = ConfigurationManager.AppSettings["DaoNameSpace"] + ".WorkerDAO";
            //object obj = Assembly.Load(ConfigurationManager.AppSettings["DaoAssembly"]).CreateInstance(classFulleName, true);
            var obj = CreateInstance(ConfigurationManager.AppSettings["DaoAssembly"], classFulleName);
            return obj as IWorkerDAO;
        }

        private static object CreateInstance(string assemblyPath, string classFulleName)
        {
            var assembly = Assembly.Load(assemblyPath);//加载程序集.
            return assembly.CreateInstance(classFulleName);
        }
    }
}
