namespace school.web.Models
{
    public class OfficeAssignmentViewModel
    {
        public int InstructorId { get; set; }
        public string? Location { get; set; }
        public byte[]? Timestamp { get; set; }

        public OfficeAssignmentViewModel()
        {
            long currentTimeTicks = DateTime.UtcNow.Ticks;

            // Convertir los ticks a un array de bytes
            Timestamp = BitConverter.GetBytes(currentTimeTicks);
        }
    }
}
