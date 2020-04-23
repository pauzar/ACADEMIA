using System.Collections.Generic;

namespace Console_App1.Lib.Models
{
    public class Subjects : Entity
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public Student Student { get; set; }

    }
}
