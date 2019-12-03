# 3 - Add New Data
This example shows how to add new data in the table with Saklambac. </br>

## Keywords
saklambacDb.Add(T model); </br>

## Example
```C#

using Saklambac.NetFramework.Database;

public class Note
{
    public string Id { get; set; } // Must be variable in the string named Id
    public string Title { get; set; }
    public string Description { get; set; }
    public bool isComplete { get; set; }
}

class Program
{
    static void Main(string[] args)
    {    
        SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>();
        
        Note newNote = new Note();
        newNote.Title = "Write a letter";
        newNote.Description = "I will write a letter to my sister.";
        newNote.isComplete = false;
        saklambacDb.Add(newNote);
    }
}

```