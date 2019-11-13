using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.NetFramework.Abstract
{
    public interface ISaklambacDb<T> where T : class, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);

        T GetOneById(string Id);
        T GetOneWithExpression(Func<T, bool> filter);

        string Add(T model);

        int Update(T oldModel, T newModel);

        int Delete(T model);
        //int DeleteWithId(string Id);
    }
}
