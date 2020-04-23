using System;
namespace Console_App1.Lib.Models
{
    public class Exam : Entity
    {
        public Student Student { get; set; }
        public Subjects Subject { get; set; }
        public double Mark { get; set; }
        public int idExam { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
