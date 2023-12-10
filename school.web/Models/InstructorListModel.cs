namespace school.web.Models
{
    public class InstructorListModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime HireDate { get; set; }
        public string? HireDateDisplay { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
