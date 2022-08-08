namespace CodeCoolAPI.DTO.Author
{
    public class AuthorReadDTO
    {
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
