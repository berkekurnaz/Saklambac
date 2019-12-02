using Saklambac.NetCore.Abstract;
using Saklambac.NetCore.Database.TextDb;
using Saklambac.NetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saklambac.NetCore.Database
{
    public enum DbType { text, json };

    public class SaklambacDb<T> : ISaklambacDb<T> where T : class, new()
    {



        private DbType dbType;



        public SaklambacDb(DbType dbType = DbType.text)
        {
            this.dbType = dbType;

            if (dbType == DbType.text)
            {
                CreateFolder.CreateForTextDb();
            }
            else if (dbType == DbType.json)
            {
                CreateFolder.CreateForJsonDb();
            }
        }



        /* Add Operation To Saklambac TextDb */
        public int Add(T model)
        {
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                db.Add(model);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return 1;
        }



        /* Delete Operation To Saklambac TextDb */
        public int Delete(T model)
        {
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                db.Delete(model);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return 1;
        }



        /* Delete Operation With Id To Saklambac TextDb */
        public int DeleteWithId(string Id)
        {
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                db.DeleteWithId(Id);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return 1;
        }



        /* GetAll Operation To Saklambac TextDb */
        public List<T> GetAll(Func<T, bool> filter = null)
        {
            List<T> data = new List<T>();
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                data = db.GetAll(filter);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return data;
        }



        /* GetOneById Operation To Saklambac TextDb */
        public T GetOneById(string Id)
        {
            T data = new T();
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                data = db.GetOneById(Id);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return data;
        }



        /* GetOneWithExpression Operation To Saklambac TextDb */
        public T GetOneWithExpression(Func<T, bool> filter)
        {
            T data = new T();
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                data = db.GetOneWithExpression(filter);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return data;
        }



        /* Update Operation To Saklambac TextDb */
        public int Update(T oldModel, T newModel)
        {
            if (dbType == DbType.text)
            {
                SaklambacTextDb<T> db = new SaklambacTextDb<T>();
                db.Update(oldModel, newModel);
            }
            else if (dbType == DbType.json)
            {
                // Json Operations Will Be Here.
            }
            return 1;
        }


    }
}
