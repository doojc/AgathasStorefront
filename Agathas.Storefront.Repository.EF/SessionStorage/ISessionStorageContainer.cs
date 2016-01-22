using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Agathas.Storefront.Repository.EF.SessionStorage
{
    public interface ISessionStorageContainer
    {
        DbContext GetCurrentSession();
        void Store(DbContext session);
    }
}
