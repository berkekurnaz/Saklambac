# 1 - Create Database
This example describes how to create a new database with Saklambac. </br>

## Keywords
SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>(); </br>

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
    
        Console.WriteLine("SaklambacDb Created...");
    }
}

```