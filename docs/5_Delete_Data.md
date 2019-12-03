# 5 - Delete Data
This example shows how to delete data in the table with Saklambac. </br>

## Keywords
saklambacDb.Delete(T model); </br>

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
        
        Note deleteNote = saklambacDb.GetOneById("0g7ceyzd8ce1fu8ieja8dede");
        saklambacDb.Delete(deleteNote);
    }
}

```