using Saklambac.NetCore.Database;
using Saklambac.TestNetCore.Models;
using System;
using System.Collections.Generic;

namespace Saklambac.TestNetCore
{
    class Program
    {
        static void Main(string[] args)
        {

            SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>();

            Console.WriteLine("Add New Note");
            Note note = new Note();
            note.Title = "Test01";
            note.Description = "Test01 Description";
            note.isCompleted = false;
            saklambacDb.Add(note);


            Console.WriteLine("List All Notes");
            List<Note> notes = saklambacDb.GetAll();
            foreach (var item in notes)
            {
                Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
            }

            Console.ReadLine();
        }
    }
}
