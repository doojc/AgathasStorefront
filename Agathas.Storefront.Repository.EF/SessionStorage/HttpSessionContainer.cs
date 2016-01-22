using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace Agathas.Storefront.Repository.EF.SessionStorage
{
    public class HttpSessionContainer : ISessionStorageContainer
    {
        private string _sessionKey = "EFSession";

        public DbContext GetCurrentSession()
        {
            DbContext efSession = null;

            if (HttpContext.Current.Items.Contains(_sessionKey))
                efSession = (DbContext)HttpContext.Current.Items[_sessionKey];

            return efSession;
        }

        public void Store(DbContext session)
        {
            if (HttpContext.Current.Items.Contains(_sessionKey))
                HttpContext.Current.Items[_sessionKey] = session;
            else
                HttpContext.Current.Items.Add(_sessionKey, session);
        }
    }
}
