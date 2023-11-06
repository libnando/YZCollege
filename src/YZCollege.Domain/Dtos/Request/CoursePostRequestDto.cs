namespace YZCollege.Domain.Dtos.Request
{
    public class CoursePostRequestDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required long Duration { get; set; }
        public required int TeacherId { get; set; }
    }
}
