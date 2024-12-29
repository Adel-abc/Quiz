namespace Quiz.Models.Entities
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
