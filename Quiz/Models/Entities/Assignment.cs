namespace Quiz.Models.Entities
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public DateOnly AssignedDate { get; set; }
    }
}
