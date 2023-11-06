namespace YZCollege.Domain.Entities
{
    public class Teacher : Entity
    {
        public required string Name { get; set; }
        public string? FavoritePokemon { get; set; }
    }
}
