# Saklambac
Easy And Fast Data Storage System For C#


## Install Saklambac
Saklambac For .Net Framework: </br>
``` Install-Package Saklambac -Version 1.0.2 ``` </br>

Saklambac For .Net Core: </br>
``` Install-Package Saklambac.Core -Version 1.0.2 ``` </br>

## Download Saklambac
You can download and install Saklambac by using the links below.</br>

Saklambac For .Net Framework: </br>
[Download For .Net Framework](https://www.nuget.org/packages/Saklambac) </br>

Saklambac For .Net Core: </br>
[Download For .Net Core](https://www.nuget.org/packages/Saklambac.Core) </br>


## How To Use Saklambac ?
A quick example for storing and searching documents:
```C#
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
    
        // We are creating the database instance.
    	SaklambacDb<Note> saklambacDb = new SaklambacDb<Note>();
        
    	Console.WriteLine("List All Notes");
        Console.WriteLine("--------------");
        List<Note> notes = saklambacDb.GetAll();
        foreach (var item in notes)
        {
        	Console.WriteLine(item.Id + "/" + item.Title + "/" + item.Description + "/" + item.isCompleted);
        }
        
        Console.WriteLine("Add New Note");
        Console.WriteLine("------------");
        Note newNote = new Note();
        newNote.Title = "Publish This Package";
        newNote.Description = "You Have To Publish This Package";
        newNote.isComplete = false;
        saklambacDb.Add(newNote);
        
        
        Console.WriteLine("Update This Note");
        Console.WriteLine("----------------");
        Note updateNote = saklambacDb.GetOneById("0g7ceyzd8ce1fu8ieja8dede");
        Note newNote = new Note();
        newNote.Title = "Publish This Package";
        newNote.Description = "You Have To Publish This Package";
        newNote.isComplete = false;
        saklambacDb.Update(updateNote, newNote);
        
        
        Console.WriteLine("Delete This Note");
        Console.WriteLine("----------------");
        Note deleteNote = saklambacDb.GetOneById("0g7ceyzd8ce1fu8ieja8dede");
        saklambacDb.Delete(deleteNote);
        
    }
}

```

## Examples
| Number | Name | Platform           | Create Date  | Link  |
| :-------------: | :-------------: |:-------------:| :-----:|  :-----:|
| 1 | School App     | Windows Form Application  | xx.xx.xxxx | Link Is Here |
| 2 | Library App     | Windows Form Application  | xx.xx.xxxx | Link Is Here |
| 3 | Contact App     | Asp.Net Mvc  | xx.xx.xxxx | Link Is Here |
| 4 | Movies App     | Asp.Net Mvc  | xx.xx.xxxx | Link Is Here |

## Documentation

You can reach the document [here...](https://github.com/berkekurnaz/Saklambac/tree/master/docs)

## Where To Use ? 
- Desktop Applications
- Web Applications

## Developers
| Name Surname        | Country           | Github Profile  | Personel Website  |
| :-------------: |:-------------:| :-----:|  :-----:|
| Berke Kurnaz     | Turkish | https://github.com/berkekurnaz  | http://www.berkekurnaz.com |

## Contact
contact@berkekurnaz.com