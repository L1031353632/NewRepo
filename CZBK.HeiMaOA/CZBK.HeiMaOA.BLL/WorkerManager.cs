using CZBK.HeiMaOA.IBLL;
using CZBK.HeiMaOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.BLL
{
    public class WorkerManager : BaseManager<Worker>, IWorkerManager
    {
        protected override void SetCurrentDAO()
        {
            this.CurrentDAO = this.DBSessionContext.WorkerDAO;
            //throw new NotImplementedException();
        }
    }
}
