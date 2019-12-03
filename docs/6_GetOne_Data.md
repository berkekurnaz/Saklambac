# 5 - Get One Data
This example shows how to get one data in the table with Saklambac. </br>

## Keywords
saklambacDb.GetOneById(string Id); </br>

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
        
        Note findNote = saklambacDb.GetOneById("0g7ceyzd8ce1fu8ieja8dede");
    }
}

```