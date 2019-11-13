using Saklambac.NetFramework.Database;
using Saklambac.NetFramework.Helpers;
using Saklambac.TestNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.TestNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Saklambac");
            Console.WriteLine("*****************************");

            SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>();
            List<Note> a = saklambacDb.GetAll();
            foreach (var item in a)
            {
                Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
            }

            Console.WriteLine("*****************************");
            Note deleteNote = saklambacDb.GetOneById("test01");
            saklambacDb.Delete(deleteNote);
            Console.WriteLine("*****************************");


            List<Note> aa = saklambacDb.GetAll();
            foreach (var item in aa)
            {
                Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
            }

            Console.ReadLine();
        }
    }
}
