

namespace CodeCoolAPI.DTO.Author
{
    public class AuthorCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
