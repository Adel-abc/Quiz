namespace Quiz.Models.Entities
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public double Grad { get; set; }
        public float Duration { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
