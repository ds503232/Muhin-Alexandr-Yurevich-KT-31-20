namespace MuhinAlexandrYurevichKT_31_20.Models
{
    public class Otsenka
    {
        public int OtsenkaId { get; set; }
        public int Mark { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
