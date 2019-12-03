# 2 - List Data
This example shows how to list all data in the table with Saklambac. </br>

## Keywords
saklambacDb.GetAll(); </br>

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
        
        List<Note> notes = saklambacDb.GetAll();
        foreach (var item in notes)
        {
        	Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
        }
    }
}

```