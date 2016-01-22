using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Agathas.Storefront.Repository.EF.SessionStorage;

namespace Agathas.Storefront.Repository.EF
{
    public class SessionFactory
    {
        private static DbContext _sessionFactory;

        private static void Init()
        {

        }

        private static DbContext GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();

            return _sessionFactory;
        }

        private static DbContext GetNewSession()
        {
            return GetSessionFactory();
        }

        public static DbContext GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            DbContext currentSession = sessionStorageContainer.GetCurrentSession();

            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }

            return currentSession;
        }

    }
}
