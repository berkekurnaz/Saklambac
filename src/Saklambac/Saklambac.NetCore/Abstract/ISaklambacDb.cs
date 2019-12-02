using System;
using System.Collections.Generic;

namespace Saklambac.NetCore.Abstract
{
    public interface ISaklambacDb<T> where T : class, new()
    {
        List<T> GetAll(Func<T, bool> filter = null);

        T GetOneById(string Id);
        T GetOneWithExpression(Func<T, bool> filter);

        int Add(T model);

        int Update(T oldModel, T newModel);

        int Delete(T model);
        int DeleteWithId(string Id);
    }
}
