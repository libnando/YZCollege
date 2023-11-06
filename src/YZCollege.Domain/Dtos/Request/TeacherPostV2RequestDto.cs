namespace YZCollege.Domain.Dtos.Request
{
    public class TeacherPostV2RequestDto : TeacherPostRequestDto
    {
        public required string FavoritePokemon { get; set; }
    }
}
