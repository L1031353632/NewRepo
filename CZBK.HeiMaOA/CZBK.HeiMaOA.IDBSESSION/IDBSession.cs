﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.HeiMaOA.IDAO;

namespace CZBK.HeiMaOA.IDBSESSION
{
    public partial interface IDBSession
    {
        IWorkerDAO WorkerDAO { get; set; }
        bool SaveChanges();
    }
}
