using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Agathas.Storefront.Repository.EF.SessionStorage
{
    public static class SessionStorageFactory
    {
        private static ISessionStorageContainer _efSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_efSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _efSessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _efSessionStorageContainer = new HttpSessionContainer();
            }

            return _efSessionStorageContainer;
        }
    }
}
