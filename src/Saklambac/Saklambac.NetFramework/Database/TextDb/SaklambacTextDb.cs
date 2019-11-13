using Saklambac.NetFramework.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.NetFramework.Database.TextDb
{
    public class SaklambacTextDb<T> where T : class, new()
    {



        /* Add Operation To Saklambac TextDb */
        public int Add(T model)
        {
            try
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
            }
            catch
            {

            }

            return 1;
        }



        /* Delete Operation To Saklambac TextDb */
        public int Delete(T model)
        {
            try
            {
                string document_path = @"SaklambacDb/TextDb/" + model.GetType().Name + ".txt";

                List<T> data = new List<T>();
                data = this.GetAll();
                var a = model.GetType().GetProperties()[0].GetValue(model);

                int index = data.FindIndex(x => x.GetType().GetProperties()[0].GetValue(x).ToString() == model.GetType().GetProperties()[0].GetValue(model).ToString());

                var file = new List<string>(File.ReadAllLines(document_path));
                file.RemoveAt(index);
                File.WriteAllLines(document_path, file.ToArray());
            }
            catch
            {

            }

            return 1;
        }



        /* GetAll Operation To Saklambac TextDb */
        public List<T> GetAll(Func<T, bool> filter = null)
        {
            List<T> data = new List<T>();
            try
            {
                string document_path = @"SaklambacDb/TextDb/Note.txt";

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
            }
            catch
            {

            }
            return data;
        }



        /* GetOneById Operation To Saklambac TextDb */
        public T GetOneById(string Id)
        {
            T findData = new T();
            try
            {
                List<T> data = new List<T>();
                data = this.GetAll();
                findData = data.Find(x => x.GetType().GetProperties()[0].GetValue(x).ToString() == Id);
            }
            catch
            {

            }
            return findData;
        }



        /* GetOneWithExpression Operation To Saklambac TextDb */
        public T GetOneWithExpression(Func<T, bool> filter)
        {
            T findData = new T();
            try
            {
                List<T> data = new List<T>();
                data = this.GetAll();
                findData = data.Where(filter).FirstOrDefault();
            }
            catch 
            {

            }

            return findData;
        }



        /* Update Operation To Saklambac TextDb */
        public int Update(T oldModel, T newModel)
        {
            try
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

            }
            catch
            {

            }

            return 1;
        }



    }
}
