namespace CodeCoolAPI.DTO.Author
{
    public class AuthorUpdateDTO
    {
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
