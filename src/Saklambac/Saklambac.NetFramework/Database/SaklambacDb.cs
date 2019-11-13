using Saklambac.NetFramework.Abstract;
using Saklambac.NetFramework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.NetFramework.Database
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
            else if(dbType == DbType.json)
            {
                CreateFolder.CreateForJsonDb();
            }
        }
        


        /* Add Operation To Saklambac TextDb */
        public string Add(T model)
        {
            string document_path = @"SaklambacDb/TextDb/" + model.GetType().Name + ".txt";

            string addText = "";
            foreach (var item in model.GetType().GetProperties())
            {
                if (addText.Length == 0)
                {
                    addText = addText + item.GetValue(model);
                }
                else
                {
                    addText = addText + "," + item.GetValue(model);
                }
            }
            StreamWriter sw = File.AppendText(document_path);
            sw.WriteLine(addText);
            sw.Flush();
            sw.Close();
            return addText;
        }



        /* Delete Operation To Saklambac TextDb */
        public int Delete(T model)
        {
            string document_path = @"SaklambacDb/TextDb/" + model.GetType().Name + ".txt";

            List<T> data = new List<T>();
            data = this.GetAll();
            var a = model.GetType().GetProperties()[0].GetValue(model);

            int index = data.FindIndex(x => x.GetType().GetProperties()[0].GetValue(x).ToString() == model.GetType().GetProperties()[0].GetValue(model).ToString());

            var file = new List<string>(File.ReadAllLines(document_path));
            file.RemoveAt(index);
            File.WriteAllLines(document_path, file.ToArray());

            return 1;
        }



        /* GetAll Operation To Saklambac TextDb */
        public List<T> GetAll(Func<T, bool> filter = null)
        {
            string document_path = @"SaklambacDb/TextDb/Note.txt";

            List<T> data = new List<T>();
            FileStream fs = new FileStream(document_path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string line = sw.ReadLine();
            while (line != null)
            {
                string[] splitLine = line.Split(',');
                T model = new T();
                int splitCount = 0;
                for (int i = 0; i < model.GetType().GetProperties().Count(); i++)
                {
                    model.GetType().GetProperties()[i].SetValue(model, ConvertValueType.ConvertObject(splitLine[splitCount], model.GetType().GetProperties()[i].PropertyType.ToString()));
                    splitCount++;
                }
                data.Add(model);

                line = sw.ReadLine();
            }

            if (filter != null)
            {
                data = data.Where(filter).ToList();
            }

            sw.Close();
            fs.Close();
            return data;
        }



        /* GetOneById Operation To Saklambac TextDb */
        public T GetOneById(string Id)
        {
            List<T> data = new List<T>();
            data = this.GetAll();
            T findData = data.Find(x => x.GetType().GetProperties()[0].GetValue(x).ToString() == Id);
            return findData;
        }



        /* GetOneWithExpression Operation To Saklambac TextDb */
        public T GetOneWithExpression(Func<T, bool> filter)
        {
            List<T> data = new List<T>();
            data = this.GetAll();
            T findData = data.Where(filter).FirstOrDefault();
            return findData;
        }



        /* Update Operation To Saklambac TextDb */
        public int Update(T oldModel, T newModel)
        {
            string document_path = @"SaklambacDb/TextDb/" + newModel.GetType().Name + ".txt";

            List<T> data = new List<T>();
            data = this.GetAll();

            string oldData = "";
            foreach (var item in oldModel.GetType().GetProperties())
            {
                if (oldData.Length == 0)
                {
                    oldData = oldData + item.GetValue(oldModel);
                }
                else
                {
                    oldData = oldData + "," + item.GetValue(oldModel);
                }
            }

            string newData = "";
            foreach (var item in newModel.GetType().GetProperties())
            {
                if (newData.Length == 0)
                {
                    newData = oldModel.GetType().GetProperties()[0].GetValue(oldModel).ToString();
                    newData = newData + item.GetValue(newModel);
                }
                else
                {
                    newData = newData + "," + item.GetValue(newModel);
                }
            }

            string text = File.ReadAllText(document_path);
            text = text.Replace(oldData, newData);
            File.WriteAllText(document_path, text);

            return 1;
        }



    }
}
