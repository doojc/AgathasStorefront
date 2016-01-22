using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections;
using System.Threading;

namespace Agathas.Storefront.Repository.EF.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable _efSessions = new Hashtable();

        public DbContext GetCurrentSession()
        {
            DbContext efSession = null;

            if (_efSessions.Contains(GetThreadName()))
                efSession = (DbContext)_efSessions[GetThreadName()];

            return efSession;
        }

        public void Store(DbContext session)
        {
            if (_efSessions.Contains(GetThreadName()))
                _efSessions[GetThreadName()] = session;
            else
                _efSessions.Add(GetThreadName(), session);
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
