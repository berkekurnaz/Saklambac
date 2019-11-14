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
            Console.WriteLine("************** LIST ALL NOTES ***************");

            SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>();
            List<Note> notes = saklambacDb.GetAll();
            foreach (var item in notes)
            {
                Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
            }

            Console.WriteLine("************** UPDATE NOTE ***************");

            Note updateNote = saklambacDb.GetOneById("0g7ceyzd8ce1fu8ieja8dede");
            Note newNote = new Note();
            newNote.isCompleted = true;
            newNote.Title = "Update Tests"; 
            newNote.Description = "test";
            saklambacDb.Update(updateNote, newNote);

            Console.WriteLine("************** LIST ALL NOTES ***************");

            List<Note> notess = saklambacDb.GetAll();
            foreach (var item in notess)
            {
                Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
            }


            Console.ReadLine();
        }
    }
}
