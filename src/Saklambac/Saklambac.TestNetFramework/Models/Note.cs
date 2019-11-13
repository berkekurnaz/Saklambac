using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac.TestNetFramework.Models
{
    public class Note
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }

        public Note()
        {

        }

        public Note(string Id, string Title, string Description, bool isCompleted)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.isCompleted = isCompleted;
        }

    }
}
