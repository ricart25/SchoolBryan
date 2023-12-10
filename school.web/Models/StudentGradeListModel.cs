namespace school.web.Models
{
    public class StudentGradeListModel
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public decimal? Grade { get; set; }
    }
}
