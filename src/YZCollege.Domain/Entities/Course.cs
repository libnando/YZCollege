namespace YZCollege.Domain.Entities
{
    public class Course : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required long Duration { get; set; }
        public required int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
    }
}
